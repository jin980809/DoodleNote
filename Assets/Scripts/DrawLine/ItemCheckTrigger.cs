using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCheckTrigger : MonoBehaviour
{
   
    [SerializeField] private int BigPoint;
    [SerializeField] private int SmallPoint;

    public MapManager MM;
    public CameraFollow CF;
    public LineCreater LC;

    // Start is called before the first frame update
    void Start()
    {
        MM = GameObject.Find("MapManager").GetComponent<MapManager>();
        CF = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
        LC = GameObject.Find("DrawLineManager").GetComponent<LineCreater>();

        CF.enabled = false;
        LC.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BigPoint"))
        {
            Destroy(other.gameObject);
            CharacterManager.Instance.Score += BigPoint;
            CharacterManager.Instance.currentFever += BigPoint;
        }

        else if (other.CompareTag("SmallPoint"))
        {
            Destroy(other.gameObject);
            CharacterManager.Instance.Score += SmallPoint;
            CharacterManager.Instance.currentFever += SmallPoint;
        }

        else if(other.CompareTag("Potion"))
        {
            Destroy(other.gameObject);
            CharacterManager.Instance.currentHP += 20.0f;
        }

        else if (other.CompareTag("RedCrayon"))
        {
            Destroy(other.gameObject);
            CharacterManager.Instance.currentColor = CharacterManager.ColorState.Red;
        }

        else if (other.CompareTag("YellowCrayon"))
        {
            Destroy(other.gameObject);
            CharacterManager.Instance.currentColor = CharacterManager.ColorState.Yellow;
        }

        else if (other.CompareTag("BlueCrayon"))
        {
            Destroy(other.gameObject);
            CharacterManager.Instance.currentColor = CharacterManager.ColorState.Blue;
        }

        else if(other.CompareTag("MapStartArea"))
        {
            MM.makeInstance();
        }

        else if(other.CompareTag("StartPoint"))
        {
            CF.enabled = true;
            LC.enabled = true;
        }
    }
}
