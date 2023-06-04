using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIM : MonoBehaviour
{
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

    private void Awake()
    {
        if (m_instance != null && m_instance != this)
        {
            Destroy(gameObject);
            return;
        }

        m_instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private static UIM m_instance;

    public Text scoreText;
    public GameObject gameoverUI;
    public Image hpBar;
    public Image feverBar;

    public void SetActiveGameoverUI(bool active)
    {
        gameoverUI.SetActive(active);
    }

    public void UpdateScoreText(int newScore)
    {
        scoreText.text = "Score : " + newScore;
    }

    public void UpdateHPBar(float currentHP, float maxHP)
    {
        float fillAmount = currentHP / maxHP;
        hpBar.fillAmount = fillAmount;
    }

    public void UpdateFeverBar(float currentFever, float maxFeverScore)
    {
        float fillAmount = currentFever / maxFeverScore;
        feverBar.fillAmount = fillAmount;
    }
}