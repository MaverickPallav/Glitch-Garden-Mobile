
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    bool spawn = true;
    public float minSpawnDelay = 1f;
    public float maxSpawnDelay = 5f;
    public float waitingTime = 25f;
    [SerializeField] Attacker[] EnemyArray;
    public float waitingtimeJabba = 1;
    public float waitingtimeBundi = 1;
   
    public void StopSpawing()
    {
        spawn = false;
    }

    private IEnumerator Start()
    {
        var difficultyLevel = PlayerPrefsController.GetDifficultyLevel();
        if(difficultyLevel == 1)
        {

            maxSpawnDelay = 10;
            minSpawnDelay = 8;
            waitingTime = 15f;
            waitingtimeJabba = 20f;
            waitingtimeBundi = 25f;
        }
        if(difficultyLevel == 2)
        {
            maxSpawnDelay = 8;
            minSpawnDelay = 6;
            waitingTime = 12f;
            waitingtimeJabba = 17f;
            waitingtimeBundi = 22f;
        }
        if (difficultyLevel == 3)
        {
            maxSpawnDelay = 6;
            minSpawnDelay = 4;
            waitingTime = 10f;
            waitingtimeJabba = 15f;
            waitingtimeBundi = 20f;
        }
        yield return new WaitForSeconds(waitingTime);
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        while(spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        var attackerindex = Random.Range(0, EnemyArray.Length);
        Spawn(EnemyArray[attackerindex]);
    }

    private void Spawn(Attacker myAttacker)
    {
        if (myAttacker == EnemyArray[2])
        {
            StartCoroutine(JabbaSpawn());
        }
        IEnumerator JabbaSpawn()
        {
            yield return new WaitForSeconds(waitingtimeJabba);
            Attacker newjabba = Instantiate(myAttacker, transform.position, transform.rotation) as Attacker;
        }

        if (myAttacker == EnemyArray[3])
        {
            StartCoroutine(BundiSpawn());
        }
        IEnumerator BundiSpawn()
        {
            yield return new WaitForSeconds(waitingtimeBundi);
            Attacker newjabba = Instantiate(myAttacker, transform.position, transform.rotation) as Attacker;
        }

        Attacker newAttacker = Instantiate(myAttacker, transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }

    
}
