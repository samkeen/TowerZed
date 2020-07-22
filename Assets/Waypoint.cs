using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    
    const int GridSize = 10;
    private Vector2Int _gridPos;
    public bool isExplored = false;
    public Waypoint exploredFrom;

    public int GetGridSize()
    {
        return GridSize;
    }
    /// <summary>
    /// x,y position for this waypoint
    /// </summary>
    /// <returns>void</returns>
    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / GridSize),
            Mathf.RoundToInt(transform.position.z / GridSize)
        );
    }    

    public void SetColor(Color color)
    {
        var transformName = "Top";
        var topTransform = transform.Find(transformName);
        if (topTransform is null)
        {
            Debug.LogError($"Unable to find Transform of name: {transformName}");
        }
        else
        {
            topTransform.GetComponent<MeshRenderer>().material.color = color;
        }
    }

    public void setExplored(Waypoint exploredFrom)
    {
        this.exploredFrom = exploredFrom;
        SetColor(Color.magenta);
    }
}
