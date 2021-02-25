using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[Serializable]
public class GameData
{
    public List<float> normalScore = new List<float>();
    public List<float> hardScore = new List<float>();
    public float volume = 1.0f;
    public float sensitivity = 0.5f;
    public bool isGameEnd = false;

    public string id = "Null";
    public bool isShowRange = false;
    public GameData()
    {
        normalScore.Add(0.0f);
        normalScore.Add(0.0f);
        normalScore.Add(0.0f);
        hardScore.Add(0.0f);
        hardScore.Add(0.0f);
        hardScore.Add(0.0f);
    }
}
