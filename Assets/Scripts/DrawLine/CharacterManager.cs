using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public float maxHP = 100f; // 최대 HP
    public float currentHP; // 현재 HP
    public float hpDecreaseRate = 1f; // HP 감소 속도


    private void Start()
    {
        UIM.Instance.SetActiveGameoverUI(false);
        currentHP = maxHP; // 시작 시 최대 HP로 초기화
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
        currentHP = Mathf.Clamp(currentHP, 0f, maxHP); // HP가 음수가 되지 않도록 클램프 처리
    }
}
