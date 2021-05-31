using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HighScore
{
    // Highscore class for use when saving the scores with binary and then outputting to a leaderboard.
    public float score;
    public string name;

    public HighScore(Score _score)
    {
        score = _score.score;
        name = _score.name;
    }
}
