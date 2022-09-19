using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_speed : MonoBehaviour
{ 
    [Range(0.1f,10f)][SerializeField] float game_speed=1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale=game_speed;
    }
}
