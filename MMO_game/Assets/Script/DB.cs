using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

[Serializable]
public static class DB
{
    private static string serverAddress = "http://10.12.54.189/";
    private static string header = "game.php?key=None";


    public static string HttpGet(string uri)
    {
        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(stream, Encoding.GetEncoding("utf-8"));
            string returnString = streamReader.ReadToEnd();

            streamReader.Close();
            stream.Close();
            response.Close();

            return returnString;

        }
        catch (Exception)
        {
            return "error";
        }
    }

    private static string currentStatus()
    {
        string status = "&hp=" + StaticStats.Hp +
            "&mp=" + StaticStats.Mp +
        "&scene=" + StaticStats.Scene +
            "&X=" + StaticStats.Position.x +
        "&Y=" + StaticStats.Position.y +
            "&Z=" + StaticStats.Position.z +
        "&loginName=" + "Player";
        return status;
    }

    private static string queryIs(string query)
    {
        string uri = serverAddress + header + "&query=" + query + currentStatus();

        return uri;
    }

    public static string setAll()
    {
        string uri = queryIs("setAll");

        return HttpGet(uri);
    }

    public static string getAll()
    {
        string uri = queryIs("getAll");

        return HttpGet(uri);
    }

    public static string setHp()
    {
        string uri = queryIs("setHp");

        return HttpGet(uri);
    }

    public static string getHp()
    {
        string uri = queryIs("getHp");

        return HttpGet(uri);
    }


}
