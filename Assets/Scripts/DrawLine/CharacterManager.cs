using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<CharacterManager>();
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

    private static CharacterManager m_instance;


    public float maxHP = 100f; // �ִ� HP
    public float currentHP; // ���� HP
    public float hpDecreaseRate = 2f; // HP ���� �ӵ�

    public float maxFever = 1200f; 
    public float currentFever; 

    public bool is_Up = true;

    [SerializeField] private GameObject Character;

    public int Score = 0;

    public StringBuilder Line_tag;

    public enum ColorState
    {
        Origin = 0,
        Red = 1,
        Yellow = 2,
        Blue = 3
    };

    public ColorState _ColorState { get; set; }

    public ColorState currentColor;

    private void Start()
    {
        UIM.Instance.SetActiveGameoverUI(false);
        currentHP = maxHP; // ���� �� �ִ� HP�� �ʱ�ȭ
        Line_tag = new StringBuilder(System.Enum.GetName(typeof(CharacterColorState.ColorState), 0)); // ���� �߻� �� ���ڿ��� ��ųʸ��� ĳ���Ͽ� ����ϱ�
        Line_tag.Append("Line");
    }

    private void Update()
    {
        DecreaseHPOverTime();
        UIM.Instance.UpdateHPBar(currentHP, maxHP);
        UIM.Instance.UpdateFeverBar(currentFever, maxFever);

        if (currentHP <= 0)
        {
            Game.Instance.CharacterDead();
        }

        ColorChange();

        UIM.Instance.UpdateScoreText(Score);

        if(currentFever >= maxFever)
        {
            currentFever = 0f;
            //GoFeverScene(); // �ǹ��������� �� ���� �ǹ� ������ �̵�
        }

        //Debug.Log(Line_tag);
    }

    private void DecreaseHPOverTime()
    {
        float hpDecreaseAmount = hpDecreaseRate * Time.deltaTime;
        currentHP -= hpDecreaseAmount;
        currentHP = Mathf.Clamp(currentHP, 0f, maxHP); // HP�� ������ ���� �ʵ��� Ŭ���� ó��
    }


    private void ColorChange()
    {
        switch (currentColor)
        {
            case ColorState.Origin:
                Character.transform.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, 1);
                make_Linetag(0);
                break;

            case ColorState.Red:
                Character.transform.GetComponent<SpriteRenderer>().material.color = new Color(1, 0.7568628f, 0.7411765f, 1);
                make_Linetag(1);
                break;

            case ColorState.Yellow:
                Character.transform.GetComponent<SpriteRenderer>().material.color = new Color(1, 0.9764706f, 0.8196079f, 1);
                make_Linetag(2);
                break;

            case ColorState.Blue:
                Character.transform.GetComponent<SpriteRenderer>().material.color = new Color(0.654902f, 0.7098039f, 1, 1);
                make_Linetag(3);
                break;
        }
    }

    private void make_Linetag(int index)
    {
        Line_tag = new StringBuilder(System.Enum.GetName(typeof(CharacterManager.ColorState), index)); // ���� �߻� �� ���ڿ��� ��ųʸ��� ĳ���Ͽ� ����ϱ�
        Line_tag.Append("Line");
    }

    private void GoFeverScene()
    {

    }

    public IEnumerator ReturnColorState()
    {
        yield return new WaitForSeconds(5f);
        currentColor = ColorState.Origin;
    }
}
