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
        // 휴대폰 뒤로가기 버튼
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
        // 시간 정지 해제
        if (Time.timeScale == 0)
            Time.timeScale = 1;

        SceneManager.LoadScene("start_scene");

        ADinit.instance.HideBanner();
        if (!audioSource.isPlaying)
            audioSource.Play();
    }

    public void RestartButtonPush()
    {
        // 시간 정지 해제
        if (Time.timeScale == 0)
            Time.timeScale = 1;

        ADinit.instance.HideBanner();
        SceneManager.LoadScene("SampleScene");
        if (!audioSource.isPlaying)
            audioSource.Play();
    }

    public void PauseButtonPush()
    {
        Time.timeScale = 0; // 멈춤
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
