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
        }
        if (other.gameObject.name == "Quad1")
        {
            Debug.Log("je suis la bas");
            gameObject.transform.position = Teleportation.transform.position;
        }
    }
}
