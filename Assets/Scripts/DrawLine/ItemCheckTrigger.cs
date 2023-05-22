using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCheckTrigger : MonoBehaviour
{
    public int Score = 0;
    private int StarPoint = 100;
    public CharacterManager CM;

    // Start is called before the first frame update
    void Start()
    {
        CM = this.transform.parent.GetComponent<CharacterManager>();
    }

    // Update is called once per frame
    void Update()
    {
        UIM.Instance.UpdateScoreText(Score);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Star"))
        {
            Destroy(other.gameObject);
            Score += StarPoint;
        }

        else if(other.CompareTag("Potion"))
        {
            Destroy(other.gameObject);
            CM.currentHP += 20.0f;
        }
    }
}
