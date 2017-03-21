using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : MonoBehaviour {
    public float speed;
    public float lifeTime;
    [HideInInspector]
    public GameObject creator;
    public int damage;
    public float deviation;
    public GameObject impactFX;

    void Awake()
    {
        Destroy(gameObject, lifeTime);
    }

    void Start()
    {
        transform.Rotate(0, 0, Random.Range(-deviation, deviation));
    }

	void FixedUpdate () 
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.gameObject != creator)
        {
            
            if (collider.gameObject.layer == LayerMask.NameToLayer("Entity"))
            {
                collider.GetComponent<Entity>().TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        Instantiate(impactFX, transform.position, transform.rotation);
    }
}
