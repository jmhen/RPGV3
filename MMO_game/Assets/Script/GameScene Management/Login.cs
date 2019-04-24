using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{

    string input;

    public void Continue()
    {
        input = gameObject.GetComponentInChildren<InputField>().text;

        if (CheckIfUserExist(input))
        {
            //TODO: Retrieve user data
            StaticStats.playerName = input;
            gameObject.SetActive(false);

        }


    }

    bool CheckIfUserExist(String username)
    {
        //TODO: check if PlayerID exit
        return true;
    }
}
