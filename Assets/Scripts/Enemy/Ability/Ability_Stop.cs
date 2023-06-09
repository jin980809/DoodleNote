using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability_Stop : MonoBehaviour
{
    private Collider2D col;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerCol"))
        {
            col = collision;
            collision.gameObject.transform.parent.GetComponent<CharacterMovement>().StopCharacter();
            TimerManager.Instance.SetTimerOn();
        }
    }

    private void Update()
    {
        if (TimerManager.Instance.GetTime() >= 1.0f && col != null)
        {
            col.gameObject.transform.parent.GetComponent<CharacterMovement>().RunCharacter();

            TimerManager.Instance.SetTimerOff();
            TimerManager.Instance.ResetTimer();
        }
    }
}
