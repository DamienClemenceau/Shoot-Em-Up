using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : MonoBehaviour {
    public float speed;
    public float lifeTime;
    [HideInInspector]
    public GameObject creator;

    void Awake()
    {
        Destroy(gameObject, lifeTime);
    }

	void FixedUpdate () 
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject != creator)
        {
            Destroy(gameObject);
        }
    }
}
