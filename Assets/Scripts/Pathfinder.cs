using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

    [SerializeField]
    private Waypoint startWaypoint, endWaypoint;

    private Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    private Queue<Waypoint> queue = new Queue<Waypoint>();
    private List<Waypoint> path = new List<Waypoint>();

    private Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    public List<Waypoint> GetPath() {
        if (path.Count == 0) {
            LoadBlocks();
            BreadthFirstSearch();
        }

        return path;
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

    private void BreadthFirstSearch() {
        List<Waypoint> seen = new List<Waypoint>();
        queue.Enqueue(startWaypoint);

        while (queue.Count > 0) {
            Waypoint curr = queue.Dequeue();
            seen.Add(curr);
            if (curr == endWaypoint) {
                CreateSolution(curr);
                break;
            }

            foreach(Vector2Int direction in directions) {
                if (grid.ContainsKey(curr.GetGridPos() + direction)) {
                    Waypoint neighbor = grid[curr.GetGridPos() + direction];

                    if (!seen.Contains(neighbor) && !queue.Contains(neighbor)) {
                        neighbor.parent = curr;
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }
    }

    private void CreateSolution(Waypoint current) {
        while (current != null) {
            path.Add(current);
            current.isPlaceable = false;
            current = current.parent;
        }

        path.Reverse();
    }
}
