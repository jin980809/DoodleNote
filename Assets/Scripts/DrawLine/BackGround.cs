using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public GameObject[] prefabList;
    //public GameObject SpawnTarget;

    public GameObject Curr_BackGround;
    public GameObject Pre_BackGround;
    public Transform TargetSpawn;

    private static BackGround m_instance;

    public static BackGround Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<BackGround>();
            }

            return m_instance;
        }
    }


    void Start()
    {
        Curr_BackGround.GetComponent<BackGroundMove>().enabled = false;
    }

    void Update()
    {
    }



    public void SpawnBackGround()
    {
        Pre_BackGround = Curr_BackGround;
        Curr_BackGround = Instantiate(prefabList[(int)MapManager.Instance.currentStage]);
        Curr_BackGround.transform.position = new Vector3(TargetSpawn.position.x, TargetSpawn.position.y + 3.76f, TargetSpawn.position.z);
        Destroy(Pre_BackGround);
    }
}
