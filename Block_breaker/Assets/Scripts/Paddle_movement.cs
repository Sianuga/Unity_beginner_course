using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle_movement : MonoBehaviour
{
    [SerializeField] float screen_width_with_units = 16f;
    [SerializeField] float minimum_screen_width=1f;
    [SerializeField] float maximum_screen_width = 15f;
   
  

    void Update()
    {
       float mousePosInUnits = Input.mousePosition.x / Screen.width * screen_width_with_units;
        Vector2 paddlePos = new Vector2(mousePosInUnits, transform.position.y);
        paddlePos.x = Mathf.Clamp(mousePosInUnits, minimum_screen_width, maximum_screen_width );
        transform.position = paddlePos;
    }


}
