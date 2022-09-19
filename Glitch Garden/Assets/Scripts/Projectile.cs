using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed, damage,rotation;

    public void Hit()
    {
        Destroy(gameObject);
    }
    public float GetDamage()
    {
        return damage;
    }
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.forward, rotation * Time.deltaTime, Space.World);
    }
}
