using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    Text healthText;
    GameSession gameSession;
    void Start()
    {
 gameSession = FindObjectOfType<GameSession>();
        healthText = GetComponent<Text>();
       
    }


    void Update()
    {
        healthText.text = gameSession.GetHealth().ToString();
    }
}
