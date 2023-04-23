using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionButtonPanel : MonoBehaviour
{
    //[SerializeField]
    //private GameObject _optionButtonLayout;
    /*
    [SerializeField]
    private GameObject _restartButtonPrefab;

    [SerializeField]
    private GameObject _levelSelecButtonPrefab;

    [SerializeField]
    private GameObject _exitButtonPrefab;
    */
    //private List<CommonUIButton> _optionButtonList;

    void Start()    
    {
        //Instantiate(_exitButtonPrefab);
        //_optionButtonList.Add();
        //TODO : _optionButtonList = button;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnRestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnLevelSelection()
    {
        Debug.Log("click");
        //string currentThemaScene = UIManager.p_UIManager.p_currentThema;
        SceneManager.LoadScene("LobbyScene");    
    }

    public void OnExitGame()
    {

    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }

}
