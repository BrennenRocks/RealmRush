using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    [SerializeField] private Collider collisionMesh;

    [SerializeField] private ParticleSystem pfbHitParticle;
    [SerializeField] private ParticleSystem pfbDeathParticle;

    [SerializeField] private int health = 10;

    [SerializeField] private AudioClip sfxEnemyHit;

    AudioSource audioSource;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnParticleCollision(GameObject other) {
        ProcessHit();
    }

    private void ProcessHit() {
        health -= 1;
        pfbHitParticle.Play();
        audioSource.PlayOneShot(sfxEnemyHit);
        if (health <= 0) {
            Death();
        }
    }

    private void Death() {
        ParticleSystem vfx = Instantiate(pfbDeathParticle, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(vfx.gameObject, vfx.main.duration);

        Destroy(gameObject);
    }
}
