using UnityEngine;

public class PotalLeverController : MonoBehaviour
{
    private bool is_visit = false;
    private bool is_change = false;

    [SerializeField]
    private GameObject Portal;

    private Animator Anim;

    void Start()
    {
        Portal.SetActive(false);
        Anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !is_visit)
        {
            is_visit = true;
            RotateLine();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && is_visit)
        {
            is_visit = false;
        }
    }

    void RotateLine()
    {
        if (!is_change)
        { 
            is_change = true;
        }
        else
        {
            is_change = false;
        }

        Anim.SetBool("is_right", is_change);
        Portal.SetActive(is_change);
    }
}
