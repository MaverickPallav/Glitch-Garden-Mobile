
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerEasy : MonoBehaviour
{
    bool spawn = true;
    public float minSpawnDelay = 1f;
    public float maxSpawnDelay = 5f;
    public float waitingTime = 25f;
    [SerializeField] Attacker[] EnemyArray;
   
    public void StopSpawing()
    {
        spawn = false;
    }

    private IEnumerator Start()
    {
        var difficultyLevel = PlayerPrefsController.GetDifficultyLevel();
        var levelnumber = PlayerPrefsController.getlevel();
        if (levelnumber == 1)
        {
            if (difficultyLevel == 1)
            {
                maxSpawnDelay = 4;
                minSpawnDelay = 4;
                waitingTime = 10f;
            }
            if (difficultyLevel == 2)
            {
                maxSpawnDelay = 3;
                minSpawnDelay = 3;
                waitingTime = 10f;
            }
            if (difficultyLevel == 3)
            {
                maxSpawnDelay = 2;
                minSpawnDelay = 2;
                waitingTime = 10f;
            }
        }

        if (levelnumber == 2)
        {
            if (difficultyLevel == 1)
            {
                maxSpawnDelay = 5;
                minSpawnDelay = 3;
                waitingTime = 15f;
            }
            if (difficultyLevel == 2)
            {
                maxSpawnDelay = 4;
                minSpawnDelay = 2;
                waitingTime = 12f;
            }
            if (difficultyLevel == 3)
            {
                maxSpawnDelay = 3;
                minSpawnDelay = 1;
                waitingTime = 10f;
            }
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
        Attacker newAttacker = Instantiate(myAttacker, transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }
}
