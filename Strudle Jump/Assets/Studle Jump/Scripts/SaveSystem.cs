using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using TMPro;


public class SaveSystem : MonoBehaviour
{
    private string FilePath => Application.streamingAssetsPath + "/gameData";
    private GameData gameData;
    private GameData loadedGameData;

    [SerializeField] private TMP_Text scorePrefab;
    [SerializeField] private Transform scoreContent;
    
   

    public void DisplayHighScore()
    {
        //null check this
        foreach (TMP_Text _highscore in scoreContent)
        {
            Destroy(_highscore);
        }
        foreach (HighScore _highscore in loadedGameData.highScores)
        {
            TMP_Text scoreText = Instantiate(scorePrefab, scoreContent);
            scoreText.text = _highscore.name + " - " + _highscore.score.ToString("0");
        }
    }


    private void Start()
    {
        if (!Directory.Exists(Application.streamingAssetsPath))
            Directory.CreateDirectory(Application.streamingAssetsPath);
    }

    public void SaveBinary()
    {
        gameData = new GameData(Score.highScores);

        // This Opens the river between RAM and the file
        using (FileStream stream = new FileStream(FilePath + ".save", FileMode.OpenOrCreate)) // using "using" closes the stream automatically.
        {
            // Like creating the boat that will carry the data from one point to another
            BinaryFormatter formatter = new BinaryFormatter();
            // Transports the data from the RAM to the specified file, like freezing water into ice, making it solid.
            formatter.Serialize(stream, gameData);
        }
    }

    public void LoadBinary()
    {

        if (!File.Exists(FilePath + ".save"))
            return;

        // This Opens the river between file and RAM
        using (FileStream stream = new FileStream(FilePath + ".save", FileMode.Open)) // using "using" closes the stream automatically.
        {
            // Like creating the boat that will carry the data from one point to another
            BinaryFormatter formatter = new BinaryFormatter();
            // Transports the data from the specified file to the RAM, like unfreezing ice into water, making it movable again.
            loadedGameData = formatter.Deserialize(stream) as GameData;
            loadedGameData.Sort();
        }
    }
}
