using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [Header("Character")]
    public string strudelName;
    [SerializeField] private TMP_InputField nameInput;
    [SerializeField] private Transform character;

    [Header("Score")]
    public float score;
    [SerializeField] private TMP_Text scoreText;

    public static List<HighScore> highScores = new List<HighScore>();
    public HighScore theScore;

    private void Start()
    {
        // Sets score
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (character != null)
        {
            // Sets the score to be the highest the character has been
            if (character.position.y > score)
            {
                score = character.position.y;
            }
        }

        // Updates score text
        scoreText.text = "Score:" + Mathf.RoundToInt(score).ToString();

        // Sets the name.
        strudelName = nameInput.text;
    }

    /// <summary>
    /// Sets the score and adds it to the list of highscores
    /// </summary>
    public void SetHighScore()
    {
        theScore.name = strudelName;
        theScore.score = score;


        highScores.Add(theScore);
    }
}
