using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemSlot : MonoBehaviour
{
    public delegate void FClickButtonSignature(InventoryItemSlot itemSlot);
    public FClickButtonSignature _FOnClickButton;

    [SerializeField]
    private Image _itemImage;

    [SerializeField]
    private Sprite _characterSprite;

    [SerializeField]
    private Image _slotBackGround;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Click()
    {
        _FOnClickButton(this);
    }

    public void SelectItemSlot()
    {
        _slotBackGround.color = new Color(255.0f, 255.0f, 255.0f, 0.4f);
    }

    public void UnSelectItemSlot()
    {
        _slotBackGround.color = new Color(255.0f, 255.0f, 255.0f, 0.0f);
    }

    public Image p_ItemImage
    {
        get
        {
            return _itemImage;
        }
        set
        {
            _itemImage = value;
        }
    }

    public Sprite p_CharacterSprite
    {
        get
        {
            return _characterSprite;
        }
        set
        {
            _characterSprite = value;
        }
    }
}
