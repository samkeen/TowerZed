using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Transform objectToPan;
    [SerializeField] private Transform targetEnemy;
    [SerializeField] private float attackRange = 10f;
    [SerializeField] private ParticleSystem projectileParticle;

    // Update is called once per frame
    void Update()
    {
        if (targetEnemy)
        {
            print($"enemy found: {targetEnemy},{objectToPan}");
            objectToPan.LookAt(targetEnemy);
            FireAtEnemy();
        }
        else
        {
            print($"No enemy found");
            Shoot(false);
        }

    }

    private void FireAtEnemy()
    {
        var distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
        var enemyInRange = distanceToEnemy <= attackRange;
        Shoot(enemyInRange);
    }

    private void Shoot(bool isActive)
    {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive;
    }
}