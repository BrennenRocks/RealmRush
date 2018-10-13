using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    [SerializeField]
    private Collider collisionMesh;

    [SerializeField]
    private int health = 10;

	// Use this for initialization
	void Start () {
		
	}

    private void OnParticleCollision(GameObject other) {
        ProcessHit();
    }

    private void ProcessHit() {
        health -= 1;
        if (health <= 0) {
            Death();
        }
    }

    private void Death() {
        Destroy(gameObject);
    }
}
