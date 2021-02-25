using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class ButtonMaster : MonoBehaviour
{
    public GameObject pauseScreen;

    private AudioSource audioSource;
    public AudioClip sound;

    public void Start()
    {
        pauseScreen.SetActive(false);

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = sound;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && DataCenter.instance.gameData.isGameEnd == false)
        {
            audioSource.Play();

            if (Time.timeScale == 0)
            {
                ResumeButtonPush();
            }
            else
            {
                PauseButtonPush();
            }
        }
    }

    public void MainMenuButtonPush()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;

        SceneManager.LoadScene("start_scene");

        ADinit.instance.HideBanner();
        if (!audioSource.isPlaying)
            audioSource.Play();
    }

    public void RestartButtonPush()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;

        ADinit.instance.HideBanner();
        SceneManager.LoadScene("SampleScene");
        if (!audioSource.isPlaying)
            audioSource.Play();
    }

    public void PauseButtonPush()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);

        ADinit.instance.ShowBanner();
        if (!audioSource.isPlaying)
            audioSource.Play();
    }

    public void ResumeButtonPush ()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);

        ADinit.instance.HideBanner();
        if (!audioSource.isPlaying)
            audioSource.Play();
    }

    public void OnApplicationPause()
    {
        if (!GameManager.instance.isGameover && Time.timeScale == 1)
            PauseButtonPush();
    }
}
