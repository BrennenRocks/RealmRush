using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

    private const int gridSize = 10;
    private Vector2Int gridPos;
    private TowerFactory towerFactory;

    public Waypoint parent;
    public bool isPlaceable = true;

    public int GetGridSize() {
        return gridSize;
    }

    private void Start() {
        towerFactory = FindObjectOfType<TowerFactory>();
    }

    public Vector2Int GetGridPos() {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize), 
            Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }

    private void OnMouseOver() {
        if (Input.GetMouseButton(0) && isPlaceable) {
            towerFactory.AddTower(this);
        }
    }
}
