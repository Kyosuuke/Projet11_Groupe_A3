using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public Player _player;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            if (_player._life > 100)
            {
                _player._life = 100;
            }
            else if (_player._life < 0)
            {
                _player._life = 0;
            }
            _player._life += 30;
            Destroy(gameObject);
        }
    }
}
