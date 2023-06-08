using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AccessoryItem : MonoBehaviour
{
    [SerializeField]
    private Sprite _itemImage;

    [SerializeField]
    private Sprite _characterImage;

    [SerializeField]
    private Animator _animator;

    [SerializeField]
    public int _itemID;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public Sprite p_ItemSprite
    {
        get
        {
            return _itemImage;
        }
        private set
        {
        }
    }
    public Sprite p_CharacterSprite
    {
        get
        {
            return _characterImage;
        }
        private set
        {
        }
    }

    public Animator p_Animator
    {
        get
        {
            return _animator;
        }
        private set
        {
        }
    }
}
