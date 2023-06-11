using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CustomUIClick : MonoBehaviour
{
    public GameObject customUI;
    private bool Active;

    // Start is called before the first frame update
    void Start()
    {
        Active = false;
        customUI.SetActive(false) ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        Active = !Active;
        customUI.SetActive(Active);

    }
}
