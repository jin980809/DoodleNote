using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public static DamageManager Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<DamageManager>();
            }
            return m_instance;
        }
    }
    private static DamageManager m_instance;

    [SerializeField] public List<EnemyInfo> enemy = new List<EnemyInfo>();
}

[System.Serializable]
public struct EnemyInfo
{
    public GameObject enemy;
    public float enemy_damage;
}