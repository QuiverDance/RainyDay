/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayNANOO;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    public Plugin plugin;

    private float hscore;
    private string hard_score;
    private string[] arr;

    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;
    public Text text5;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(1.5f);

        plugin = Plugin.GetInstance();

        if (DataCenter.instance.gameData.id == "Null")
        {
            DataCenter.instance.gameData.id = FindUniqueID();
        }

        plugin.SetUUID(DataCenter.instance.gameData.id);
        plugin.SetNickname(DataCenter.instance.gameData.id);
        plugin.SetLanguage("Configure.PN_LANG_KO");

        arr = new string[5];
        hscore = DataCenter.instance.gameData.hardScore[0];
        hard_score = ProcessFloatData(hscore);
    }

    // Update is called once per frame
    void Update()
    {
        //AllRecordRead();
        //TextRecord();
    }

    string FindUniqueID()
    {
        string id;
        id = "Fire" + UnityEngine.Random.Range(0, 1000000);

        return id;
    }

    private string ProcessFloatData(float value)
    {
        int second = (int)Mathf.Floor(value);
        string text = (second / 60).ToString("00") + ":" + (second % 60).ToString("00");
        return text;
    }

    public void RankingRecord()
    {
        plugin.RankingRecord("rainyday-RANK-129B544E-8711B622", (int)hscore*100, hard_score, (state, message, rawData, dictionary) => {
            if (state.Equals(Configure.PN_API_STATE_SUCCESS))
            {
                Debug.Log("Success");
            }
            else
            {
                Debug.Log("Fail");
            }
        });
    }

    public void AllRecordRead()
    {
        int i = 0;

        plugin.Ranking("rainyday-RANK-129B544E-8711B622", (int)5, (state, message, rawData, dictionary) => {
            if (state.Equals(Configure.PN_API_STATE_SUCCESS))
            {
                ArrayList list = (ArrayList)dictionary["list"];
       
                foreach (Dictionary<string, object> rank in list)
                {
                    arr[i++] = rank["data"].ToString();
                    Debug.Log(rank["score"]);
                    Debug.Log(rank["data"]);
                }
            }
            else
            {
                Debug.Log("Fail");
            }
        });
    }

    public void TextRecord()
    {
        if (arr[0] != null)
            text1.text = arr[0];
        if (arr[1] != null)
            text2.text = arr[1];
        if (arr[2] != null)
            text3.text = arr[2];
        if (arr[3] != null)
            text4.text = arr[3];
        if (arr[4] != null)
            text5.text = arr[4];
    }
}
*/