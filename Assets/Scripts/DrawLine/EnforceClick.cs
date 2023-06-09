using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EnforceClick : MonoBehaviour
{
    public Text EnforceHpTxt;
    public Text EnforceFeverTxt;
    public Text EnforceTrasureMapTxt;

    public Text NeedHpCost;
    public Text NeedFeverCost;
    public Text NeedTrasureMapCost;

    public Text Coin;

    public Button HpEnforce;
    public Button FeverEnforce;
    public Button TrasureMapEnforce;

    private DataManager DM;

    private OptionButton PRB_OB;

    void Start()
    {
        PRB_OB = GameObject.Find("PlayReadyButton").GetComponent<OptionButton>();
        DM = DataManager.Instance;
        LoadText();
    }

    void Update()
    {
        InteractableButton();
        LoadText();
    }

    void LoadText()
    {
        EnforceHpTxt.text = "LV. " + DM.charStat.Hp;
        EnforceFeverTxt.text = "LV. " + DM.charStat.FeverTime;
        EnforceTrasureMapTxt.text = "LV. " + DM.charStat.TrasureMap;

        NeedHpCost.text = DM.HP_List[DM.charStat.Hp]["Cost"].ToString();
        NeedFeverCost.text = DM.Fever_List[DM.charStat.FeverTime]["Cost"].ToString();
        NeedTrasureMapCost.text = DM.TrasureMap_List[DM.charStat.TrasureMap]["Cost"].ToString();

        Coin.text = DM.charStat.Coin.ToString();
    }

    void InteractableButton()
    {
        if (DM.charStat.Coin < int.Parse(DM.HP_List[DM.charStat.Hp]["Cost"].ToString()))
        {
            HpEnforce.interactable = false;
        }
        else
        {
            HpEnforce.interactable = true;
        }

        if (DM.charStat.Coin < int.Parse(DM.Fever_List[DM.charStat.FeverTime]["Cost"].ToString()))
        {
            FeverEnforce.interactable = false;
        }
        else
        {
            FeverEnforce.interactable = true;
        }

        if (DM.charStat.Coin < int.Parse(DM.TrasureMap_List[DM.charStat.TrasureMap]["Cost"].ToString()))
        {
            TrasureMapEnforce.interactable = false;
        }
        else
        {
            TrasureMapEnforce.interactable = true;
        }
    }

    public void HpOnClick()
    {
        Debug.Log("Click HP");
        DM.charStat.Coin -= int.Parse(DM.HP_List[DM.charStat.Hp]["Cost"].ToString());
        DM.charStat.Hp++;
        DM.SaveJson();
    }

    public void FeverOnClick()
    {
        Debug.Log("Click Fever");
        DM.charStat.Coin -= int.Parse(DM.Fever_List[DM.charStat.FeverTime]["Cost"].ToString());
        DM.charStat.FeverTime++;
    }

    public void TrasureMapOnClick()
    {
        Debug.Log("Click Trasure");
        DM.charStat.Coin -= int.Parse(DM.TrasureMap_List[DM.charStat.TrasureMap]["Cost"].ToString());
        DM.charStat.TrasureMap++;
    }

    public void BackOnClick()
    {
        PRB_OB.OnClick();
    }

    public void GameStartOnClick()
    {
        SceneManager.LoadScene("MapCreating");
    }
}
