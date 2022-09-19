using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Buttons : MonoBehaviour
{
    [SerializeField] string sceneDestination;
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (sceneDestination == "Main_menu")
            FindObjectOfType<Level>().Reset_game();
        SceneManager.LoadScene(sceneDestination);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
