using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Our level timer in seconds")]
    [SerializeField] float levelTime=10f;
    void Update()
    {
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        bool TimerFinished = (Time.timeSinceLevelLoad >= levelTime);
        if(TimerFinished)
        {
            FindObjectOfType<LevelController>().TimerFinished();
        }
    }
}
