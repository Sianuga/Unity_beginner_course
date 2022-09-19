using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_management : MonoBehaviour
{
    [SerializeField] string sceneName;
public void LoadNextScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
