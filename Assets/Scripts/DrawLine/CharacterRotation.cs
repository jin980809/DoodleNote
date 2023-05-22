using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRotation : MonoBehaviour
{
    private LineRenderer LR;
    private Vector3 L_Start_pos;
    private Vector3 L_End_pos;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Line"))
        {
            LR = other.gameObject.GetComponent<LineRenderer>();
            L_Start_pos = LR.GetPosition(0);
            L_End_pos = LR.GetPosition(1);
        }
    }

    void Start()
    {
        LR = GameObject.Find("Line").GetComponent<LineRenderer>();
        L_Start_pos = LR.GetPosition(0);
        L_End_pos = LR.GetPosition(1);
    }

    
    void Update()
    {
        float m_fDegree = Mathf.Atan((float)(L_End_pos.y - L_Start_pos.y) / (float)(L_End_pos.x - L_Start_pos.x)) * 180 / Mathf.PI;

        this.transform.rotation = Quaternion.AngleAxis(m_fDegree, Vector3.forward);

        Debug.Log(m_fDegree);
    }
}
