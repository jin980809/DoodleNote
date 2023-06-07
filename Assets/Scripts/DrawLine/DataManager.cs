using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class DataManager : MonoBehaviour
{
    public static DataManager Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<DataManager>();
            }

            return m_instance;
        }
    }

    private void Awake()
    {
        if (m_instance != null && m_instance != this)
        {
            Destroy(gameObject);
            return;
        }

        m_instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private static DataManager m_instance;

    public List<Dictionary<string, object>> HP_List;
    public List<Dictionary<string, object>> Fever_List;
    public List<Dictionary<string, object>> TrasureMap_List;

    private string _saveDataPath;
    private string _saveFileName = "Stat";

    [System.Serializable]
    public class stat
    {
        public int Hp, FeverTime, TrasureMap, Coin;
    }

    public stat charStat;

    void Start()
    {
        ReadCSV();
        LoadJson();

        _saveDataPath = Application.persistentDataPath + "/Save/";

        //Debug.Log(HP_List[charStat.Hp]["Stat"].ToString());
        //Debug.Log(Fever_List[charStat.FeverTime]["Stat"].ToString());
        //Debug.Log(TrasureMap_List[charStat.TrasureMap]["Stat"].ToString());
        //Debug.Log(charStat.Coin.ToString());

    }

    void Update()
    {
        //LoadJson();
    }

    void ReadCSV()
    {
        HP_List = CSVReader.Read("HP");
        Fever_List = CSVReader.Read("FeverTime");
        TrasureMap_List = CSVReader.Read("TrasureMap");

    }

    public void LoadJson()
    {
        var loadedJson = Resources.Load<TextAsset>("Json/Stat");
        if (loadedJson == null)
            Debug.Log("json file does not exist");

        charStat = JsonUtility.FromJson<stat>(loadedJson.ToString());
    }

    public void SaveJson()
    {
        string json = JsonUtility.ToJson(charStat);
        File.WriteAllText(_saveDataPath + _saveFileName + ".json", json);
    }

}
