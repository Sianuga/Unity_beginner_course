using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Loader : MonoBehaviour
{

public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadGame()
    {
       SceneManager.LoadScene("Level");
        if (!FindObjectOfType<GameSession>()) return;
        else
        FindObjectOfType<GameSession>().ResetGame();
    }
    public void LoadEndMenu()
    {
        StartCoroutine(LoadDelayToEnd(2f));
       
    }
    public void Quit()
    {
        Application.Quit();
    }
    IEnumerator LoadDelayToEnd(float time)
    {
        yield return new WaitForSeconds(time);
 SceneManager.LoadScene("Game Over");
    }
}
