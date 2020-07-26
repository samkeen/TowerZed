using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float secondsBetweenEnemy = 2f;
    [SerializeField] private EnemyMovement enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine(SpawnEnemy(), secondsBetweenEnemy);
    }

    private void SpawnEnemy()
    {
        print('x');
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
