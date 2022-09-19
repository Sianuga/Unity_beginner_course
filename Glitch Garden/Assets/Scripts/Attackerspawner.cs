using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackerspawner : MonoBehaviour
{
    [SerializeField] Attacker[] attacker;
    [SerializeField] float minSpawnTime=1f, maxSpawnTime=1f;
    [SerializeField] bool spawn = false;

   IEnumerator Start()
    {
       while (spawn)
        { 
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            if(spawn)
                SpawnAttacker(attacker);
        }
        
    }
    public void StopSpawn()
    {
        spawn = false;
    }
private void SpawnAttacker(Attacker[] attackers)
    {
        Spawn(attackers[Random.Range(0,attacker.Length)]);
    }

    private void Spawn(Attacker attacker)
    {
        FindObjectOfType<LevelController>().AddAttacker();
        Attacker newAttacker = Instantiate(attacker, transform.position, Quaternion.identity) as Attacker;
        newAttacker.transform.parent = transform;
    }
}
