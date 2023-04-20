using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int RedCount { get; set; }
    public int OrangeCount { get; set; }
    public int YellowCount { get; set; }
    public int GreenCount { get; set; }
    public int BlueCount { get; set; }
    public int PurpleCount { get; set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}
