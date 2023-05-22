using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float Speed = 1.0f;
    private LineRenderer LR;
    private LineRenderer Pre_LR;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Line"))
        {
            Pre_LR = LR;
            LR = other.gameObject.GetComponent<LineRenderer>();
            Pre_LR.gameObject.GetComponent<EdgeCollider2D>().enabled = false;
            this.transform.position = LR.GetPosition(0);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        LR = GameObject.Find("Line").GetComponent<LineRenderer>();
        this.transform.position = LR.GetPosition(0);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, LR.GetPosition(1), Speed * Time.deltaTime);
    }
}
