using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public List<HighScore> highScores = new List<HighScore>();

    public GameData(List<HighScore> _highscores)
    {
        highScores = _highscores;
    }

    public void Sort()
    {
        highScores = highScores.OrderBy(_score => _score.score).ToList();
    }
}
