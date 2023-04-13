using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject _shield;
    [SerializeField] Transform _projectileSpawnLocation;
    public Material[] mats;
    public Material[] matsBuff;
    public Material[] matsDebuff;
    public float hastePercent = 0.5f;
    public float lenght = 3f;
    private float cooldown = 0f;
    private float fr;
    public float _Time = -1;
    [SerializeField] GameObject _armatureMesh;
    [SerializeField] Material[] oldMats;
    public Material mat;
    public int _life = 100;
    public int _maxLife = 100;


    private void Start()
    {
        _Time = 0.5f;
        fr = gameObject.GetComponent<TigerBullet>().fireRate;
        _armatureMesh.GetComponent<SkinnedMeshRenderer>().materials = mats;
    }

    async void Update()
    {
        // Buff & Debuff
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

        if (_Time > -1 && _life > 0)
        {
            _Time -= Time.deltaTime;
            GetComponent<ThirdPersonController>().enabled = false;
        }
        else if (_Time <= -1 && _life > 0 && Time.time > cooldown)
        {
            gameObject.GetComponent<TigerBullet>().fireRate = fr;
            _armatureMesh.GetComponent<SkinnedMeshRenderer>().materials = oldMats;
            GetComponent<ThirdPersonController>().enabled = true;
        }
        Shader.SetGlobalVector("_WorldSpacePlayerPos", transform.position);

        // Shield
        if (Input.GetKeyDown(KeyCode.E))
        {
            _shield.SetActive(!_shield.activeSelf);
            //isActive = true;
        }

        _shield.transform.position = gameObject.transform.position;
        if (_life == 0 && _Time < 0.5)
        {
            _Time += Time.deltaTime;
            GetComponent<Animator>().enabled = false;
            GetComponent<ThirdPersonController>().enabled = false;
        }
        else if (_life == 0 && _Time >= 0.5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        foreach (Material mat in _armatureMesh.GetComponent<SkinnedMeshRenderer>().materials)
        {
            mat.SetFloat("_TimeFloat", _Time);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemies")
        {
            UpdateLife(-10);
            StartCoroutine(TakeDamage());

            if (other.gameObject.tag == "Heal")
            {
                StartCoroutine(Heal());
            }
        }
    }
    public void UpdateLife(int valueToAdd)
    {
        _life = Mathf.Clamp(_life + valueToAdd, 0, 100);
        Debug.Log(_life);
        if (_life == 0)
        {
            _armatureMesh.GetComponent<SkinnedMeshRenderer>().materials = mats;
            _Time = -1;
        }
        // clamp the life between 0 and MaxLife;
        // if life == 0
        //    Visual effect + disable the movements of the player, etc etc...
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
            mat.SetFloat("_FullscreenIntensity", 0.5f);
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
