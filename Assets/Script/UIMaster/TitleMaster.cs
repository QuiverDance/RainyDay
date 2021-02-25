using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
 
public class TitleMaster : MonoBehaviour
{
    public GameObject gameStartScreen;
    public GameObject helpScreen;
    public GameObject recordScreen;
    public GameObject gameSettingScreen;
    public GameObject gameSettingScreen2;
    public GameObject gameExitScreen;

    private AudioSource audioSource;
    public AudioClip sound;

    public Slider volumeSlider;
    public Slider sensitivitySlider;

    void Start()
    {
        gameStartScreen.SetActive(false);
        helpScreen.SetActive(false);
        recordScreen.SetActive(false);
        gameSettingScreen.SetActive(false);
        gameSettingScreen2.SetActive(false);
        gameExitScreen.SetActive(false);

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = sound;

        volumeSlider.value = DataCenter.instance.gameData.volume;
        sensitivitySlider.value = DataCenter.instance.gameData.sensitivity;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameStartScreen.activeInHierarchy == true)
            {
                GameStartScreenReturnButtonPush();
            }
            else if (helpScreen.activeInHierarchy == true)
            {
                HelpScreenConfirmButtonPush();
            }
            else if (recordScreen.activeInHierarchy == true)
            {
                RecoredConfirmButtonPush();
            }
            else if (gameSettingScreen.activeInHierarchy == true || gameSettingScreen2.activeInHierarchy == true)
            {
                GameSettingScreenConfirmButtonPush();
            }
            else if (gameExitScreen.activeInHierarchy == true)
            {
                GameExitScreenReturnButtonPush();
            }    
            else
            {
                GameExitButtonPush();
            }
        }
    }

    public void GameStartButtonPush()
    {
        gameStartScreen.SetActive(true);
        audioSource.Play();
    }

    public void GameSettingButtonPush()
    {
        gameSettingScreen.SetActive(true);
        audioSource.Play();
    }

    public void HelpButtonPush()
    {
        helpScreen.SetActive(true);
        audioSource.Play();
    }

    public void RecordButtonPush()
    {
        recordScreen.SetActive(true);
        audioSource.Play();
    }

    public void RecoredConfirmButtonPush()
    {
        recordScreen.SetActive(false);
        audioSource.Play();
    }

    public void NormalGameStartButtonPush()
    {
        DataCenter.instance.SetDifficulty(Difficulty.Normal);
        SceneManager.LoadScene("SampleScene");
        audioSource.Play();
    }

    public void HardGameStartButtonPush()
    {
        DataCenter.instance.SetDifficulty(Difficulty.Hard);
        SceneManager.LoadScene("SampleScene");
        audioSource.Play();
    }

    public void GameStartScreenReturnButtonPush()
    {
        gameStartScreen.SetActive(false);
        audioSource.Play();
    }

    public void HelpScreenConfirmButtonPush()
    {
        helpScreen.SetActive(false);
        audioSource.Play();
    }

    public void GameSettingScreenConfirmButtonPush()
    {
        gameSettingScreen.SetActive(false);
        gameSettingScreen2.SetActive(false);
        audioSource.Play();
    }

    public void GameSettingNextButtionPush()
    {
        gameSettingScreen.SetActive(false);
        gameSettingScreen2.SetActive(true);
        audioSource.Play();
    }
    public void GameSettingBackButtionPush()
    {
        gameSettingScreen2.SetActive(false);
        gameSettingScreen.SetActive(true);
        audioSource.Play();
    }

    public void GameSettingRangeONButtionPush()
    {
        DataCenter.instance.SetShowRange(true);
        audioSource.Play();
    }
    public void GameSettingRangeOFFButtionPush()
    {
        DataCenter.instance.SetShowRange(false);
        audioSource.Play();
    }

    public void GameExitButtonPush()
    {
        gameExitScreen.SetActive(true);
        audioSource.Play();
    }

    public void GameExitScreenReturnButtonPush()
    {
        gameExitScreen.SetActive(false);
        audioSource.Play();
    }

    public void GameExitScreenExitButtonPush()
    {
        Application.Quit();
    }
}
