using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem; // Importa o sistema de entrada do Unity

public class GameController : MonoBehaviour
{
    public float life; // vida do jogador
    private GameObject Player; // referencia do objeto "Player"(jogador)
    private GameObject PauseMenu; // referencia para o objeto do menu de pausa
    private GameObject MenuHUD;
    private GameObject Bastet;
    private PlayerScript playerScript;
    private BastetScript bastetScript;
    public Button ResumeButton;
    public Button RestartButton;
    public Button MainMenuButton;
    bool paused; // define o menu de pausa como visivel ou oculto;
    public Text menuMessage; // mensagem de pausa do jogo: pausado, vitoria ou derrota
    private GameObject Joystick;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        Player = GameObject.Find("Player");
        playerScript = gameObject.GetComponent<PlayerScript>();
        //MenuHUD = GameObject.Find("MenuHUD");
        PauseMenu = GameObject.Find("PauseMenu");
        Joystick = GameObject.Find("Joysticks");
        //Bastet = GameObject.FindGameObjectWithTag("Bastet");
        //bastetScript = Bastet.GetComponent<BastetScript>();
        
        paused = false;
        PauseMenu.SetActive(false);
        //MenuHUD.SetActive(true);

        //tutorialPanel = GameObject.Find("Tutorial Panel"); // Codigo demo da professora; esse objeto ainda nao foi implementado
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            playerScript.Health -= bastetScript.Damage;
        if (Input.GetKeyDown(KeyCode.E))
            bastetScript.Health -= playerScript.Damage;
        //if (Input.GetKeyDown(KeyCode.Escape))
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
            TogglePause();

    }


    //metodo novo para pausar o jogo
    public void TogglePause()
    {
        if (paused == false)
        {
            paused = true;
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
        }
        else
        {
            paused = false; // Alterna o estado de pausa
            Time.timeScale = 1;
            PauseMenu.SetActive(false);
        }        
    }



    public void sprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(speedup());
        }
    }

    public IEnumerator speedup()
    { 
        Player.GetComponent<PlayerScript>().speed = 10.0f;
        yield return new WaitForSeconds(4f);
        Player.GetComponent<PlayerScript>().speed = 5.0f;
    
    }

    // seção do MENU DE PAUSA
    public void ResumeGame()
    { 
        Time.timeScale = 1;
        PauseMenu.SetActive(false);        
        paused = false;

    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Introdução", LoadSceneMode.Single);
        //ResumeGame();
        Time.timeScale = 1; // Reseta o tempo do jogo
        paused = false; // Reseta o estado de pausa
        PauseMenu.SetActive(false); // Desativa o menu de pausa
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu Principal", LoadSceneMode.Single);
    }
    // fim da seção do MENU DE PAUSA

    private void GameControl()
    {
        if(playerScript.Health == 0)
        {
            SceneManager.LoadScene("Game Over", LoadSceneMode.Additive);
        }
        if (bastetScript.Health == 0)
        {
            SceneManager.LoadScene("Victory", LoadSceneMode.Additive);
        }
    }
}