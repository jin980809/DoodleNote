using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int _currentLevel;
    private string _currentThema;

    void Start()
    {

    }

    private void Awake()
    {
        if (_LevelManager == null)
        {
            _LevelManager = this;

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

    public void LoadNextLevel()     //임시코드
    {
        ++_currentLevel;

        DataManager.p_DataManager.SetLevelProgressData(EThema.AmusementPark, _currentLevel );
        DataManager.p_DataManager.SaveData();

        if (_currentLevel == 9)
        {
            SceneManager.LoadScene("LobbyScene");
        }
        SceneManager.LoadScene(_currentThema + "Scene" + (_currentLevel).ToString());


    }

    public static LevelManager p_LevelManager
    {
        get
        {
            if (_LevelManager == null)
            {
                return null;
            }
            return _LevelManager;
        }

        private set { }
    }

    public int p_currentLevel
    {
        get
        {
            return _currentLevel;
        }
        set
        {
            _currentLevel = value;
        }
    }

    public string p_currentThema
    {
        get
        {
            return _currentThema;
        }
        set
        {
            _currentThema = value;
        }

    }

    private static LevelManager _LevelManager;

}