using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex==0)
        StartCoroutine(LoadingScreen());
    }

    IEnumerator LoadingScreen()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("StartMenu");
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
