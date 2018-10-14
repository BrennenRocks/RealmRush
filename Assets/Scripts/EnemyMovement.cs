using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField]
    private float movementSpeed = .5f;

    [SerializeField]
    private ParticleSystem pfbGoalParticle;

    private PlayerHealth playerHealth;

    // Use this for initialization
    void Start () {
        playerHealth = FindObjectOfType<PlayerHealth>();
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        List<Waypoint> path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    private IEnumerator FollowPath(List<Waypoint> path) {
        foreach (Waypoint waypoint in path) {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(movementSpeed);
        }
        Death();
    }

    private void Death() {
        ParticleSystem vfx = Instantiate(pfbGoalParticle, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(vfx.gameObject, vfx.main.duration);

        Destroy(gameObject);
        playerHealth.BaseHit();
    }
}
