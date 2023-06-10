using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Follow : MonoBehaviour
{
    private GameObject target;
    [SerializeField] private float moveSpeed = 5;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        Destroy(this.gameObject, 5);
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
        transform.up = target.transform.position - transform.position;
        Debug.Log(target.transform.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerCol"))
        {
            Destroy(gameObject);
        }
    }
}
