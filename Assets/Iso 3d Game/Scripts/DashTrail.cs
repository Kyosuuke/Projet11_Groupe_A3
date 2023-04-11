using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class DashTrail : MonoBehaviour
{
    public float activeTime = 0.05f;
    public float meshRefreshRate = 0.01f;
    public float meshDestroyDelay = 0.5f;
    public Transform positionToSpawn;
    public Material[] mats;
    private bool isTrailActive;
    private SkinnedMeshRenderer skinnedMeshRenderers;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && !isTrailActive)
        {
            StartCoroutine(ActivateTrail(activeTime));
        }
    }

    IEnumerator ActivateTrail(float time)
    {
        float actualMoveSpeed = gameObject.GetComponent<ThirdPersonController>().MoveSpeed;
        float actualSprintSpeed = gameObject.GetComponent<ThirdPersonController>().SprintSpeed;
        gameObject.GetComponent<ThirdPersonController>().SpeedChangeRate = 1000;
        gameObject.GetComponent<ThirdPersonController>().MoveSpeed = 50;
        gameObject.GetComponent<ThirdPersonController>().SprintSpeed = 50;
        /*gameObject.GetComponent<StarterAssetsInputs>().move.x;
        gameObject.transform.position.x*/
        while (time > 0)
        {
            time -= meshRefreshRate;
            if (skinnedMeshRenderers == null )
                skinnedMeshRenderers = GetComponentInChildren<SkinnedMeshRenderer>();

            GameObject gObj = new GameObject();
            gObj.transform.SetPositionAndRotation(positionToSpawn.position, positionToSpawn.rotation);

            MeshRenderer mr = gObj.AddComponent<MeshRenderer>();
            MeshFilter mf = gObj.AddComponent<MeshFilter>();

            Mesh mesh = new Mesh();
            skinnedMeshRenderers.BakeMesh(mesh);

            mf.mesh = mesh;
            mr.materials = mats;
                

            Destroy(gObj, meshDestroyDelay);

            yield return new WaitForSeconds(meshRefreshRate);
        }

        
        gameObject.GetComponent<ThirdPersonController>().MoveSpeed = actualMoveSpeed;
        gameObject.GetComponent<ThirdPersonController>().SprintSpeed = actualSprintSpeed;
        /*TimeSpan ts = TimeSpan.FromMilliseconds(1000);
        Task.Run(() => { gameObject.GetComponent<ThirdPersonController>().SpeedChangeRate = 10; }).Wait(ts);*/


    }
}
