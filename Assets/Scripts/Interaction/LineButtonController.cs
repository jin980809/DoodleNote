using UnityEngine;
using System.Collections;

public class LineButtonController : MonoBehaviour
{
    public GameObject OriLine;
    public GameObject ChangeLine;

    private Vector3 F_Ori_Pos;
    private Vector3 E_Ori_Pos;
    private Vector3 F_Chan_Pos;
    private Vector3 E_Chan_Pos;

    private Vector3 S_pos;
    private Vector3 E_pos;

    private LineRenderer Ori_LineRenderer;
    private LineRenderer Chan_LineRenderer;

    private bool is_visit = false;
    private bool is_change = false;

    private Animator Anim;

    void Start()
    {
        Ori_LineRenderer = OriLine.GetComponent<LineRenderer>();
        Chan_LineRenderer = ChangeLine.GetComponent<LineRenderer>();

        ChangeLine.SetActive(false);
        OriLine.SetActive(true);

        F_Ori_Pos = Ori_LineRenderer.GetPosition(0);
        E_Ori_Pos = Ori_LineRenderer.GetPosition(1);
        F_Chan_Pos = Chan_LineRenderer.GetPosition(0);
        E_Chan_Pos = Chan_LineRenderer.GetPosition(1);

        S_pos = F_Ori_Pos;
        E_pos = E_Ori_Pos;

        Anim = GetComponent<Animator>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if ((other.CompareTag("Box") || other.CompareTag("Player"))  && !is_visit)
        {
            is_visit = true;
            RotateLine();
            Anim.SetBool("is_ButtonDown", true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if ((other.CompareTag("Box") || other.CompareTag("Player")) && is_visit)
        {
            is_visit = false;
            RotateLine();
            Anim.SetBool("is_ButtonDown", false);
        }
    }

    void RotateLine()
    {
        if (!is_change)
        {
            ChangeLine.SetActive(true);
            OriLine.SetActive(false);
            StopAllCoroutines();

            ChangeLine.GetComponent<EdgeCollider2D>().enabled = false;
            OriLine.GetComponent<EdgeCollider2D>().enabled = false;

            StartCoroutine(MoveLineToPosition(ChangeLine, Chan_LineRenderer,  S_pos, E_pos, F_Chan_Pos, E_Chan_Pos, 2f));

            is_change = true;
        }
        else
        {
            ChangeLine.SetActive(false);
            OriLine.SetActive(true);
            StopAllCoroutines();

            OriLine.GetComponent<EdgeCollider2D>().enabled = false;
            ChangeLine.GetComponent<EdgeCollider2D>().enabled = false;

            StartCoroutine(MoveLineToPosition(OriLine, Ori_LineRenderer, S_pos, E_pos, F_Ori_Pos, E_Ori_Pos, 2f));

            is_change = false;
        }
    }

    IEnumerator MoveLineToPosition(GameObject Line, LineRenderer lineToMove, Vector3 startPosition, Vector3 endPosition, Vector3 targetStart, Vector3 targetEnd, float duration)
    {
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);

            S_pos = lineToMove.GetPosition(0);
            E_pos = lineToMove.GetPosition(1);

            lineToMove.SetPosition(0, Vector3.Lerp(startPosition, targetStart, t));
            lineToMove.SetPosition(1, Vector3.Lerp(endPosition, targetEnd, t));

            yield return null;
        }

        lineToMove.SetPosition(0, targetStart);
        lineToMove.SetPosition(1, targetEnd);

        Line.GetComponent<EdgeCollider2D>().enabled = true;
    }
}
