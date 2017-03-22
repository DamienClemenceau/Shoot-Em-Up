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
	
	void FixedUpdate ()
    {
	    if(player != null)
        {
            Vector3 target = player.transform.position + player.velocity.normalized * 2 ;
            target.z = depth;

            transform.position = Vector3.Lerp
            (
                transform.position,
                target,
                lerpTime * Time.deltaTime
            );
        }	
	}
}
