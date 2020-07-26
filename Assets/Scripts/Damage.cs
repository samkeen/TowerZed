using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private int hitPoints = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints<=0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        Destroy(gameObject);
    }

    void ProcessHit()
    {
        hitPoints -= 1;
    }
}
