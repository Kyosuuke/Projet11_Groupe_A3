using UnityEngine;
using System.Collections;


public class Electrified : MonoBehaviour
{
    public Player _player;
    public MeshRenderer _enemy;

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _player._life -= 5;
        }
    }
}

