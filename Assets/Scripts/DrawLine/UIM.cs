using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// 필요한 UI에 즉시 접근하고 변경할 수 있도록 허용하는 UI 매니저
public class UIM : MonoBehaviour
{
    // 싱글톤 접근용 프로퍼티
    public static UIM Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<UIM>();
            }

            return m_instance;
        }
    }

    private static UIM m_instance;


    public Text scoreText; // 점수 표시용 텍스트
    public GameObject gameoverUI; // 게임 오버시 활성화할 UI 
    public Image hpBar; // HP를 표시할 UI의 Image 컴포넌트

    // 점수 텍스트 갱신
    public void UpdateScoreText(int newScore)
    {
        scoreText.text = "Score : " + newScore;
    }

    // 게임 오버 UI 활성화
    public void SetActiveGameoverUI(bool active)
    {
        gameoverUI.SetActive(active);
    }

    public void UpdateHPBar(float currentHP, float maxHP)
    {
        float fillAmount = currentHP / maxHP;
        hpBar.fillAmount = fillAmount;
    }
}