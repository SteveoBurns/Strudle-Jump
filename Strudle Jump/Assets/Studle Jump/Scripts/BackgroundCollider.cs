using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCollider : MonoBehaviour
{
    [SerializeField] private GameObject endPanel;

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        endPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
