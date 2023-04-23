using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectButton : MonoBehaviour
{
    [SerializeField]
    private int _levelIndex;

    [SerializeField]
    private string _levelSceneString;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    { 
        string themaString = gameObject.transform.parent.parent.gameObject.GetComponent<LevelSelectPanel>().p_ThemaString;

        Debug.Log(gameObject.transform.parent.parent.gameObject.GetComponent<LevelSelectPanel>());
        Debug.Log(themaString + "Scene" + _levelIndex.ToString());

        LevelManager.p_LevelManager.p_currentLevel = _levelIndex;
        LevelManager.p_LevelManager.p_currentThema = themaString;

        SceneManager.LoadScene(themaString + "Scene" + _levelIndex.ToString());
    }

    public void SetLevelIndex(int index)
    {
        _levelIndex = index;
    }
}
