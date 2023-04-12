using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationPortal : MonoBehaviour
{
    public GameObject Teleportation;
    public GameObject TeleportationTarget;

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Quad")
        {
            Debug.Log("je suis la");
            gameObject.transform.position = new Vector3(6, 6, 6);
            Debug.Log(gameObject);
        }
        if (other.gameObject.name == "Quad1")
        {
            Debug.Log("je suis la bas");
            gameObject.transform.position = Teleportation.transform.position;
        }
    }

    /*public GameObject projectiles;


    // Start is called before the first frame update
    void Start()
    {
        if (Input.GetButton("Fire1"))
        {
            ShootProjectile();
        }
    }

    private void ShootProjectile()
    {
        Instantiate(projectiles);
    }*/
}
