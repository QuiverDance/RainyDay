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
        normal1.text = ProcessFloatData(DataCenter.instance.gameData.normalScore[0]);
        normal2.text = ProcessFloatData(DataCenter.instance.gameData.normalScore[1]);
        normal3.text = ProcessFloatData(DataCenter.instance.gameData.normalScore[2]);
        hard1.text = ProcessFloatData(DataCenter.instance.gameData.hardScore[0]);
        hard2.text = ProcessFloatData(DataCenter.instance.gameData.hardScore[1]);
        hard3.text = ProcessFloatData(DataCenter.instance.gameData.hardScore[2]);

    }
    private string ProcessFloatData(float value)
    {
        int second = (int)Mathf.Floor(value);
        string text = (second / 60).ToString("00") + ":" + (second % 60).ToString("00");
        return text;
    }
}
