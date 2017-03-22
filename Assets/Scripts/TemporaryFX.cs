using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryFX : MonoBehaviour {
    public float flashTime;
	void Start () {
		Destroy(gameObject, flashTime);
	}

}
