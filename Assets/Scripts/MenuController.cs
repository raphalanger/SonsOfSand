using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private GameObject MenuHUD;
    public Button StartBtn;
    public Button QuitBtn;

    // Start is called before the first frame update
    void Start()
    {     

    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartButton()
    {
        SceneManager.LoadScene("Introdução", LoadSceneMode.Single);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
