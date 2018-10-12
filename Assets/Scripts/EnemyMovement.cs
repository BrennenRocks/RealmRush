using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField]
    private List<Waypoint> path;

	// Use this for initialization
	void Start () {
        StartCoroutine(FollowPath());
    }

    private IEnumerator FollowPath() {
        print("Starting patrol...");
        foreach (Waypoint waypoint in path) {
            transform.position = waypoint.transform.position;
            print("Visiting: " + waypoint.name);
            yield return new WaitForSeconds(1f);
        }
        print("ending");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
