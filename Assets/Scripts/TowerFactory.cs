using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

    [SerializeField]
    private Tower pfbTower;

    [SerializeField]
    private int limit = 5;

    [SerializeField]
    private Transform towerParentTransform;

    private Queue<Tower> towers = new Queue<Tower>();

    public void AddTower(Waypoint waypoint) {
        if (towers.Count < limit) {
            Tower newTower = Instantiate(pfbTower, waypoint.transform.position, Quaternion.identity);
            newTower.transform.parent = towerParentTransform;
            newTower.waypoint = waypoint;
            waypoint.isPlaceable = false;
            towers.Enqueue(newTower);
        } else {
            Tower oldTower = towers.Dequeue();
            oldTower.waypoint.isPlaceable = true;
            oldTower.waypoint = waypoint;
            oldTower.transform.position = waypoint.transform.position;
            waypoint.isPlaceable = false;
            towers.Enqueue(oldTower);
        }
    }
}
