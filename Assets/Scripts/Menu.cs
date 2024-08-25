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
    public GameObject prefab;

    void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
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
        Instantiate(prefab, playerMovement.PlayerPositionInicial(), Quaternion.identity);
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        telaMorte.SetActive(false);
    }
}
