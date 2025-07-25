using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class endGameController : MonoBehaviour
{
    public GameObject DeathMenu;
    public Button menu;
    public Button quit;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu Principal", LoadSceneMode.Single);

    }
    public void Quit()
    {
        Application.Quit();
    }
}
