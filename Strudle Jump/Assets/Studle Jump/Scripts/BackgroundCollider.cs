using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
    }
}
