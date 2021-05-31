using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
    [Header("Menu Attributes")]
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Slider volumeSlider;
    
    private bool isPaused = false;
    private float loadedVolume;

    private void Awake()
    {
        // Loading saved volume through PlayerPrefs
        if(PlayerPrefs.HasKey("volume"))
        {
            loadedVolume = PlayerPrefs.GetFloat("volume");
            VolumeSlider(loadedVolume);
            volumeSlider.value = loadedVolume;
            Debug.Log("loaded player prefs volume");
        }
    }

    private void Update()
    {
        // Pause game with esc key
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            PauseGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
            Play();
    }


    /// <summary>
    /// Takes the slider value, remaps it for use with the master volume scale
    /// </summary>
    #region Volume Slider
    public void VolumeSlider(float _volume)
    {
        PlayerPrefs.SetFloat("volume", _volume);
        _volume = VolumeRemap(_volume);
        audioMixer.SetFloat("masterVolume", _volume);
    }
    public float VolumeRemap(float value)
    {
        return -40 + (value - 0) * (20 - -40) / (1 - 0);
    }
    #endregion

    /// <summary>
    /// Pauses game and time scale
    /// </summary>
    public void PauseGame()
    {
        pausePanel.SetActive(true);
        isPaused = true;
        Time.timeScale = 0;
    }

    public void LoadMain()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    /// <summary>
    /// Plays game and alters time scale
    /// </summary>
    public void Play()
    {
        pausePanel.SetActive(false);
        isPaused = false;
        Time.timeScale = 1;
    }

    /// <summary>
    /// Quits game from build and editor
    /// </summary>
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}
