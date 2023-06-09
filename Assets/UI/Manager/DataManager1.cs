using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;

[System.Serializable]
public class SaveDataAsset
{
    public int _AmusementPark;
    public List<int> _saveAccessoryItemID = new List<int>();

    public List<int> GetsaveAccessoryItemData()
    {
        return _saveAccessoryItemID;
    }
}

public class DataManager1 : MonoBehaviour
{
    private string _saveDataPath;
    private string _saveFileName = "SaveFile";

    private Dictionary<EThema, int> levelProgressDictionary;
    public SaveDataAsset _saveData = new SaveDataAsset();

    void Start()
    {
    }

    private void Awake()
    {   
        if (_dataManager1 == null)
        {
            _dataManager1 = this;

            DontDestroyOnLoad(gameObject);

            levelProgressDictionary = new Dictionary<EThema, int>();
            //_saveData = new SaveDataAsset();
            
            _saveDataPath = Application.persistentDataPath + "/Save/";
            if (!Directory.Exists(_saveDataPath))
            {
                Directory.CreateDirectory(_saveDataPath);
                SaveData();
            }
            
            LoadData();
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
        string json = JsonUtility.ToJson(_saveData);
        File.WriteAllText(_saveDataPath + _saveFileName + ".json", json); 
    }

    private void LoadData()
    {      
        if (!File.Exists(_saveDataPath + _saveFileName + ".json"))
        {
            return;
        }
        else
        {
            string loadJson = File.ReadAllText(_saveDataPath + _saveFileName + ".json");
            _saveData = JsonUtility.FromJson<SaveDataAsset>(loadJson);
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
        //~Inventory   
        AccessoryInventory inventory = FindObjectOfType<AccessoryInventory>();
        var inventorylist = inventory.GetAllItems();

        _saveData._saveAccessoryItemID.Clear();
            
        for (int i = 0; i < inventorylist.Count; ++i)
        {
            if (inventorylist[i] != null)
            {
                Debug.Log(inventorylist[i]._itemID);
                _saveData._saveAccessoryItemID.Add(inventorylist[i]._itemID);
                Debug.Log(_saveData._saveAccessoryItemID[i]);
            }
        }

        //~Inventory

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

    public static DataManager1 p_DataManager1
    {
        get
        {
            if (_dataManager1 == null)
            {
                return null;
            }
            return _dataManager1;
        }
    }

    private static DataManager1 _dataManager1;
}
