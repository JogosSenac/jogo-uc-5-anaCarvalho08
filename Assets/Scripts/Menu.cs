using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    public GameObject pauseMenu;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu();
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
}
