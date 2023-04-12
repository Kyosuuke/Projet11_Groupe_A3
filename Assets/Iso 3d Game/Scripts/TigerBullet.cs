using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TigerBullet : MonoBehaviour
{
    public Camera cam;
    public GameObject projectiles;
    public Transform firePoint;
    public float fireRate = 4;

    private Vector3 destination;
    private float timeToFire;
    private TigerAttack tigerAttackScript;


    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= timeToFire)
        {
            timeToFire = Time.time + 1/fireRate;
            InstantiateProjectileAtFirePoint();
        }
    }

    void InstantiateProjectileAtFirePoint()
    {
        var projectileObj = Instantiate(projectiles, firePoint.position, Quaternion.identity) as GameObject;

        tigerAttackScript = projectileObj.GetComponent<TigerAttack>();
        rotateToDestination(projectileObj, firePoint.transform.forward * 1000, true);
        projectileObj.GetComponent<Rigidbody>().velocity = transform.forward * tigerAttackScript.speed;
    }

    void rotateToDestination(GameObject obj, Vector3 destination, bool onlyY)
    {
        var direction = destination - obj.transform.position;
        var rotation = Quaternion.LookRotation(direction);

        if(onlyY)
        {
            rotation.x = 0;
            rotation.z = 0;
        }

        obj.transform.localRotation = Quaternion.Lerp(obj.transform.rotation, rotation, 1);
    }
}
