using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BackgroundCollider : MonoBehaviour
{
    [SerializeField] private GameObject endPanel;
    
    
    
    private void Start()
    {
        Time.timeScale = 0;
    }

   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        endPanel.SetActive(true);       
        Time.timeScale = 0;
    }
}
