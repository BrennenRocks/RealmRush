using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField]
    private Text txtScore;

    [SerializeField]
    private AudioClip sfxSpawnedEnemy;

    private int score = 0;

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnEnemies());
        txtScore.text = score.ToString();
	}

    private IEnumerator SpawnEnemies() {
        for (int i = 0; i < numberToSpawn; i++) {
            score++;
            txtScore.text = score.ToString();

            GetComponent<AudioSource>().PlayOneShot(sfxSpawnedEnemy);

            EnemyMovement newEnemy = Instantiate(pfbEnemy, transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyParentTransform;
            yield return new WaitForSeconds(secondsBetweenSpawn);
        }
    }
}
