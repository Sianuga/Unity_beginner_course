using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    private float destroyTime;
    public void Awake()
    {
        ParticleSystem system = GetComponent<ParticleSystem>();
        destroyTime = Time.time + 2.5f;

    }
    public void Update()
    {
        if (Time.time >= destroyTime)
        {
            GameObject.Destroy(gameObject);
        }
    }
}


