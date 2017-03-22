using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {
    private float depth = -10;
    public float lerpTime;
    private PlayerController player;

    void Start ()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
	}
	
	void FixedUpdate()
    {
	    if(player != null)
        {
            Vector3 target = player.transform.position + player.velocity * 0.5f;
            target.z = depth;

            transform.position = Vector3.Lerp
            (
                transform.position,
                target,
                lerpTime * Time.deltaTime
            );
        }

        Debug.DrawLine(transform.position + Vector3.up, transform.position + Vector3.down);
        Debug.DrawLine(transform.position + Vector3.right, transform.position + Vector3.left);
	}
}
