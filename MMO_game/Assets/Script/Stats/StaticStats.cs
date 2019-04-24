using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public static class StaticStats
{
   
    private static int mp, hp, scene=1, gameStatus=0;
    private static Vector3 position;
    public static string playerName;

    public static int GameStatus
    {
        get
        {
            return gameStatus;
        }
        set
        {
            gameStatus = value;
        }
    }
    public static int Mp
    {
        get
        {
            return mp;
        }
        set
        {
            mp = value;
        }
    }

    public static int Hp
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
        }
    }

    public static int Scene
    {
        get
        {
            return scene;
        }
        set
        {
            scene = value;
        }
    }

    public static Vector3 Position
    {
        get
        {
            return position;
        }
        set
        {
            position = value;
        }
    }
    public static string PlayerName
    {
        get
        {
            return playerName;
        }
        set
        {
            playerName = value;
        }
    }
}
