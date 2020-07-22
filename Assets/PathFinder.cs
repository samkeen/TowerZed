using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> _queue = new Queue<Waypoint>();

    [SerializeField] private Waypoint startWaypoint, endWaypoint;
    private bool _endFound = false;
    private Waypoint _searchCenter;
    private List<Waypoint> _path = new List<Waypoint>();

    private Vector2Int[] _directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left,
    };

    public List<Waypoint> GetPath()
    {
        LoadBlocks();
        ColorStartAndEnd();
        BreadthFirstSearch();
        CreatePath();
        return _path;
    }

    private void CreatePath()
    {
        _path.Add(endWaypoint);
        Waypoint previous = endWaypoint.exploredFrom;
        while (previous != startWaypoint)
        {
            _path.Add(previous);
            // set the next previous waypoint
            previous = previous.exploredFrom;
        }

        _path.Reverse();
    }

    private void BreadthFirstSearch()
    {
        _queue.Enqueue(startWaypoint);
        while (_queue.Count > 0 && !_endFound)
        {
            _searchCenter = _queue.Dequeue();
            _searchCenter.isExplored = true;
            HaltIfEndFound();
            ExploreNeighbors();
        }
    }

    private void HaltIfEndFound()
    {
        if (_searchCenter == endWaypoint)
        {
            print($"Found end waypoint {_searchCenter}");
            _endFound = true;
        }
    }

    private void ExploreNeighbors()
    {
        if (_endFound)
        {
            return;
        }

        foreach (var direction in _directions)
        {
            Vector2Int neighborCoordinates = _searchCenter.GetGridPos() + direction;
            print($"Exploring {neighborCoordinates}");
            if (grid.ContainsKey(neighborCoordinates))
            {
                QueueNewNeighbor(neighborCoordinates);
            }
            else
            {
                print($"Position {neighborCoordinates} not on grid");
            }
        }
    }

    private void QueueNewNeighbor(Vector2Int neighborCoordinates)
    {
        // look up waypoint in or grid matrix
        Waypoint neighbor = grid[neighborCoordinates];
        if (!neighbor.isExplored || _queue.Contains(neighbor))
        {
            _queue.Enqueue(neighbor);
            print($"queueing neighbor: {neighbor}");
            neighbor.setExplored(_searchCenter);
        }
        else
        {
            print($"{neighbor} already explored");
        }
    }

    private void ColorStartAndEnd()
    {
        startWaypoint.SetColor(Color.green);
        endWaypoint.SetColor(Color.red);
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (var waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();
            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning($"Not loading overlapping waypoint at {waypoint}");
            }
            else
            {
                grid.Add(gridPos, waypoint);
            }
        }
    }
}