using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCrayon : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            switch (this.tag)
            {
                case "RedCrayon":
                    GameManager.Instance.RedCount++;
                    break;

                case "OrangeCrayon":
                    GameManager.Instance.OrangeCount++;
                    break;

                case "YellowCrayon":
                    GameManager.Instance.YellowCount++;
                    break;

                case "GreenCrayon":
                    GameManager.Instance.GreenCount++;
                    break;

                case "BlueCrayon":
                    GameManager.Instance.BlueCount++;
                    break;

                case "PurpleCrayon":
                    GameManager.Instance.PurpleCount++;
                    break;

            }

            Destroy(gameObject);
        }
    }
}
