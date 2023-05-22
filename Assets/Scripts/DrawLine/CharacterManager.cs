using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public float maxHP = 100f; // �ִ� HP
    public float currentHP; // ���� HP
    public float hpDecreaseRate = 1f; // HP ���� �ӵ�


    private void Start()
    {
        UIM.Instance.SetActiveGameoverUI(false);
        currentHP = maxHP; // ���� �� �ִ� HP�� �ʱ�ȭ
    }

    private void Update()
    {
        DecreaseHPOverTime();
        UIM.Instance.UpdateHPBar(currentHP, maxHP);


        if (currentHP <= 0)
        {
            Game.Instance.CharacterDead();
        }
    }

    private void DecreaseHPOverTime()
    {
        float hpDecreaseAmount = hpDecreaseRate * Time.deltaTime;
        currentHP -= hpDecreaseAmount;
        currentHP = Mathf.Clamp(currentHP, 0f, maxHP); // HP�� ������ ���� �ʵ��� Ŭ���� ó��
    }
}
