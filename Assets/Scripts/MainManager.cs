using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public string playerName;
    public int m_highScore;
    public string m_highScoreName;
    

    private void Awake()
    {
        if(Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    [System.Serializable]
    class HighScore
    {
        public int score;
        public string name;
    }
    public void SaveHighScore()
    {
        HighScore highScore = new HighScore();
        highScore.score = MainManager.Instance.m_highScore;
        highScore.name = MainManager.Instance.playerName;
        string json = JsonUtility.ToJson(highScore);
        File.WriteAllText(Application.persistentDataPath + "/highscore.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/highscore.json";
        if(File.Exists(path)){
            string json = File.ReadAllText(path);
            HighScore highScore = JsonUtility.FromJson<HighScore>(json);
            m_highScore = highScore.score;
            m_highScoreName = highScore.name;
        }
        else{
            m_highScore = 0;
            m_highScoreName = "";
        }
    }

}
