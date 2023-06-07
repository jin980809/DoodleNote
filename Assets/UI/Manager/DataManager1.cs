using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class LevelProgressData
{
    public int _AmusementPark;
}

public class DataManager1 : MonoBehaviour
{
    private string _saveDataPath;
    private string _saveFileName = "LevelProgressSaveFile";

    private Dictionary<EThema, int> levelProgressDictionary;
    private LevelProgressData levelProgressData;

    void Start()
    {
        levelProgressDictionary = new Dictionary<EThema, int>();
        levelProgressData = new LevelProgressData();
        _saveDataPath = Application.persistentDataPath + "/Save/";
        if(!Directory.Exists(_saveDataPath))
        {
            Directory.CreateDirectory(_saveDataPath);
            SaveData();
        }

        LoadData();
    }

    private void Awake()
    {
        if (_dataManager == null)
        {
            _dataManager = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SaveData()
    {
        string json = JsonUtility.ToJson(levelProgressData);
        File.WriteAllText(_saveDataPath + _saveFileName + ".json", json);
    }

    private void LoadData()
    {
        if(!File.Exists(_saveDataPath + _saveFileName + ".json"))
        {
            return;
        }
        else
        {
            string loadJson = File.ReadAllText(_saveDataPath + _saveFileName + ".json");
            levelProgressData = JsonUtility.FromJson<LevelProgressData>(loadJson);

            levelProgressDictionary.Add(EThema.AmusementPark, levelProgressData._AmusementPark);        //TODO : Refactoring Load Func;
        }
    }

    public int GetLevelProgressData(EThema thema)
    {
        int outLevelProgress;
        bool bSuccess = levelProgressDictionary.TryGetValue(thema, out outLevelProgress);
        
        if (bSuccess)
        {
            return outLevelProgress;
        }
        else
        {
            return -1;
        }
    }

    void OnApplicationQuit()
    {
        SaveData();
    }

    public void SetLevelProgressData(EThema thema, int currentClearLevel)
    {
       
        if(levelProgressDictionary.ContainsKey(thema))
        {
           
            int clearLevel;
            levelProgressDictionary.TryGetValue(thema, out clearLevel);

            Debug.Log(clearLevel);

            if (clearLevel < currentClearLevel)
            {
                levelProgressDictionary[thema] = currentClearLevel;
            }
        }
    }

    public static DataManager1 p_DataManager
    {
        get
        {
            if (_dataManager == null)
            {
                return null;
            }
            return _dataManager;
        }
    }

    private static DataManager1 _dataManager;
}
