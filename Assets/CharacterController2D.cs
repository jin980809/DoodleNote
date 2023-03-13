using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float moveDist = 1f;

    public bool is_up = true;     // ĳ���Ͱ� ���� ���� ������
    public bool is_down = false;  // ĳ���Ͱ� ���� �Ʒ��� ������
    public bool is_right = false; // ĳ���Ͱ� ���� �����ʿ� ������
    public bool is_left = false;  // ĳ���Ͱ� ���� ���ʿ� ������

    public bool dir_up = false;    // true�̸� ���� ������ ���϶�, false�̸� ���� ������ �Ʒ��϶�
    public bool dir_right = true; // true�̸� ��������� �������϶�, false�̸� ���� ������ �����϶�

    public bool is_fall;
    public bool is_side = false;

    public bool is_mid = false;
    public bool is_jump = false;

    // ��ĭ�� �̵��ϴ� �� ���� o 
    // ���� �ִ� bool������ ����� ������ �����̼� �־��ֱ� o
    // ���̵� ���� �� ���̵� �������� ���� ��ȯ o 
    // ������ ���� o
    // �� ���θ��� ���� 1 ~ 3 ���� o


    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (is_left || is_right || is_side)
            {
                if (!is_fall)
                    transform.position = new Vector2(transform.position.x, transform.position.y + moveDist);

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

            if (is_down && !is_mid)
            {
                is_mid = true;
                moveDist = 0f;
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f);
            }
            else if (is_down && is_mid)
            {
                is_mid = false;
                is_down = false;
                is_up = true;
                moveDist = 1f;
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f);
            }
            else if (is_mid && !is_right && !is_left)
            {
                is_mid = false;
                moveDist = 1f;
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f);
            }

            if(is_up && is_jump)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + moveDist);
                is_up = false;
                is_down = true;
            }

        }

        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (is_left || is_right || is_side)
            {
                if (!is_fall)
                    transform.position = new Vector3(transform.position.x, transform.position.y - moveDist);

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

            if (is_up && !is_mid)
            {
                is_mid = true;
                moveDist = 0f;
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f);
            }
            else if (is_up && is_mid)
            {
                is_mid = false;
                is_up = false;
                is_down = true;
                moveDist = 1f;
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f);
            }
            else if (is_mid && !is_right && !is_left)
            {
                is_mid = false;
                moveDist = 1f;
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f);
            }

            if (is_down && is_jump)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - moveDist);
                is_down = false;
                is_up = true;
            }
        }

        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (is_up || is_down || is_side)
            {
                if (!is_fall)
                    transform.position = new Vector3(transform.position.x - moveDist, transform.position.y);

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

            if (is_right && !is_mid)
            {
                is_mid = true;
                moveDist = 0f;
                transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y);
            }
            else if (is_right && is_mid)
            {
                is_mid = false;
                is_right = false;
                is_left = true;
                moveDist = 1f;
                transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y);
            }
            else if (is_mid && !is_up && !is_down)
            {
                is_mid = false;
                moveDist = 1f;
                transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y);
            }


            if (is_left && is_jump)
            {
                transform.position = new Vector2(transform.position.x - moveDist, transform.position.y);
                is_left = false;
                is_right = true;
            }
        }

        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (is_up || is_down || is_side)
            {
                if (!is_fall)
                    transform.position = new Vector3(transform.position.x + moveDist, transform.position.y);

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

            if (is_left && !is_mid)
            {
                is_mid = true;
                moveDist = 0f;
                transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y);
            }
            else if (is_left && is_mid)
            {
                is_mid = false;
                is_left = false;
                is_right = true;
                moveDist = 1f;
                transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y);
            }
            else if (is_mid && !is_up && !is_down)
            {
                is_mid = false;
                moveDist = 1f;
                transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y);
            }

            if (is_right && is_jump)
            {
                transform.position = new Vector2(transform.position.x + moveDist, transform.position.y);
                is_right = false;
                is_left = true;
            }
        }
    }
}


