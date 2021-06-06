using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject alertBox;
    public AudioMixer mixer;
    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;

    public void QuitGame()
    {
        Debug.Log("Quitting the game");
        Application.Quit();
    }

    public void DisplayOptionsMenu()
    {
        optionsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void CloseOptionsMenu()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void StartGame()
    {
        //SceneManager.LoadScene("Level");
        SceneManager.LoadScene(1);
    }

    public void ChangeMasterVolume(float masterVolume)
    {
        mixer.SetFloat("MasterVolume", Mathf.Log10(masterVolume) * 20);
    }

    public void ChangeMusicVolume(float musicVolume)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(musicVolume) * 20);
    }

    public void SaveOptions()
    {
        Debug.Log("Saving Options");
        float mixerMasterVolume;
        float mixerMusicVolume;
        mixer.GetFloat("MasterVolume", out mixerMasterVolume);
        mixer.GetFloat("MusicVolume", out mixerMusicVolume);
        PlayerPrefs.SetFloat("MasterVolume", mixerMasterVolume);
        PlayerPrefs.SetFloat("MusicVolume", mixerMusicVolume);
        PlayerPrefs.SetFloat("MasterVolumeSlider", masterVolumeSlider.value);
        PlayerPrefs.SetFloat("MusicVolumeSlider", musicVolumeSlider.value);
    }

    public void LoadOptions()
    {
        Debug.Log("Loading Options");
        float mixerMasterVolume = PlayerPrefs.GetFloat("MasterVolume", 0f);
        float mixerMusicVolume = PlayerPrefs.GetFloat("MusicVolume", 0f);
        mixer.SetFloat("MasterVolume", mixerMasterVolume);
        mixer.SetFloat("MusicVolume", mixerMusicVolume);
        float masterSliderValue = PlayerPrefs.GetFloat("MasterVolumeSlider", 1f);
        float musicSliderValue = PlayerPrefs.GetFloat("MusicVolumeSlider", 1f);
        masterVolumeSlider.value = masterSliderValue;
        musicVolumeSlider.value = musicSliderValue;
    }

    private void Start()
    {
        LoadOptions();
    }

    public void CheckForChanges()
    {
        float savedMasterVolume = PlayerPrefs.GetFloat("MasterVolume", 0f);
        float actualMasterVolume;
        mixer.GetFloat("MasterVolume", out actualMasterVolume);
        float savedMusicVolume = PlayerPrefs.GetFloat("MusicVolume", 0f);
        float actualMusicVolume;
        mixer.GetFloat("MusicVolume", out actualMusicVolume);
        if (Mathf.Approximately(savedMasterVolume, actualMasterVolume) && 
            Mathf.Approximately(savedMusicVolume, actualMusicVolume))
        {
            //The values are the same
            CloseOptionsMenu();
        }
        else
        {
            //The values are different
            ShowAlertBox();
        }
    }

    public void ShowAlertBox()
    {
        optionsMenu.SetActive(false);
        alertBox.SetActive(true);
    }

    public void CloseAlertBox()
    {
        mainMenu.SetActive(true);
        alertBox.SetActive(false);
    }

}
