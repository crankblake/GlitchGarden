using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] bool spawn = true;
    [SerializeField] Attacker attackerPrefab;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] float minSpawnDelay = 1f;
    // Start is called before the first frame update
    IEnumerator Start()
    {

        while (spawn)
        {
            float spawnRandom = UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(spawnRandom);
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        var newEnemy = Instantiate(attackerPrefab, transform.position, Quaternion.identity);
        //Debug.Log(Time.timeSinceLevelLoad);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
