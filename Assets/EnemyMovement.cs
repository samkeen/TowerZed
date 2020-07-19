using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private List<Waypoint> path;
    [SerializeField] private float dwellTime = 1;
    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        print("Starting patrol");
        foreach (Waypoint waypoint in path)
        {
            print($"Visiting {waypoint.name}");
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(dwellTime);
        }
        print("Ending partol");
    }
    
}
