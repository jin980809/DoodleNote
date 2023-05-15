using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float Speed = 1.0f;
    private LineRenderer LR;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Line"))
        {
            LR = other.gameObject.GetComponent<LineRenderer>();
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
