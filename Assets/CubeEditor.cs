using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
/*
 * when clicking on elements of the cube, default to selection of entire cube (were this
 * script is attached)
 */
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    private Waypoint _waypoint;

    private void Awake()
    {
        _waypoint = GetComponent<Waypoint>();
    }

    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        var gridSize = _waypoint.GetGridSize();
        transform.position = new Vector3(
            _waypoint.GetGridPos().x,
            0f,
            // the Vector2Int returned uses x,y so we use y for z here.
            _waypoint.GetGridPos().y
        );;
    }

    private void UpdateLabel()
    {
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        var gridSize = _waypoint.GetGridSize();
        var cubeLabel = $"{_waypoint.GetGridPos().x / gridSize},{_waypoint.GetGridPos().y / gridSize}";
        textMesh.text = cubeLabel;
        gameObject.name = cubeLabel;
    }
}