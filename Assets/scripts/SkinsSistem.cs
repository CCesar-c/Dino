using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinsSistem : MonoBehaviour
{
    public Image skin;
    public void ChangeIndex(bool enun)
    {

        if (enun)
        {
            GameManager.instance.index += 1;
        }
        else
        {
            GameManager.instance.index -= 1;
        }
        if (GameManager.instance.index < 0)
        {
            GameManager.instance.index = 0;
        }
        else if (GameManager.instance.index >= GameManager.instance.spr.Length)
        {
            GameManager.instance.index = 1;
        }
    }
    void LateUpdate()
    {
        switch (GameManager.instance.index)
        {
            case 0:
                skin.sprite = GameManager.instance.spr[GameManager.instance.index];
                break;
            case 1:
                skin.sprite = GameManager.instance.spr[GameManager.instance.index];
                break;
        }
    }
}
