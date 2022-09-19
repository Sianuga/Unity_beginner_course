using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrFox : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collided = collision.gameObject;

 if(collided.GetComponent<Gravestone>())
            {
                GetComponent<Animator>().SetTrigger("JumpTrigger");
            }

       else if (collided.GetComponent<Defender>())
        {
           
            GetComponent<Attacker>().Attack(collided);
        }
    }
}
