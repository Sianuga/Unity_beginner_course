using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //config params
    [SerializeField] AudioClip clip_1;
    [SerializeField] GameObject blockSparklesVFX;
  
    [SerializeField] Sprite[] hitSprites;

    //Cached reference
    Level level;

    //state variables
    int timesHit=0;
  
    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
            level.block_count();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag=="Breakable")
        {
            HandleHit();

        }

        // Debug.Log(collision.gameObject.name);
    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            Destroy_block();
        }
        else
            ShowNextHitSprites();
    }

    private void ShowNextHitSprites()
    {
  int spriteIndex = timesHit-1;
        if (hitSprites[spriteIndex] != null)
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        else
            Debug.LogError("Block sprite is missing from an array in object " + gameObject.name);
  
    }

    private void Destroy_block()
    {
        level.block_broken();
        level.next_level();
        block_destroy();
        TriggerParticles();
    }

    private void block_destroy()
    {
        AudioSource.PlayClipAtPoint(clip_1, Camera.main.transform.position, 2);
        Destroy(gameObject);
    }
    private void TriggerParticles()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX,transform.position,transform.rotation);
        Destroy(sparkles, 1f);
    }
}
