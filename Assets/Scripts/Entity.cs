using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float structurePoint;
    private Color damageColor = new Color(1, 1, 1, 0.2f);
    private float blinkLength = 0.05f;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(int amount)
    {
        structurePoint -= amount;
        if(structurePoint <= 0)
        {
            Destroy(gameObject);
        }
        StartCoroutine(DamageColorSwap());
    }

    private IEnumerator DamageColorSwap()
    {
        spriteRenderer.color = damageColor;
        yield return new WaitForSeconds(blinkLength);
        spriteRenderer.color = Color.white;
    }
}
