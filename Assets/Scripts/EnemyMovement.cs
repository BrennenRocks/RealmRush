﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        List<Waypoint> path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    private IEnumerator FollowPath(List<Waypoint> path) {
        foreach (Waypoint waypoint in path) {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(2f);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
