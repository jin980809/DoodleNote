using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class LevelSelector : MonoBehaviour
{
    //levelselector, thema repactoring

    [SerializeField]
    private GameObject _levelSelectPanelPrefab;

    [SerializeField]
    private Transform _canvas;

    [SerializeField]
    private Sprite _lockBackGroundImage;

    [SerializeField]
    private Sprite _lockImage;

    [SerializeField]
    private List<Sprite> _levelNumberIndex;

    [SerializeField]
    private EThema _thema;

    [SerializeField]
    private string _themaSceneString;

    private GameObject _levelSelectPanelObject;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //TODO : Refactoring     
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //_levelSelectPanelObject.SetActive(false);
    }

    public void Activate(bool activate)
    {
        if (!_levelSelectPanelObject)
        {
            _levelSelectPanelObject = Instantiate(_levelSelectPanelPrefab, _canvas);
            _levelSelectPanelObject.transform.SetSiblingIndex(0);

            int levelButtonCount = _levelSelectPanelObject.transform.GetChild(0).childCount;
            int levelclearindex = DataManager1.p_DataManager.GetLevelProgressData(_thema);

            int i = 0;
            for (i = 0; i < levelclearindex + 1; ++i)       //CurrentLevel
            {
                var button = _levelSelectPanelObject.transform.GetChild(0).GetChild(i).GetComponent<LevelSelectButton>();
                button.SetLevelIndex(i);
                button.transform.GetChild(0).GetComponent<Image>().sprite = _levelNumberIndex[i];
            }

            //Currentlevel next
            var buttontemp = _levelSelectPanelObject.transform.GetChild(0).GetChild(i).GameObject();
            Color color = new Color(255.0f, 255.0f, 255.0f, 150.0f);
            buttontemp.GetComponent<Button>().interactable = false;
            buttontemp.GetComponent<Image>().color = color;
            buttontemp.GetComponent<Image>().sprite = _lockBackGroundImage;
            buttontemp.transform.GetChild(0).GameObject().GetComponent<Image>().sprite = _lockImage;
            buttontemp.GetComponent<LevelSelectButton>().SetLevelIndex(i);

            //Lock level
            for (++i; i < levelButtonCount; ++i)
            {
                var button = _levelSelectPanelObject.transform.GetChild(0).GetChild(i).GameObject();
                button.GetComponent<Button>().interactable = false;
                button.GetComponent<Image>().color = new Color(255.0f, 255.0f, 255.0f, 100.0f);
                button.GetComponent<Image>().sprite = _lockBackGroundImage;
                button.transform.GetChild(0).GameObject().SetActive(false);
                button.GetComponent<LevelSelectButton>().SetLevelIndex(i);
            }

            _levelSelectPanelObject.GetComponent<LevelSelectPanel>().p_ThemaString = _themaSceneString;

            Debug.Log(_levelSelectPanelObject.GetComponent<LevelSelectPanel>().p_ThemaString);
        }
        else
        {
            if (!_levelSelectPanelObject.activeSelf)
            {
                _levelSelectPanelObject.SetActive(true);
            }
        }
    }



    public EThema GetThema()
    {
        return _thema;
    }
}
