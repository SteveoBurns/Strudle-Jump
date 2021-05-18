using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private Transform character;

    private float score;
    [SerializeField] private TMP_Text scoreText;

    private void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (character != null)
        {
            if (character.position.y > score)
            {
                score = character.position.y;
            }
        }


        scoreText.text = "Score:" + Mathf.RoundToInt(score).ToString();
    }
}
