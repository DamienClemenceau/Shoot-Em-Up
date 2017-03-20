using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float structurePoint;

    public void TakeDamage(int amount)
    {
        structurePoint -= amount;
        if(structurePoint <= 0)
        {
            Destroy(gameObject);
        }
    }
}
