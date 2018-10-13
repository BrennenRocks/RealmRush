using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [Range(0.5f, 30f)]
    [SerializeField]
    private float secondsBetweenSpawn = 2f;

    [SerializeField]
    private int numberToSpawn = 5;

    [SerializeField]
    private Transform enemyParentTransform;

    [SerializeField]
    private EnemyMovement pfbEnemy;

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnEnemies());
	}

    private IEnumerator SpawnEnemies() {
        for (int i = 0; i < numberToSpawn; i++) {
            EnemyMovement newEnemy = Instantiate(pfbEnemy, transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyParentTransform;
            yield return new WaitForSeconds(secondsBetweenSpawn);
        }
    }
}
