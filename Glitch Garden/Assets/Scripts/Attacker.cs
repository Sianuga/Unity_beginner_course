using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    float currentSpeed = 1f;
    [SerializeField] float health,damageToLives=1;
    [SerializeField] GameObject deathVFX;
    GameObject currentTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed*Time.deltaTime);
        UpdateAnimationState();
    }
    public float GetLifeDamage()
    {
        return damageToLives;
    }
    private void UpdateAnimationState()
    {
        if (!currentTarget)
            GetComponent<Animator>().SetBool("IsAttacking",false);
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Projectile projectile = collision.gameObject.GetComponent<Projectile>();
        if (!projectile)
        {
            return;
        }
        health =- projectile.GetDamage();
        if(health<=0)
        {
            TriggerVFX();
            FindObjectOfType<LevelController>().SubtractAttacker();
            Destroy(gameObject);
        }
 projectile.Hit();
    }

    private void TriggerVFX()
    {
        if(!deathVFX) { return; }
        Instantiate(deathVFX, transform.position, Quaternion.identity);
    }
    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("IsAttacking", true);
        currentTarget = target;
    }
    public void StrikeCurrentTarget(float damage)
    {
        if(!currentTarget)
        {
            return;
        }
        Defender health = currentTarget.GetComponent<Defender>();
        health.DealDamage(damage);
    }
}
