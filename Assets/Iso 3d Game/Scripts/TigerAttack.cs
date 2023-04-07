using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerAttack : MonoBehaviour
{
    public float erodeRate = 0.03f;
    public float erodeRefreshRate = 0.01f;
    public float erodeDelay = 1.25f;
    public SkinnedMeshRenderer erodeObject;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ErodeObject());
    }

    IEnumerator ErodeObject()
    {
        yield return new WaitForSeconds(erodeDelay);

        float t = 0;
        while (t < 1)
        {
            t += erodeRate;
            erodeObject.material.SetFloat("_Slider", t);
            yield return new WaitForSeconds(erodeRefreshRate);
        }
    }
}
