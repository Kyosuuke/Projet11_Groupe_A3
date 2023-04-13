using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Buff : MonoBehaviour
{
    public float hastePercent = 0.5f;
    public float lenght = 3f;
    public Material[] matsBuff;
    public Material[] matsDebuff;

    private float cooldown = 0f;
    private float fr;
    private Material[] matsPlayer;

    private void Start()
    {
        fr = gameObject.GetComponent<TigerBullet>().fireRate;
        matsPlayer = GetComponentInChildren<SkinnedMeshRenderer>().materials;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && Time.time > cooldown)
        { 
            fr = gameObject.GetComponent<TigerBullet>().fireRate;
            gameObject.GetComponent<TigerBullet>().fireRate += fr * hastePercent;
            cooldown = Time.time + lenght;
            GetComponentInChildren<SkinnedMeshRenderer>().materials = matsBuff;
        }
        if (Input.GetKeyDown(KeyCode.V) && Time.time > cooldown)
        {
            fr = gameObject.GetComponent<TigerBullet>().fireRate;
            gameObject.GetComponent<TigerBullet>().fireRate = fr * hastePercent;
            cooldown = Time.time + lenght;
            GetComponentInChildren<SkinnedMeshRenderer>().materials = matsDebuff;
        }
        if (Time.time > cooldown)
        {
            gameObject.GetComponent<TigerBullet>().fireRate = fr;
            GetComponentInChildren<SkinnedMeshRenderer>().materials = matsPlayer;
        }
    }
}
