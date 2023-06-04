using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRotation : MonoBehaviour
{
    private LineRenderer LR;
    private Vector3 L_Start_pos;
    private Vector3 L_End_pos;

    private int Curr_index = 0;

    private CharacterMovement CM;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Line") || CharacterManager.Instance.Line_tag.ToString() == other.tag)
        {
            LR = other.gameObject.GetComponent<LineRenderer>();
            L_Start_pos = LR.GetPosition(0);
            L_End_pos = LR.GetPosition(1);
        }
    }

    void Start()
    {
        CM = GameObject.Find("Character").GetComponent<CharacterMovement>();
        LR = GameObject.Find("Line").GetComponent<LineRenderer>();

        L_Start_pos = LR.GetPosition(Curr_index);
        L_End_pos = LR.GetPosition(Curr_index + 1);
    }

    
    void Update()
    {
        int Ci = CM.Curr_index;

        L_Start_pos = LR.GetPosition(Ci);
        L_End_pos = LR.GetPosition(Ci + 1);

        float m_fDegree = Mathf.Atan((float)(L_End_pos.y - L_Start_pos.y) / (float)(L_End_pos.x - L_Start_pos.x)) * 180 / Mathf.PI;

        //this.transform.rotation = Quaternion.AngleAxis(m_fDegree, Vector3.forward);

        if(CharacterManager.Instance.is_Up)
        {
            this.transform.eulerAngles = new Vector3(0f, 0f, m_fDegree);
        }
        else if(!CharacterManager.Instance.is_Up)
        {
            this.transform.eulerAngles = new Vector3(-180.0f, 0f, -m_fDegree);
        }

        //Debug.Log(m_fDegree);
    }
}
