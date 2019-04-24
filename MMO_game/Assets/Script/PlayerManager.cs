using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class PlayerManager : NetworkBehaviour
{
    #region
    public static PlayerManager instance;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        if (!isLocalPlayer)
        {
            Destroy(this);
            return;
        }
        instance = this;


    }

    #endregion



    public void KillPlayer() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
