using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetNPC : MonoBehaviour
{
    public string playerTag = "Player";
    public GameObject objectToDisappear; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            objectToDisappear.SetActive(false);
        }
    }
}
