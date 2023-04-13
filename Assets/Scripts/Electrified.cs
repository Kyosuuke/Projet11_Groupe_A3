using UnityEngine;

public class Electrified : MonoBehaviour
{
    public Material Mat;

    public SkinnedMeshRenderer _player;

    private void Start() 
    {
        _player = GetComponentInChildren<SkinnedMeshRenderer>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player")
        {
           _player.material = Mat;
        }

        if (other.gameObject.tag == "Enemy")
        {
            
        }
    }
}
