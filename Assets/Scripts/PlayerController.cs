using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ShipInfo
{
    public float lateralSpeed, thrustSpeed, reverseSpeed;
    public float yawSpeed;
    public float structurePoint, shipMass;
    public List<GameObject> primaryWeapon, secondaryWeapon;
}

public class PlayerController : MonoBehaviour {
    public ShipInfo shipInfo;
    public GameObject bullet;
    private Vector2 velocity;

	void Update () 
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");
        float yaw = Input.GetAxisRaw("Yaw");

        velocity.x = xAxis * shipInfo.lateralSpeed;
        velocity.y = yAxis * shipInfo.thrustSpeed;

        transform.Rotate(Vector3.forward, yaw * shipInfo.yawSpeed);
        transform.Translate(velocity * Time.deltaTime);	

        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject goBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            goBullet.GetComponent<SimpleBullet>().creator = gameObject;
        }
	}
}
