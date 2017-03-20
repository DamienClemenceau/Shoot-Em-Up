using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : MonoBehaviour {
    public float speed;
    [HideInInspector]
    public GameObject creator;

	void Update () 
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject != creator)
        {
            Destroy(collider.gameObject);
            Destroy(gameObject);
        }
    }
}
