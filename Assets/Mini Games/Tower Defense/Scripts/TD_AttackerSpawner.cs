using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TD_AttackerSpawner : MonoBehaviour {

    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] TD_Attacker[] attackerPrefabArray;

    bool spawn = true;

    IEnumerator Start()
    {
        while(spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }
	
    public void StopSpawning()
    {
        spawn = false;
    }

    private void SpawnAttacker()
    {
        var attackerIndex = Random.Range(0, attackerPrefabArray.Length);
        Spawn(attackerPrefabArray[attackerIndex]);
    }

    private void Spawn (TD_Attacker myAttacker)
    {
        TD_Attacker newAttacker = Instantiate
            (myAttacker, transform.position, transform.rotation)
            as TD_Attacker;
        newAttacker.transform.parent = transform;
    }
}
