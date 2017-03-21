using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {
    private float depth = -10;
    private PlayerController player;

    void Start ()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
	}
	
	void Update ()
    {
	    if(player != null)
        {
            transform.position = new Vector3
            (
                player.transform.position.x,
                player.transform.position.y,
                depth
            );
        }	
	}
}
