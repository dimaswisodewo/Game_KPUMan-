using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGround : MonoBehaviour
{

    private float timer = 4f;
    private float movingSpeed = 2f;
    private bool isDown = false;

    void FixedUpdate()
    {
        timer -= Time.deltaTime;
        if (isDown == false)
        {
            GroundMoveDown();
        }
        else
        {
            GroundMoveUp();
        }
        if (Mathf.Round(timer) <= 0)
        {
            if (isDown == false)
            {
                isDown = true;
            }
            else
            {
                isDown = false;
            }

            timer = 4f;
        }    
    }

    void GroundMoveUp()
    {
        transform.Translate(Vector3.up * movingSpeed * Time.deltaTime);
    }

    void GroundMoveDown()
    {
        transform.Translate(Vector3.down * movingSpeed * Time.deltaTime);
    }
}
