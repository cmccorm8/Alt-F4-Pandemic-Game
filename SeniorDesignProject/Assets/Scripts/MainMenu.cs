using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;



public class MainMenu : MonoBehaviour
{
    public string startLevel;

    public string levelSelect;

    public void Start()
    {
        //FindObjectOfType<AudioManager>().Play("MenuTheme");
    }

    public void NewGame()
    {
        SceneManager.LoadScene("SuperMarket"); //(SceneManager.GetActiveScene().buildIndex + 1 );
        FindObjectOfType<AudioManager>().StopPlaying("MenuTheme");
        FindObjectOfType<AudioManager>().Play("MainTheme");
    }

    public void Options()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
