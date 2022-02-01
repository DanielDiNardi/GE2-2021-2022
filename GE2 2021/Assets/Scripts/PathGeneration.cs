using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGeneration : MonoBehaviour
{
    public int numberOfWaypoints = 4;
    public List<Vector3> waypoints = new List<Vector3>();
    public int current = 0;
    public bool isLooped = true;

    public void OnDrawGizmos(){
        // PopulateWaypoints();

        for(int i = 1; i < waypoints.Count; i++){
            Gizmos.DrawLine(waypoints[i - 1], waypoints[i]);
        }

        if(isLooped){
            Gizmos.DrawLine(waypoints[waypoints.Count - 1], waypoints[0]);
        }
    }

    public Vector3 Next(){
        return waypoints[current];
    }

    public bool IsLast(){
        return (current == waypoints.Count - 1 && isLooped);
    }

    public void AdvanceToNext(){
        if((! isLooped)){
            if(! IsLast()){
                current++;
            }
        }
        else{
            current = (current + 1) % waypoints.Count;
        }
    }

    // public void OnDrawGizmos(){
    //     Gizmos.color = Color.red;
    //     foreach(Vector3 point in waypoints){
    //         int index = waypoints.IndexOf(point);
    //         Gizmos.DrawWireSphere(point, 1);
    //         if(index == waypoints.Count - 1){
    //             Gizmos.DrawLine(waypoints[index], waypoints[0]);
    //         }
    //         else{
    //             Gizmos.DrawLine(waypoints[index], waypoints[index + 1]);
    //         }
    //     }
    // }

    public void Awake(){
        PopulateWaypoints();
    }

    public void PopulateWaypoints(){
        waypoints.Clear();
        for(int i = 0; i < numberOfWaypoints; i++){
            float x = Random.Range(-50f, 50f);
            float z = Random.Range(-50f, 50f);

            Vector3 position = new Vector3(x, 0.5f, z);
            waypoints.Add(position);
        }
    }
}
