using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class RecordScreen : MonoBehaviour
{
    public Text normal1;
    public Text normal2;
    public Text normal3;
    public Text hard1;
    public Text hard2;
    public Text hard3;

    void Start()
    {
        /*
        // float초를 00:00형식으로 변환
        normal1.text = string.Format("{0:2N}:{0:2N}", (int)(DataCenter.instance.gameData.normalScore[0]) / 60, (int)(DataCenter.instance.gameData.normalScore[0]) % 60);
        normal2.text = string.Format("{0}:{1}", (int)(DataCenter.instance.gameData.normalScore[1]) / 60, (int)(DataCenter.instance.gameData.normalScore[1]) % 60);
        normal3.text = string.Format("{0}:{1}", (int)(DataCenter.instance.gameData.normalScore[2]) / 60, (int)(DataCenter.instance.gameData.normalScore[2]) % 60);
        hard1.text = string.Format("{0}:{1}", (int)(DataCenter.instance.gameData.hardScore[0]) / 60, (int)(DataCenter.instance.gameData.hardScore[0]) % 60);
        hard2.text = string.Format("{0}:{1}", (int)(DataCenter.instance.gameData.hardScore[1]) / 60, (int)(DataCenter.instance.gameData.hardScore[1]) % 60);
        hard3.text = string.Format("{0}:{1}", (int)(DataCenter.instance.gameData.hardScore[2]) / 60, (int)(DataCenter.instance.gameData.hardScore[2]) % 60);
        */
        normal1.text = ProcessFloatData(DataCenter.instance.gameData.normalScore[0]);
        normal2.text = ProcessFloatData(DataCenter.instance.gameData.normalScore[1]);
        normal3.text = ProcessFloatData(DataCenter.instance.gameData.normalScore[2]);
        hard1.text = ProcessFloatData(DataCenter.instance.gameData.hardScore[0]);
        hard2.text = ProcessFloatData(DataCenter.instance.gameData.hardScore[1]);
        hard3.text = ProcessFloatData(DataCenter.instance.gameData.hardScore[2]);

    }

    // float 숫자를 분:초로 바꾸는 함수
    private string ProcessFloatData(float value)
    {
        // 소숫점 버림
        int second = (int)Mathf.Floor(value);
        string text = (second / 60).ToString("00") + ":" + (second % 60).ToString("00");
        return text;
    }
}
