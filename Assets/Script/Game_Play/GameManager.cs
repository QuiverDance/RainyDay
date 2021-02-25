using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static public GameManager instance;

    public GameObject gameoverPannel;
    public Text survive_time_text;
    public Text record_text;
    public GameObject pausescreen;
    public GameObject newrecordscreen;

    public bool isGameover = false;
    public float surviveTime = 0f;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        isGameover = false;

        if (DataCenter.instance.difficulty == Difficulty.Normal)
        {
            GameObject.Find("Co2Spawner").SetActive(false);
        }

        DataCenter.instance.gameData.isGameEnd = false;
        Screen.sleepTimeout = (int)SleepTimeout.NeverSleep;
    }
    
    void Update()
    {
        if (!isGameover)
        {
            surviveTime += Time.deltaTime;
            survive_time_text.text = ProcessFloatData(surviveTime);
            if(!pausescreen.activeInHierarchy)
                ADinit.instance.HideBanner();
        }
    }

    public void EndGame()
    {
        DataCenter.instance.gameData.isGameEnd = true;

        isGameover = true;
        gameoverPannel.SetActive(true);
        newrecordscreen.SetActive(false);
        ADinit.instance.ShowBanner();

        record_text.text = ProcessFloatData(surviveTime);

        if (DataCenter.instance.difficulty == Difficulty.Normal)
        {
            if (DataCenter.instance.gameData.normalScore[0] < surviveTime)
            {
                newrecordscreen.SetActive(true);
            }

            DataCenter.instance.AddScore(surviveTime, Difficulty.Normal);
        }
        else if (DataCenter.instance.difficulty == Difficulty.Hard)
        {
            if (DataCenter.instance.gameData.hardScore[0] < surviveTime)
            {
                newrecordscreen.SetActive(true);
            }

            DataCenter.instance.AddScore(surviveTime, Difficulty.Hard);
        }

        DataCenter.instance.SaveGameData();
    }

    private string ProcessFloatData(float value)
    {
        int second = (int)Mathf.Floor(value);
        string text = (second / 60).ToString("00") + ":" + (second % 60).ToString("00");
        return text;
    }
}