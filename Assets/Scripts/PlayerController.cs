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

public class PlayerController : Entity
{
    public ShipInfo shipInfo;
    public GameObject bullet;
    public float fireRate;
    private float primaryFireCooldown;
    private Vector2 velocity;

    void FixedUpdate() 
    {
        float xAxis = Input.GetAxisRaw("Yaw"); // TODO : Need to change Input Settings
        float yAxis = Input.GetAxisRaw("Vertical");
        float yaw = Input.GetAxisRaw("Horizontal");

        velocity.x = xAxis * shipInfo.lateralSpeed;
        velocity.y = yAxis * (Mathf.Sign(yAxis) == 1 ? shipInfo.thrustSpeed : shipInfo.reverseSpeed);

        transform.Rotate(Vector3.forward, yaw * shipInfo.yawSpeed);
        transform.Translate(velocity * Time.deltaTime);	

        if(Input.GetKey(KeyCode.Space) && primaryFireCooldown < Time.time)
        {
            primaryFireCooldown = Time.time + fireRate;
            foreach (GameObject primary in shipInfo.primaryWeapon) 
            {
                GameObject goBullet = Instantiate(bullet, primary.transform.position, primary.transform.rotation);
                goBullet.GetComponent<SimpleBullet>().creator = gameObject;
            }
        }
	}
}
