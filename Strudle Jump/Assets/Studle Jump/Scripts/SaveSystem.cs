using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveSystem : MonoBehaviour
{
    private string FilePath => Application.streamingAssetsPath + "/gameData";
    private GameData gameData;


    private void Start()
    {
        if (!Directory.Exists(Application.streamingAssetsPath))
            Directory.CreateDirectory(Application.streamingAssetsPath);
    }

    public void SaveBinary()
    {
        gameData = new GameData(FindObjectOfType<Score>().highScores);

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
            gameData = formatter.Deserialize(stream) as GameData;
            gameData.Sort();
        }
    }
}
