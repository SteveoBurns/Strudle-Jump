using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("The Character to follow")]
    public Transform target;


    // Update is called once per frame
    void LateUpdate()
    {
        if (target != null)
        {
            // Moving the camera, but only upwards. Don't want it to keep dropping with the character.
            if (target.position.y > transform.position.y)
            {

                Vector3 newPos = new Vector3(transform.position.x, target.position.y, transform.position.z);
                transform.position = newPos;

            }

        }

    }
}
