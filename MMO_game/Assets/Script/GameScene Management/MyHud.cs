using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(NetworkManager))]
public class MyHud : MonoBehaviour
{
 
    public static MyHud hud;
    public InputField serveripinput;

    private NetworkManager networkManager;


    private void Awake()
    {
        if (hud != null)
        {
            return;
        }
        networkManager = this.GetComponent<NetworkManager>();
        hud = this;
    }


    private void Start()
    {
        UIManager.UI.OpenMenu();
        UIManager.UI.OpenLogin();

    }

    public void PlayAsServer()
    {
        if (!NetworkClient.active && !NetworkServer.active && networkManager.matchMaker == null)
        {

            StaticStats.GameStatus = 1;
            networkManager.StartHost();
 
        }


    }
    public void PlayAsClient()
    {
        if (!NetworkClient.active && !NetworkServer.active && networkManager.matchMaker == null)
        {

            networkManager.networkAddress = serveripinput.text;
            if (networkManager.networkAddress == null)
            {
                networkManager.networkAddress = UIManager.UI.GetComponentInChildren<InputField>().text;
            }
            Toast.toast.ShowToast("Network Address: " + networkManager.networkAddress +" port: "+ networkManager.networkPort, 3);
            StaticStats.GameStatus = 1;
            networkManager.StartClient();

        }


    }



    // Update is called once per frame
    public void Quit()
    {

        //TODO: save user stats
        //DB.setAll();
        DB.setHp();
        if (NetworkServer.active && NetworkClient.active)
        {
            networkManager.StopHost();
        }
        else
        {
            networkManager.StopClient();
        }
        StaticStats.GameStatus = 0;

        Application.Quit();
        Debug.Log("App is quit.");
        Debug.Log(StaticStats.Hp);
    }




}