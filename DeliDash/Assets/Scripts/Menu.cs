using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadScene("Final Demo");
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void SettingsPage(){
        SceneManager.LoadScene("Settings");
    }

    public void MenuScreen(){
        SceneManager.LoadScene("MainMenu");
    }

    public void GameOver(){
        SceneManager.LoadScene("Demo");
    }

    public void Credits(){
        SceneManager.LoadScene("Credits");
    }

    public void Cut(){
        SceneManager.LoadScene("Cutscene");
    }
}
