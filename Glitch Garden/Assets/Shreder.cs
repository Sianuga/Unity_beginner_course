using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shreder : MonoBehaviour
{
    HealthDisplay healthDisplay;
    void Start()
    {
   healthDisplay = FindObjectOfType<HealthDisplay>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        healthDisplay.UpdateDisplay(collision.gameObject.GetComponent<Attacker>().GetLifeDamage());
        FindObjectOfType<LevelController>().SubtractAttacker();
        Destroy(collision.gameObject);
    }
}
