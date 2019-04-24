using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    [SerializeField] Button playBtn;
    int gameStatus;
    private void Start()
    {
        gameStatus = StaticStats.GameStatus;
        if (gameStatus == 1)
        {
            playBtn.GetComponentInChildren<Text>().text = "Resume";
        }
        else
        {
            playBtn.GetComponentInChildren<Text>().text = "Play";
        }

    }
    public void Play()
    {
        if (gameStatus ==0)
        {
            MyHud.hud.PlayAsClient();
        }
        gameObject.SetActive(false);

    }



    // Update is called once per frame
    public void Quit()
    {
        MyHud.hud.Quit();
    }

}
