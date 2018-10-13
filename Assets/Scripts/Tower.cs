using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    [SerializeField]
    private Transform objectToPan;

    [SerializeField]
    private int range = 30;

    [SerializeField]
    private ParticleSystem ptcProjectile;

    private Transform targetEnemy;
    public Waypoint waypoint;

    void Update () {
        SetTargetEnemy();
        if (targetEnemy) {
            objectToPan.LookAt(targetEnemy);
            FireAtEnemy();
        } else {
            Shoot(false);
        }
	}

    private void SetTargetEnemy() {
        EnemyDamage[] enemies = FindObjectsOfType<EnemyDamage>();
        if (enemies.Length == 0) {
            return;
        }

        Transform closestEnemy = enemies[0].transform;
        foreach (EnemyDamage enemy in enemies) {
            closestEnemy = GetClosestEnemy(closestEnemy, enemy.transform);
        }

        targetEnemy = closestEnemy;
    }

    private Transform GetClosestEnemy(Transform a, Transform b) {
        float distToA = Vector3.Distance(transform.position, a.position);
        float distToB = Vector3.Distance(transform.position, b.position);

        return distToA < distToB ? a : b;
    }

    private void FireAtEnemy() {
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
        if (distanceToEnemy <= range) {
            Shoot(true);
        } else {
            Shoot(false);
        }
    }

    private void Shoot(bool active) {
        ParticleSystem.EmissionModule emissionModule = ptcProjectile.emission;
        emissionModule.enabled = active;
    }
}
