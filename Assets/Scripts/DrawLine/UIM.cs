using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// �ʿ��� UI�� ��� �����ϰ� ������ �� �ֵ��� ����ϴ� UI �Ŵ���
public class UIM : MonoBehaviour
{
    // �̱��� ���ٿ� ������Ƽ
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


    public Text scoreText; // ���� ǥ�ÿ� �ؽ�Ʈ
    public GameObject gameoverUI; // ���� ������ Ȱ��ȭ�� UI 
    public Image hpBar; // HP�� ǥ���� UI�� Image ������Ʈ

    // ���� �ؽ�Ʈ ����
    public void UpdateScoreText(int newScore)
    {
        scoreText.text = "Score : " + newScore;
    }

    // ���� ���� UI Ȱ��ȭ
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