using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float FixSpeed = 3.0f;
    private float Speed = 3.0f;
    private LineRenderer LR;
    private LineRenderer Pre_LR;

    public int Curr_index { get; set; }


    private Vector3 target_Pos;
    private Vector3 char_Pos;

    Animator Anim;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Line") || CharacterManager.Instance.Line_tag.ToString() == other.tag)
        {
            Debug.Log(CharacterManager.Instance.Line_tag.ToString());
            Pre_LR = LR;
            Curr_index = 0;
            LR = other.gameObject.GetComponent<LineRenderer>();
            LR.gameObject.GetComponent<EdgeCollider2D>().enabled = false;

            if(CharacterManager.Instance.is_Up)
            {
                this.transform.position = new Vector3(LR.GetPosition(0).x, LR.GetPosition(0).y + 0.5f, 0);
                target_Pos = new Vector3(LR.GetPosition(1).x, LR.GetPosition(1).y + 0.5f, 0);
            }
            else if(!CharacterManager.Instance.is_Up)
            {
                this.transform.position = new Vector3(LR.GetPosition(0).x, LR.GetPosition(0).y - 0.5f, 0);
                target_Pos = new Vector3(LR.GetPosition(1).x, LR.GetPosition(1).y - 0.5f, 0);
            }
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();

        LR = GameObject.Find("Line").GetComponent<LineRenderer>();

        Curr_index = 0;
        
        char_Pos = new Vector3(LR.GetPosition(Curr_index).x, LR.GetPosition(Curr_index).y + 0.5f, 0);

        target_Pos = new Vector3(LR.GetPosition(Curr_index + 1).x, LR.GetPosition(Curr_index + 1).y + 0.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position == target_Pos && Curr_index == LR.positionCount - 2)
        {
            Anim.SetBool("is_Run", false);
        }
        else
        {
            Anim.SetBool("is_Run", true);
        }

        if (this.transform.position == target_Pos && Curr_index < LR.positionCount - 2)
        {
            Curr_index++;
            UpDownChange();
        }

        this.transform.position = Vector2.MoveTowards(this.transform.position, target_Pos, Speed * Time.deltaTime);

        //Debug.Log(Curr_index);

    }

    public void UpDownChange()
    {
        if (CharacterManager.Instance.is_Up)
        {
            target_Pos = new Vector3(LR.GetPosition(Curr_index + 1).x, LR.GetPosition(Curr_index + 1).y + 0.5f, 0);
        }
        else if (!CharacterManager.Instance.is_Up)
        {
            target_Pos = new Vector3(LR.GetPosition(Curr_index + 1).x, LR.GetPosition(Curr_index + 1).y - 0.5f, 0);
        }
    }

    public void StopCharacter()
    {
        Anim.SetBool("is_Run", false);
        Speed = 0;
    }

    public void RunCharacter()
    {
        Anim.SetBool("is_Run", true);
        Speed = FixSpeed;
    }

    public void SetCharacterSpeed(float speed)
    {
        Speed = speed;
    }

    public void InitCharacterSpeed()
    {
        Speed = FixSpeed;
    }
}
