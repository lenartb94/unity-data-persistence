using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    private static DataManager Instance;

    public static int BestScore = 0;
    public static string Name;

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBestSocre();
    }

    public void SaveBestScore()
    {
        DataSave data = new DataSave();
        data.BestScore = BestScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/bestscore.json", json);
    }

    public void LoadBestSocre()
    {
        string path = Application.persistentDataPath + "/bestscore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            DataSave data = JsonUtility.FromJson<DataSave>(json);
            BestScore = data.BestScore;
        }
    }

    [System.Serializable]
    class DataSave
    {
        public int BestScore;
    }
}
