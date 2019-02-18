using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] bool spawn = true;
    //[SerializeField] Attacker attackerPrefab;
    [SerializeField] Attacker[] attackerPrefabArray;
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
    public void StopSpawning()
    {
        spawn = false;
    }

    private void SpawnAttacker()
    {
        var attackerIndex = UnityEngine.Random.Range(0, attackerPrefabArray.Length);
        Spawn(attackerPrefabArray[attackerIndex]);
    }

    private void Spawn(Attacker attacker)
    {
        Attacker newAttacker = Instantiate(attacker, transform.position, Quaternion.identity) as Attacker;
        newAttacker.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
