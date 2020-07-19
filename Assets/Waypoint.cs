using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    
    const int GridSize = 10;
    private Vector2Int _gridPos;

    public int GetGridSize()
    {
        return GridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / GridSize) * GridSize,
            Mathf.RoundToInt(transform.position.z / GridSize) * GridSize
        );
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
