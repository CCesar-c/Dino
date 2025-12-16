using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Canvasmanager : MonoBehaviour
{
    public GameObject panel;
    public Text text_error;
    public Text text_Perfil;
    public InputField input;
    public GameObject ParentRank;
    public GameObject Parentskin;
    public GameObject ParentHome;
    int homestate = 0;

    void Start()
    {
        try
        {
            // PlayerPrefs.DeleteKey("nomeP");
            StartCoroutine(nameof(setValores));
            var nome = PlayerPrefs.GetString("nomeP", "");
            if (string.IsNullOrEmpty(nome))
            {
                panel.SetActive(true);
            }
            else
            {
                panel.SetActive(false);
            }
        }
        catch (System.Exception e)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", "log_Juego.txt");
            List<string> testo = new List<string>
            {
                "Erro " + System.DateTime.Now.ToString() + ": " + e,
            };
            File.AppendAllLines(path, testo);
            // throw; esto crashe el app despues de ejecutar lo anterior
        }
    }
    public void reloadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
    public void Statebool(int i)
    {
        homestate = i;
    }
    int ejecutados = 0;
    public void createTextRank()
    {
        if (ejecutados == 0)
        {
            var listaordenada = GameManager.instance.lista.players.OrderByDescending(p => p.score).ToList();
            for (int i = 0; i < listaordenada.Count; i++)
            {
                var newText = Instantiate(ParentRank.transform.GetChild(0), new Vector2(ParentRank.transform.GetChild(0).position.x, ParentRank.transform.GetChild(0).position.y - 50 * i), ParentRank.transform.GetChild(i).transform.rotation, ParentRank.transform);
                newText.GetComponent<Text>().text = $"Nome: {listaordenada[i].name}\nScore: {listaordenada[i].score}";
            }
            ejecutados = 1;
        }
    }
    public void namePlayer()
    {
        foreach (var item in GameManager.instance.lista.players)
        {
            if (item.name == input.text)
            {
                PlayerPrefs.SetString("nomeP", input.text.Trim());
                panel.SetActive(false);
            }
            else
            {
                text_error.text = "Usuario não registrado ou Não encontrado";
            }
        }
    }

    IEnumerator setValores()
    {
        yield return new WaitForSeconds(2);
        var nome = PlayerPrefs.GetString("nomeP");
        foreach (var item in GameManager.instance.lista.players)
        {
            if (item.name == nome)
            {
                text_Perfil.text = $"Nome: {item.name}\nMoedas: {item.moneycount}\nBest Score: {item.score}";
            }
        }
    }
    void LateUpdate()
    {
        ParentHome.SetActive(homestate == 0);
        ParentRank.SetActive(homestate == 1);
        Parentskin.SetActive(homestate == 2);
    }
}