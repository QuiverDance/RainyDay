using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public enum Difficulty
{
    Normal,
    Hard
}

public class DataCenter : MonoBehaviour
{
    static public DataCenter instance;

    public GameData gameData = null;
    
    public Difficulty difficulty;

    public Text text;

    private const string dataFileName = "RainFallRankingData.json";

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        LoadGameData();
    }

    public void LoadGameData()
    {
        string filePath = Application.persistentDataPath + '/' + dataFileName;

        if (File.Exists(filePath))
        {
            FileStream fs = new FileStream(Application.persistentDataPath + '/' + dataFileName,  FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string fromJsonData = sr.ReadToEnd();
            gameData = JsonUtility.FromJson<GameData>(fromJsonData);
            sr.Close();
            fs.Close();
        }
        else
        {
            text.text += "\nMake New File " + Application.persistentDataPath + '/' + dataFileName;
            gameData = new GameData();
        }
    }

    public void SaveGameData()
    {
        FileStream fs = new FileStream(Application.persistentDataPath + '/' + dataFileName, FileMode.Create, FileAccess.Write);
        StreamWriter sw = new StreamWriter(fs);
        string toJsonData = JsonUtility.ToJson(gameData);
        sw.Write(toJsonData);
        sw.Close();
        fs.Close();
    }

    private void OnApplicationPause()
    {
        SaveGameData();
    }

    private void OnApplicationQuit()
    {
        SaveGameData();
    }

    public void AddScore (float score, Difficulty dif)
    {
        if (dif == Difficulty.Normal)
        {
            gameData.normalScore.Add(score);
            gameData.normalScore.Sort();
            gameData.normalScore.Reverse();
        }
        else if (dif == Difficulty.Hard)
        {
            gameData.hardScore.Add(score);
            gameData.hardScore.Sort();
            gameData.hardScore.Reverse();
        }
        gameData.normalScore.RemoveRange(4, 10);
        gameData.hardScore.RemoveRange(4, 10);
    }

    public void SetDifficulty(Difficulty diff)
    {
        difficulty = diff;
    }

    public void SetVolume(float value)
    {
        gameData.volume = value;
    }

    public void SetSensitivity(float value)
    {
        gameData.sensitivity = value;
    }

    public void SetShowRange(bool value)
    {
        gameData.isShowRange = value;
    }
} 
