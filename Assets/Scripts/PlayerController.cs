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
    public GameObject bullet, muzzleFlash;
    public float fireRate;
    private float primaryFireCooldown;
    private Vector3 velocity;
    private Vector2 currentVelocity;
    public float smoothTime;

    void FixedUpdate() 
    {
        Vector2 dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 yaw = new Vector2(Input.GetAxisRaw("HorizontalYaw"), Input.GetAxisRaw("VerticalYaw"));

        velocity.x = Mathf.SmoothDamp(velocity.x, dir.x * shipInfo.lateralSpeed, ref currentVelocity.x, smoothTime);
        velocity.y = Mathf.SmoothDamp(velocity.y, dir.y * (Mathf.Sign(dir.y) == 1 ? shipInfo.thrustSpeed : shipInfo.reverseSpeed), ref currentVelocity.y, smoothTime);
        
        transform.Rotate(Vector3.forward * (yaw.x * shipInfo.yawSpeed));
        transform.position += (velocity * Time.deltaTime);	

        if(Input.GetAxis("Fire1") > 0 && primaryFireCooldown < Time.time)
        {
            primaryFireCooldown = Time.time + fireRate;
            foreach (GameObject primary in shipInfo.primaryWeapon) 
            {
                GameObject goBullet = Instantiate(bullet, primary.transform.position, primary.transform.rotation);
                goBullet.GetComponent<SimpleBullet>().creator = gameObject;
                Instantiate(muzzleFlash, primary.transform.position, primary.transform.rotation, primary.transform);
            }
        }
	}
}
