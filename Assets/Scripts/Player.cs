using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject _shield;
    [SerializeField] GameObject _projectileToSpawn;
    [SerializeField] Transform _projectileSpawnLocation;

    public Material mat;
    public int _life = 100;
    public int _maxLife = 100;

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
            _shield.SetActive(!_shield.activeSelf);
    }

    public void UpdateLife(int valueToAdd)
    {
        // clamp the life between 0 and MaxLife;
        // if life == 0
        //    Visual effect + disable the movements of the player, etc etc...
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Enemy")
        {
            StartCoroutine(TakeDamage());
        }

        if (other.gameObject.tag == "Heal")
        {
            StartCoroutine(Heal());
        }
    }

    IEnumerator TakeDamage()
    {
        mat.color = Color.red;
        mat.SetFloat("_FullscreenIntensity", 0.3f);
        yield return new WaitForSeconds(1f);
        mat.SetFloat("_FullscreenIntensity", 0f);

        if (_life <= 30)
        {
            mat.color = Color.red;
            mat.SetFloat("_FullscreenIntensity", 0.3f);
        }
        else
        {
            mat.SetFloat("_FullscreenIntensity", 0.0f);
        }
    }

    IEnumerator Heal()
    {
        mat.color = Color.green;
        mat.SetFloat("_FullscreenIntensity", 0.3f);
        yield return new WaitForSeconds(1f);
        mat.SetFloat("_FullscreenIntensity", 0f);
    }
}
