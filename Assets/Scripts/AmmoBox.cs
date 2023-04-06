using Unity.VisualScripting;
using UnityEngine.UIElements;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    private float posX;
    private float posY;
    private float newPosY;
    private float rotaY;
    private bool Up;
    void Start()
    {
        posX = transform.position.x;
        posY = transform.position.y;
        rotaY = 0;
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
            transform.position = new Vector2(posX, newPosY+0.005f);
        }
        else
        {
            transform.position = new Vector2(posX, newPosY - 0.005f);
        }
    }

    private void Rotated()
    {
        if (rotaY <= -360)
        {
            rotaY = 0;
        }
    }
}
