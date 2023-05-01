using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineColorCheck : MonoBehaviour
{
    public GameObject Crayon_UI;


    void Start()
    {
        //Crayon_UI = GameObject.Find("Crayon");
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("OriginLine"))
        { 
            ButtonActive();
        }
        else
        {
            for (int i = 0; i < 6; i++)
            {
                Crayon_UI.transform.GetChild(i + 1).GetComponent<Button>().interactable = false;
            }
        }
    }

    private void ButtonActive()
    {
        Crayon_UI.transform.GetChild(1).GetComponent<Button>().interactable = GameManager.Instance.RedCount > 0 ? true : false;
     
        Crayon_UI.transform.GetChild(2).GetComponent<Button>().interactable = GameManager.Instance.OrangeCount > 0 ? true : false;
       
        Crayon_UI.transform.GetChild(3).GetComponent<Button>().interactable = GameManager.Instance.YellowCount > 0 ? true : false;
     
        Crayon_UI.transform.GetChild(4).GetComponent<Button>().interactable = GameManager.Instance.GreenCount > 0 ? true : false;
             
        Crayon_UI.transform.GetChild(5).GetComponent<Button>().interactable = GameManager.Instance.BlueCount > 0 ? true : false;
      
        Crayon_UI.transform.GetChild(6).GetComponent<Button>().interactable = GameManager.Instance.PurpleCount > 0 ? true : false;        
    }
}
