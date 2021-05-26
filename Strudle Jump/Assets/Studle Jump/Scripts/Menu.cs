using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;

    [SerializeField] private TMP_Text scorePrefab;
    
    public void DisplayHighScore()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Play()
    {
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        application.Quit();
#endif
    }

}
