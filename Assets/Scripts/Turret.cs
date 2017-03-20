using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Entity {
    // TODO : Unify these data
    public float offset;
    private PlayerController player;

    public float fireRate;
    private float primaryFireCooldown;
    public GameObject bullet;
    public GameObject primaryWeapon;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        primaryFireCooldown = Time.time + fireRate;
    }
	
	void Update ()
    {
		if(player != null)
        {
            Vector3 diff = player.transform.position - transform.position;
            float tan = Mathf.Atan2(diff.y, diff.x);
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, tan * Mathf.Rad2Deg + offset);

            if (primaryFireCooldown < Time.time)
            {
                primaryFireCooldown = Time.time + fireRate;
                GameObject goBullet = Instantiate(bullet, primaryWeapon.transform.position, primaryWeapon.transform.rotation);
                goBullet.GetComponent<SimpleBullet>().creator = gameObject;
            }
        }
	}
}
