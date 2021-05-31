using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BackgroundCollider : MonoBehaviour
{
    [Header("Lose panel")]
    [SerializeField] private GameObject endPanel;
           
    private void Start()
    {
        // Sets game time scale at begining
        Time.timeScale = 0;
    }
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // When character collides with the collider the game is finished
        endPanel.SetActive(true);       
        Time.timeScale = 0;
    }
}
