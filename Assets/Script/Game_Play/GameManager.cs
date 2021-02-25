using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI 관련 코드 가져오기
using UnityEngine.SceneManagement; // 씬 관리 코드 가져오기

public class GameManager : MonoBehaviour
{
    static public GameManager instance;

    public GameObject gameoverPannel; // 게임 오버 패널
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
        // 하드모드 설정
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
        //gameoverPannel.transform.Find("NewRecordImage").gameObject.SetActive(false);
        newrecordscreen.SetActive(false);
        ADinit.instance.ShowBanner();

        record_text.text = ProcessFloatData(surviveTime);

        if (DataCenter.instance.difficulty == Difficulty.Normal)
        {
            if (DataCenter.instance.gameData.normalScore[0] < surviveTime)
            {
                newrecordscreen.SetActive(true);
            }
            // 데이터를 넣음
            DataCenter.instance.AddScore(surviveTime, Difficulty.Normal);
        }
        else if (DataCenter.instance.difficulty == Difficulty.Hard)
        {
            if (DataCenter.instance.gameData.hardScore[0] < surviveTime)
            {
                newrecordscreen.SetActive(true);
            }
            // 데이터를 넣음
            DataCenter.instance.AddScore(surviveTime, Difficulty.Hard);
        }

        DataCenter.instance.SaveGameData();
    }

    private string ProcessFloatData(float value)
    {
        // 소숫점 버림
        int second = (int)Mathf.Floor(value);
        string text = (second / 60).ToString("00") + ":" + (second % 60).ToString("00");
        return text;
    }
}