using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class DeathMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject deathMenuUI;

    public InfectionMeter infection;

    void Update()
    {
        if(infection.get() >= 500 && !GameIsPaused)
        {
            FindObjectOfType<AudioManager>().StopPlaying("MainTheme");
            //FindObjectOfType<AudioManager>().Play("Infected");
            FindObjectOfType<AudioManager>().Play("InfectedTheme");
            GameIsPaused = true;
            deathMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("SuperMarket"); //(SceneManager.GetActiveScene().buildIndex + 1 );
        FindObjectOfType<AudioManager>().StopPlaying("InfectedTheme");
        FindObjectOfType<AudioManager>().Play("MainTheme");
        infection.set(0);
        GameIsPaused = false;
        Time.timeScale = 1f;
    }

    /*void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }*/

    public void LoadMenu()
    {
        infection.set(0);
        GameIsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        FindObjectOfType<AudioManager>().StopPlaying("MainTheme");
        FindObjectOfType<AudioManager>().StopPlaying("InfectedTheme");
        FindObjectOfType<AudioManager>().Play("MenuTheme");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
