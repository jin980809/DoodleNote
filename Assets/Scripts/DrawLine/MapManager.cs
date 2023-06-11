using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject[] prefabList;

    public GameObject inst_prefab;

    public List <GameObject> inst_prefabList;
    public Transform spawn_Point;
    private int randomIndex = -1;

    public int MapCount = 0;
    private int CurrentStageIndex = 0;

    public List<int> StageMapCount; // 놀이공원, 과자나라, 해변가, 우주 순

    List<Vector2> points;
    public enum StageState
    {
        Amusement_Park = 0,
        Sweets_Country = 1,
        Beach = 2,
        Space = 3
    };

    public StageState _StageState { get; set; }

    public StageState currentStage;

    private static MapManager m_instance;

    public static MapManager Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<MapManager>();
            }

            return m_instance;
        }
    }

    //private void Awake()
    //{
    //    if (m_instance != null && m_instance != this)
    //    {
    //        Destroy(gameObject);
    //        return;
    //    }

    //    m_instance = this;
    //    DontDestroyOnLoad(gameObject);
    //}

    private void Start()
    {
        inst_prefabList = new List<GameObject>(); 
    }

    public void makeInstance()
    {
        MapCount++;
        MapChange();
        SpawnRandomPrefab();
        LineMove();
    }

    public void SpawnRandomPrefab()
    {
        if (prefabList.Length > 0 && spawn_Point != null)
        {
            randomIndex = Random.Range(0, prefabList.Length);

            inst_prefab = Instantiate(prefabList[randomIndex]);
            inst_prefabList.Add(inst_prefab);

            if(inst_prefabList.Count == 4)
            {
                Destroy(inst_prefabList[0]);
                inst_prefabList.RemoveAt(0);
            }

        }
    }

    public void LineMove()
    {
        points = new List<Vector2>();

        for (int i = 0; i < inst_prefab.transform.childCount; i++)
        {
            GameObject child = inst_prefab.transform.GetChild(i).gameObject;
            //Debug.Log(child);

            if (child.CompareTag("Line") || child.CompareTag("RedLine") || child.CompareTag("YellowLine") || child.CompareTag("BlueLine"))
            {
                LineRenderer LR = child.GetComponent<LineRenderer>();
                EdgeCollider2D EC = child.GetComponent<EdgeCollider2D>();

                for (int j = 0; j < LR.positionCount; j++)
                {
                    LR.SetPosition(j, new Vector3(LR.GetPosition(j).x + spawn_Point.position.x + 24.0f, LR.GetPosition(j).y, LR.GetPosition(j).z));

                    points.Add(new Vector2(LR.GetPosition(j).x, LR.GetPosition(j).y));
                }

                EC.points = points.ToArray();
                points.Clear();
            }
            else
            {
                child.transform.position = new Vector3(child.transform.position.x + spawn_Point.position.x + 24.0f, child.transform.position.y, child.transform.position.z);
            }
        }

        spawn_Point.position = inst_prefab.transform.GetChild(1).gameObject.transform.position;

    }
    public void MapChange()
    {
        if (MapCount == StageMapCount[(int)currentStage])
        {
            if (System.Enum.GetValues(typeof(StageState)).Length - 1 == (int)currentStage)
            {
                CurrentStageIndex = 0;
            }
            else
            {
                CurrentStageIndex++;
            }

            currentStage = (StageState)CurrentStageIndex;
            MapCount = 0;
            BackGround.Instance.SpawnBackGround();


        }
        else
            return;
    }
}
