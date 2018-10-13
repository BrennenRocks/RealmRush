using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    [SerializeField]
    private Transform objectToPan, targetEnemy;

    [SerializeField]
    private int range = 30;

    [SerializeField]
    private ParticleSystem ptcProjectile;
	
	void Update () {
        if (targetEnemy) {
            objectToPan.LookAt(targetEnemy);
            FireAtEnemy();
        } else {
            Shoot(false);
        }
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
