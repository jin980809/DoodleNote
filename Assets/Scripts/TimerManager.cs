using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public static TimerManager Instance
    {
        get
        {
            if(m_instance == null)
            {
                m_instance = FindObjectOfType<TimerManager>();
            }
            return m_instance;
        }
    }
    private static TimerManager m_instance;
    
    bool active;
    private float time; // �ð�.
    private int t, m, s;

    private void Start()
    {
        active = false;
    }

    public void SetTimerOn()
    {
        active = true;
    }

    public void SetTimerOff()
    {
        active = false;
    }

    public float GetTime()
    {
        return time;
    }

    public void ResetTimer()
    {
        time = 0;
    }

    private void Update() // �ٲ�� �ð��� text�� �ݿ� �� �� update �����ֱ�
    {
        if (active)
        {
            time += Time.deltaTime;
            t = ((int)time / 3600);
            m = ((int)time / 60 % 60);
            s = ((int)time % 60);
        }
    }
}