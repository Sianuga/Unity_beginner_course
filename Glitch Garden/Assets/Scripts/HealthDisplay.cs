using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthDisplay : MonoBehaviour
{
    [SerializeField] float baseLife = 3;
    float health;
    Text lifeDisplay;
    void Start()
    {
        health = baseLife - PlayerPrefsController.GetDifficulty();
        lifeDisplay = GetComponent<Text>();
        lifeDisplay.text = health.ToString();
    }

    void Update()
    {
    
    }
    public void UpdateDisplay(float damage)
    {
        health -= damage;
if(health==0)
        {
            FindObjectOfType<SceneLoader>().LoadScene("Lose screen");
        }
        lifeDisplay.text = health.ToString();
    }
}
