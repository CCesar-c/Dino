using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int MoneyCount;
    [HideInInspector] public string Nome;
    public GameObject pl;
    public Sprite[] spr;
    public int index;
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
    }
    void Start()
    {
        Application.targetFrameRate = 60;
        Nome = PlayerPrefs.GetString("nomeP");
        StartCoroutine(SelectPlayers());
    }
    [Header("Supabase")]
    [HideInInspector] public string supabaseUrl = "https://mtpvcaekijuaessqkykm.supabase.co";
    [HideInInspector] public string anonKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Im10cHZjYWVraWp1YWVzc3FreWttIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NjExNTQxMDAsImV4cCI6MjA3NjczMDEwMH0.MrohDyIoolSw-yMy70Y2L40CsmJR5lnJMxM6DlUVwFo";
    [HideInInspector] public PlayerDinoList lista;
    IEnumerator SelectPlayers()
    {
        // SELECT * FROM players ORDER BY score DESC
        string url = supabaseUrl + "/rest/v1/player_dino?select=*";

        UnityWebRequest req = UnityWebRequest.Get(url);

        req.SetRequestHeader("apikey", anonKey);
        req.SetRequestHeader("Authorization", "Bearer " + anonKey);
        req.SetRequestHeader("Accept", "application/json");

        yield return req.SendWebRequest();

        if (req.isNetworkError || req.isHttpError)
        {
            Debug.LogError("Error: " + req.error);
        }
        else
        {
            // respons
            string rawJson = req.downloadHandler.text;

            // Unity NO parsea arrays directamente
            string wrappedJson = "{ \"players\": " + rawJson + " }";

            lista = JsonUtility.FromJson<PlayerDinoList>(wrappedJson);
        }
    }

    void LateUpdate()
    {
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            pl = GameObject.Find("player");
            pl.GetComponent<SpriteRenderer>().sprite = spr[index];

        }
    }
    public void reloadScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
    int res;
    int newtime;
    public void StartUpdateMoney()
    {
        for (int i = 0; i < lista.players.Length; i++)
        {
            if (lista.players[i].name == Nome)
            {
                newtime = Mathf.Max(pl.GetComponent<Moviment>().tim, lista.players[i].score);
                res = lista.players[i].moneycount + MoneyCount;

                StartCoroutine(UpdateMoney(res, newtime));
                break;
            }
        }
    }

    IEnumerator UpdateMoney(int newMoney, int newscore)
    {
        string url = supabaseUrl +
            "/rest/v1/player_dino?name=eq." + UnityWebRequest.EscapeURL(Nome);
        UpdateData data = new UpdateData
        {
            moneycount = newMoney,
            score = newscore
        };

        string json = JsonUtility.ToJson(data);

        UnityWebRequest req = new UnityWebRequest(url, "PATCH");
        req.uploadHandler = new UploadHandlerRaw(
            System.Text.Encoding.UTF8.GetBytes(json)
        );
        req.downloadHandler = new DownloadHandlerBuffer();

        req.SetRequestHeader("Content-Type", "application/json");
        req.SetRequestHeader("apikey", anonKey);
        req.SetRequestHeader("Authorization", "Bearer " + anonKey);
        req.SetRequestHeader("Prefer", "return=representation");

        yield return req.SendWebRequest();

        if (req.isNetworkError || req.isHttpError)
        {
            Debug.LogError("UPDATE ERROR: " + req.error);
            Debug.LogError(req.downloadHandler.text);
        }
        else
        {
            Debug.Log("UPDATE OK");
        }
    }

    [System.Serializable]
    public class PlayerDino
    {
        public int id;
        public string name;
        public int moneycount;
        public int score;
    }

    [System.Serializable]
    public class PlayerDinoList
    {
        public PlayerDino[] players;
    }
    [System.Serializable]
    public class UpdateData
    {
        public int moneycount;
        public int score;
    }

}