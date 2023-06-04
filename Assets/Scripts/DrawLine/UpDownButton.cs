using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownButton : MonoBehaviour
{
    private CharacterManager CMR;
    private CharacterMovement CMT;

    void Start()
    {

        CMT = GameObject.Find("Character").GetComponent<CharacterMovement>();
    }


    public void UpDownClick()
    {
        CharacterManager.Instance.is_Up = !CharacterManager.Instance.is_Up;


        if (CharacterManager.Instance.is_Up)
        {
            CMT.transform.position = new Vector3(CMT.transform.position.x, CMT.transform.position.y + 1f, 0);
        }
        else if (!CharacterManager.Instance.is_Up)
        {
            CMT.transform.position = new Vector3(CMT.transform.position.x, CMT.transform.position.y - 1f, 0);
        }

        CMT.UpDownChange();
    }
}
