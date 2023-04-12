using Unity.VisualScripting;
using UnityEngine.UIElements;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class AmmoBox : MonoBehaviour
{
    private float posX;
    private float posY;
    private float posZ;
    private float newPosY;
    private float rotaY;
    private bool Up;
    AudioSource source;
    void Start()
    {
        posX = transform.position.x;
        posY = transform.position.y;
        posZ = transform.position.z;
        rotaY = 0;

        source = GetComponent<AudioSource>();
        //newPosY = posY + 1;
    }

    void Update()
    {
        newPosY = transform.position.y;

        if (newPosY <= posY )
        {
            Up = true;
        }
        else if (newPosY >= posY+2)
        {
            Up = false;
        }

        rotaY += 0.5f;
        transform.rotation = Quaternion.Euler( 0, rotaY, 0 );
        Move();

    }

    private void Move()
    {
        if(Up)
        {
            transform.position = new Vector3(posX, newPosY+0.005f, posZ);
        }
        else
        {
            transform.position = new Vector3(posX, newPosY - 0.005f, posZ);
        }
    }

    private void Rotated()
    {
        if (rotaY <= -360)
        {
            rotaY = 0;
        }
    }


    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            source.Play();
            //Destroy(gameObject);
        }
    }

}
