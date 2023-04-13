using System.ComponentModel;
using UnityEngine;

public class mapLimiter : MonoBehaviour
{
    public float right;
    public float left;
    public float up;
    public float down;
    public GameObject player;

    private float posX;
    private float posY;
    private float posZ;
    private float rePosition = 1;

    // Update is called once per frame
    void Update()
    {
        posX = player.transform.position.x;
        posY = player.transform.position.y;
        posZ = player.transform.position.z;

        if (posZ < right)
        {
            player.transform.position = new Vector3(posX, posY, posZ + rePosition);
            Debug.Log("Limite a droite atteinte");
        }
        if (posZ > left)
        {
            player.transform.position = new Vector3(posX, posY, posZ - rePosition);
            Debug.Log("Limite a gauche atteinte");
        }
        if (posX > up)
        {
            player.transform.position = new Vector3(posX - rePosition, posY, posZ);
            Debug.Log("Limite en haut atteinte");
        }
        if (posX < down)
        {
            player.transform.position = new Vector3(posX + rePosition, posY, posZ);
            Debug.Log("Limite en bas atteinte");
        }
    }
}
