using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    int score = 0;
    int health=1;
    private void Start()
    {
        health = FindObjectOfType<Movement_player>().GetHealth();
    }

    void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        int numberOfGameSessions = FindObjectsOfType<GameSession>().Length;
        if(numberOfGameSessions>1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

public int GetScore()
    {
        return score;
    }
    public void AddToScore(int points)
    {
        score += points;
    }
    public void ResetGame()
    {
        Destroy(gameObject);
    }
    public void DecreaseHealth(int damage)
    {
        health -= damage;
    }
    public int GetHealth()
    {
        return health;
    }
}
