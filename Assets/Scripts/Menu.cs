using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject telaMorte;

    public GameObject player;
    public PlayerMovement playerMovement;
    public GameObject prefabPlayer;

    public GameObject bola;
    public Bola bolaScript;
    public GameObject prefabBola;

    public GameObject bola2;
    public Bola bolaScript2;
    public GameObject prefabBola2;

    void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
        bolaScript = bola.GetComponent<Bola>();
        bolaScript2 = bola2.GetComponent<Bola>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu();
        }

        if(!playerMovement.VerificaSePlayerEstaVivo())
        {
            Destroy(player);
            TelaDeMorte();
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene ("Fase1");
    }

    public void MenuPrincipal()
    {
        SceneManager.LoadScene ("Menu");
    }

    public void SairGame()
    {
        Application.Quit();
    }

    public void PauseMenu()
    {
        pauseMenu.SetActive (true);
        Time.timeScale = 0.0f;
    }

    public void Resume()
    {
        pauseMenu.SetActive (false);
        Time.timeScale = 1.0f;
    }

    public void TelaDeMorte()
    {
        telaMorte.SetActive(true);
    }

    public void Replay()
    {
        telaMorte.SetActive(false);

        Instantiate(prefabPlayer, playerMovement.PlayerPositionInicial(), Quaternion.identity);
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();

        if(bola == null)
        {
            Instantiate(prefabBola, bolaScript.BolaPositionInicial(), Quaternion.identity);
            bola = GameObject.FindGameObjectWithTag("Ball");
            bolaScript = bola.GetComponent<Bola>();
        }
        
        if(bola2 == null)
        {
            Instantiate(prefabBola2, bolaScript2.BolaPositionInicial(), Quaternion.identity);
            bola2 = GameObject.FindGameObjectWithTag("Ball");
            bolaScript2 = bola2.GetComponent<Bola>();
        }

        SceneManager.LoadScene ("Fase1");
    }
}
