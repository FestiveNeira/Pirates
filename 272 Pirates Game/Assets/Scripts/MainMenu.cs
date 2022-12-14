using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public AudioClip menu;
    public void ExitButton()
    {
        Application.Quit();
    }
    
    public void StartGame()
    {
        AudioSolver.instance.SwapTrack(menu);
        SceneManager.LoadScene("Menu");
    }

    public void CharacterSelect()
    {
        SceneManager.LoadScene("Charcter Select");
    }

    public void Controls()
    {
        SceneManager.LoadScene("Controls");
    }
}
