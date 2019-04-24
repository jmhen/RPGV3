using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] public static UIManager UI;
    [SerializeField] public GameObject basicUI;
    [SerializeField] public GameObject inventoryUI;
    [SerializeField] public GameObject nodeReclaimUI;
    [SerializeField] public GameObject chatUI;
    [SerializeField] public GameObject loaderUI;
    [SerializeField] public GameObject mapUI;
    [SerializeField] public GameObject toastUI;
    [SerializeField] public GameObject craftingUI;
    [SerializeField] public GameObject menuUI;
    [SerializeField] public GameObject login;
    [SerializeField] Button playBtn;
    
    private void Awake()
    {
        UI = this;
    }

    private void Start()
    {
        basicUI.SetActive(true);
        inventoryUI.SetActive(false);
        nodeReclaimUI.SetActive(false);
        chatUI.SetActive(false);
        loaderUI.SetActive(false);
        //mapUI.SetActive(false);
        toastUI.SetActive(true);
        craftingUI.SetActive(false);
    }

    public void CloseMenu()
    {

        menuUI.SetActive(false);
        Debug.Log("CLOSEING MENU: " + menuUI.activeSelf);
    }
    public void OpenMenu()
    {
        if(StaticStats.GameStatus == 1)
        {
            playBtn.GetComponentInChildren<Text>().text = "Resume";
        }
        menuUI.SetActive(true);
    }
    public void OpenLogin()
    {
        login.SetActive(true);
    }
    public void CloseLogin()
    {

        login.SetActive(false);
        Debug.Log("CLOSEING LOGIN: " + login.activeSelf);
    }

    public void ToggleChat()
    {
        chatUI.SetActive(!chatUI.activeSelf);
        Debug.Log("ChatUIactive:" + chatUI.activeSelf);
    }
}
