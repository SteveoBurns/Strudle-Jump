using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public string strudelName;
    [SerializeField] private TMP_InputField nameInput;

    [SerializeField] private Transform character;

    public float score;
    [SerializeField] private TMP_Text scoreText;

    public static List<HighScore> highScores = new List<HighScore>();
    public HighScore theScore;

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

        strudelName = nameInput.text;
    }

    public void SetHighScore()
    {
        theScore.name = strudelName;
        theScore.score = score;


        highScores.Add(theScore);
    }
}
