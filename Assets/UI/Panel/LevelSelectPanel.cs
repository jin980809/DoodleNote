using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelSelectPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject _levelpanel;

    [SerializeField]
    private GameObject joystick;

    private string _themaString;

    void Awake()
    {
        joystick = GameObject.Find("JoyStick");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBackButton()
    {
        joystick.SetActive(true);
        joystick.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.SetActive(false);
        
    }

    public string p_ThemaString
    {
        get
        {
            return _themaString;
        }
        set
        {
            _themaString = value;
        }
    }

}
