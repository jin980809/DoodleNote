using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JCharacterController : MonoBehaviour
{
    public bool is_up = true;     // 캐릭터가 라인 위에 있을때
    public bool is_down = false;  // 캐릭터가 라인 아래에 있을때
    public bool is_right = false; // 캐릭터가 라인 오른쪽에 있을때
    public bool is_left = false;  // 캐릭터가 라인 왼쪽에 있을때

    public bool dir_up = false;    // true이면 진행 방향이 위일때, false이면 진행 방행이 아래일때
    public bool dir_right = true; // true이면 진행방향이 오른쪽일때, false이면 진행 방향이 왼쪽일때

    public bool is_fall;
    public bool is_side = false;
    public bool is_mid = false;
    public bool is_jump = false;

    private bool Anim_End = true;

    private GameObject Joystick;
    private GameObject P;

    Animator Anim;

    void Start()
    {
        Joystick = GameObject.Find("JoyStick");
        P = GameObject.Find("Player");
        Anim = GetComponent<Animator>();
        Joystick.GetComponent<Joystick>().is_click = true;
    }

    void Update()
    {
        float Hori = Joystick.GetComponent<Joystick>().Horizontal;
        float Vert = Joystick.GetComponent<Joystick>().Vertical;

        Anim.SetBool("Is_Mid", is_mid);



        if (Vert > 0 && (-1 * Vert < Hori && Hori < Vert))
        {
            if ((is_left || is_right || is_side ) && Joystick.GetComponent<Joystick>().is_click)
            {
                Anim.SetBool("Is_Walk", true);
                Anim.SetBool("Is_Idle", false);

                Joystick.GetComponent<Joystick>().is_click = false;

                if (is_up && dir_right)
                {
                    is_up = false;
                    is_left = true;
                    dir_up = true;
                }
                else if (is_up && !dir_right)
                {
                    is_up = false;
                    is_right = true;
                    dir_up = true;
                }

                if (!dir_up)
                {
                    dir_up = true;
                }
            }

            if (is_down && !is_mid && Joystick.GetComponent<Joystick>().is_click && Anim_End)
            {
                is_mid = true;

                P.GetComponent<JCharacterMovement>().moveSpeed = 0f;
                //transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f);

                Anim_End = false;

                Joystick.GetComponent<Joystick>().is_click = false;
            }
            else if (is_down && is_mid && Joystick.GetComponent<Joystick>().is_click && Anim_End)
            {
                is_mid = false;
                is_down = false;
                is_up = true;

                P.GetComponent<JCharacterMovement>().moveSpeed = 5f;
                transform.position = new Vector3(transform.position.x, transform.position.y + 1f);

                Anim_End = false;

                Joystick.GetComponent<Joystick>().is_click = false;
            }
            else if (is_mid && !is_right && !is_left && Joystick.GetComponent<Joystick>().is_click && Anim_End)
            {
                is_mid = false;

                P.GetComponent<JCharacterMovement>().moveSpeed = 5f;
                //transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f);

                Anim_End = false;

                Joystick.GetComponent<Joystick>().is_click = false;
            }

            if (is_up && is_jump && Joystick.GetComponent<Joystick>().is_click && Anim_End)
            {
                Anim.SetBool("Is_Jump", true);

                is_up = false;
                is_down = true;

                Anim_End = false;

                //transform.position = new Vector2(transform.position.x, transform.position.y + 1f);

                Joystick.GetComponent<Joystick>().is_click = false;
            }

        }

        else if (Vert < 0 && (-1 * Vert > Hori && Hori > Vert))
        {
            if ((is_left || is_right || is_side) && Joystick.GetComponent<Joystick>().is_click)
            {
                Anim.SetBool("Is_Walk", true);
                Anim.SetBool("Is_Idle", false);

                Joystick.GetComponent<Joystick>().is_click = false;

                if (is_down && dir_right)
                {
                    is_down = false;
                    is_left = true;
                    dir_up = false;
                }
                else if (is_down && !dir_right)
                {
                    is_down = false;
                    is_right = true;
                    dir_up = false;
                }

                if (dir_up)
                {
                    dir_up = false;
                }
            }

            if (is_up && !is_mid && Joystick.GetComponent<Joystick>().is_click && Anim_End)
            {
                is_mid = true;
                P.GetComponent<JCharacterMovement>().moveSpeed = 0f;
                //transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f);

                Anim_End = false;

                Joystick.GetComponent<Joystick>().is_click = false;
            }
            else if (is_up && is_mid && Joystick.GetComponent<Joystick>().is_click && Anim_End)
            {
                //Anim.SetBool("Is_Mid", false);

                is_mid = false;
                is_up = false;
                is_down = true;

                P.GetComponent<JCharacterMovement>().moveSpeed = 5f;
                transform.position = new Vector3(transform.position.x, transform.position.y - 1f);

                Anim_End = false;

                Joystick.GetComponent<Joystick>().is_click = false;
            }
            else if (is_mid && !is_right && !is_left && Joystick.GetComponent<Joystick>().is_click && Anim_End)
            {
                //Anim.SetBool("Is_Mid", false);

                is_mid = false;
                P.GetComponent<JCharacterMovement>().moveSpeed = 5f;
                //transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f);

                Anim_End = false;

                Joystick.GetComponent<Joystick>().is_click = false;
            }


            if (is_down && is_jump && Joystick.GetComponent<Joystick>().is_click && Anim_End)
            {
                Anim.SetBool("Is_Jump", true);

                is_down = false;
                is_up = true;

                //transform.position = new Vector2(transform.position.x, transform.position.y - 1f);

                Anim_End = false;

                Joystick.GetComponent<Joystick>().is_click = false;
            }
        }

        else if (Hori < 0 && (-1 * Hori > Vert && Vert > Hori))
        {
            if ((is_up || is_down || is_side) && Joystick.GetComponent<Joystick>().is_click)
            {
                Anim.SetBool("Is_Walk", true);
                Anim.SetBool("Is_Idle", false);

                Joystick.GetComponent<Joystick>().is_click = false;

                if (is_left && dir_up)
                {
                    is_left = false;
                    is_down = true;
                    dir_right = false;
                }
                else if (is_left && !dir_up)
                {
                    is_left = false;
                    is_up = true;
                    dir_right = false;
                }

                if (dir_right)
                {
                    dir_right = false;
                }
            }

            if (is_right && !is_mid && Joystick.GetComponent<Joystick>().is_click && Anim_End)
            {
                is_mid = true;
                P.GetComponent<JCharacterMovement>().moveSpeed = 0f;
                //transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y);

                Anim_End = false;

                Joystick.GetComponent<Joystick>().is_click = false;
            }
            else if (is_right && is_mid && Joystick.GetComponent<Joystick>().is_click && Anim_End)
            {
                is_mid = false;
                is_right = false;
                is_left = true;

                P.GetComponent<JCharacterMovement>().moveSpeed = 5f;
                transform.position = new Vector3(transform.position.x - 1f, transform.position.y);

                Anim_End = false;

                Joystick.GetComponent<Joystick>().is_click = false;
            }
            else if (is_mid && !is_up && !is_down && Joystick.GetComponent<Joystick>().is_click && Anim_End)
            {
                is_mid = false;
                P.GetComponent<JCharacterMovement>().moveSpeed = 5f;
                //transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y);

                Anim_End = false;

                Joystick.GetComponent<Joystick>().is_click = false;
            }


            if (is_left && is_jump && Joystick.GetComponent<Joystick>().is_click && Anim_End)
            {
                Anim.SetBool("Is_Jump", true);

                is_left = false;
                is_right = true;

                //transform.position = new Vector2(transform.position.x - 1f, transform.position.y);

                Anim_End = false;

                Joystick.GetComponent<Joystick>().is_click = false;
            }
        }

        else if (Hori > 0 && (-1 * Hori < Vert && Vert < Hori))
        { 
            if ((is_up || is_down || is_side) && Joystick.GetComponent<Joystick>().is_click)
            {
                Anim.SetBool("Is_Walk", true);
                Anim.SetBool("Is_Idle", false);

                Joystick.GetComponent<Joystick>().is_click = false;

                if (is_right && dir_up)
                {
                    is_right = false;
                    is_down = true;
                    dir_right = true;
                }
                else if (is_right && !dir_up)
                {
                    is_right = false;
                    is_up = true;
                    dir_right = true;
                }

                if (!dir_right)
                {
                    dir_right = true;
                }
            }

            if (is_left && !is_mid && Joystick.GetComponent<Joystick>().is_click && Anim_End)
            {
                is_mid = true;

                P.GetComponent<JCharacterMovement>().moveSpeed = 0f;
                // transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y);

                Anim_End = false;

                Joystick.GetComponent<Joystick>().is_click = false;
            }
            else if (is_left && is_mid && Joystick.GetComponent<Joystick>().is_click && Anim_End)
            {
                is_mid = false;
                is_left = false;
                is_right = true;

                P.GetComponent<JCharacterMovement>().moveSpeed = 5f;
                transform.position = new Vector3(transform.position.x + 1f, transform.position.y);

                Anim_End = false;

                Joystick.GetComponent<Joystick>().is_click = false;
            }
            else if (is_mid && !is_up && !is_down && Joystick.GetComponent<Joystick>().is_click && Anim_End)
            {
                is_mid = false;
                P.GetComponent<JCharacterMovement>().moveSpeed = 5f;
                //transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y);

                Anim_End = false;

                Joystick.GetComponent<Joystick>().is_click = false;
            }

            if (is_right && is_jump && Joystick.GetComponent<Joystick>().is_click && Anim_End)
            {
                Anim.SetBool("Is_Jump", true);

                is_right = false;
                is_left = true;

                //transform.position = new Vector2(transform.position.x + 1f, transform.position.y);

                Anim_End = false;

                Joystick.GetComponent<Joystick>().is_click = false;
            }
        }
        else
        {
            Anim.SetBool("Is_Walk", false);
            Anim.SetBool("Is_Idle", true);
        }
    }


    public void TimeLineEvent()
    {
        Anim_End = true;
    }

    public void JumpEnd()
    {
        Anim.SetBool("Is_Jump", false);
        Anim_End = true;
    }
}