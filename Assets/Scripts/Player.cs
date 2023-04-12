using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject _shield;
    [SerializeField] GameObject _projectileToSpawn;
    [SerializeField] Transform _projectileSpawnLocation;

    private int _life = 100;
    private int _maxLife = 100;


    void Update()
    {
        Shader.SetGlobalVector("_WorldSpacePlayerPos", transform.position);

        // Projectile
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            GameObject clone = Instantiate(_projectileToSpawn, _projectileSpawnLocation.transform.position, Quaternion.identity);
            clone.transform.forward = transform.forward;
        }

        // Shield
        if (Input.GetKeyDown(KeyCode.E))
        {
            _shield.SetActive(!_shield.activeSelf);
            //isActive = true;
        }

        _shield.transform.position = gameObject.transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemies")
        {
            UpdateLife(-10);
        }
    }
    public void UpdateLife(int valueToAdd)
    {
        _life = Mathf.Clamp(_life + valueToAdd, 0, 100);
        Debug.Log(_life);
        if (_life == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        // clamp the life between 0 and MaxLife;
        // if life == 0
        //    Visual effect + disable the movements of the player, etc etc...
    }
}
