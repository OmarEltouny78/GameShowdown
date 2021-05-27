using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletshot : MonoBehaviour
{
    public float projSpeed = 12.0f;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Fire();
        }
    }
    void Fire()
    {
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Bullet>().bulletSpeed = projSpeed;
        Destroy(bullet, 5.0f);
    }
}
