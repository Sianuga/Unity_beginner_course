using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] float soundEffectTime = 5f;
 [SerializeField]   int attackersAlive=0;
    [SerializeField] GameObject winText, winDarkScreen;
    bool timerFinished=false,repeat = true;
    public void AddAttacker()
    {
        attackersAlive++;
    }
    public void SubtractAttacker()
    {
        attackersAlive--;
    }
    public void TimerFinished()
    {
        timerFinished=true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        Attackerspawner[] spawnerArray = FindObjectsOfType<Attackerspawner>();
        foreach (Attackerspawner spawner in spawnerArray)
        {
            spawner.StopSpawn();
        }
    }

    void Update()
    {




        if (attackersAlive == 0 && timerFinished && repeat)
        {
            repeat = false;
 winText.SetActive(true);
            winDarkScreen.SetActive(true);
            StartCoroutine(LevelFinish());
        }
           

    }
    IEnumerator LevelFinish()
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(soundEffectTime);
        FindObjectOfType<SceneLoader>().LoadScene("Level 2");
    }
}
