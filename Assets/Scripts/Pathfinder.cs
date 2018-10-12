using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

    [SerializeField]
    private Waypoint startWaypoint, endWaypoint;

    private Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    private Queue<Waypoint> queue = new Queue<Waypoint>();

    private Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

	// Use this for initialization
	void Start () {
        LoadBlocks();
        ColorStartAndEnd();
        Pathfind();
        //ExploreNeighbors();
	}


    // Update is called once per frame
    void Update () {
		
	}

    private void LoadBlocks() {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints) {
            if (!grid.ContainsKey(waypoint.GetGridPos())) {
                grid.Add(waypoint.GetGridPos(), waypoint);
            } else {
                Debug.LogWarning("Overlapping Block: " + waypoint);
            }
        }
    }

    private void ColorStartAndEnd() {
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.red);
    }

    private void ExploreNeighbors() {
        foreach (Vector2Int direction in directions) {
            Vector2Int neighbor = startWaypoint.GetGridPos() + direction;
            try {
                grid[neighbor].SetTopColor(Color.blue);
            } catch {
                // do nothing
            }
        }
    }

    private void Pathfind() {
        List<Waypoint> seen = new List<Waypoint>();
        queue.Enqueue(startWaypoint);

        while (queue.Count > 0) {
            Waypoint curr = queue.Dequeue();
            seen.Add(curr);
            print(curr);
            if (curr == endWaypoint) {
                // Get the path
                print("solution");
                break;
            }

            foreach(Vector2Int direction in directions) {
                Waypoint neighbor = null;
                try {
                    neighbor = grid[curr.GetGridPos() + direction];
                } catch {
                    // do nothing
                }

                if (neighbor != null) {
                    if (neighbor == endWaypoint) {
                        print("solution found in neighbor");
                        return;
                    }

                    if (!seen.Contains(neighbor) && !queue.Contains(neighbor)) {
                        neighbor.SetTopColor(Color.blue);
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }
    }
}
