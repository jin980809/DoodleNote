using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AccessoryInventoryPanel : MonoBehaviour
{
    [SerializeField]
    private List<InventoryItemSlot> _accessoryItemSlotList;

    [SerializeField]
    private Transform _itemPanel;

    [SerializeField]
    private GameObject _itemSlotInstance;

    [SerializeField]
    private GameObject _customizingCharacter;

    [SerializeField]
    private Transform _inventory;

    private int _currentItemSlotIndex = 0;

    void Start()
    {
        UIManager.p_UIManager.p_AccessoryInventoryPanel = this;
    }

    private void Awake()
    {
    }

    public void AddItemSlot(AccessoryItem NewItem)
    {
        Debug.Log(_accessoryItemSlotList);

        if (!_accessoryItemSlotList.Find(element => element.transform.GetChild(2).GetComponent<Image>().sprite == NewItem.p_ItemSprite))
        {
            var itemSlot = Instantiate(_itemSlotInstance, _itemPanel);

            itemSlot.GetComponent<InventoryItemSlot>()._FOnClickButton = OnClickButton;

            itemSlot.transform.GetChild(2).GetComponent<Image>().sprite = NewItem.p_ItemSprite;
            itemSlot.GetComponent<InventoryItemSlot>().p_CharacterSprite = NewItem.p_CharacterSprite;
            _accessoryItemSlotList.Add(itemSlot.GetComponent<InventoryItemSlot>());

            _accessoryItemSlotList[_currentItemSlotIndex].SelectItemSlot();
            _accessoryItemSlotList[_currentItemSlotIndex]._FOnClickButton = OnClickButton;
        }
    }

    public void OnClickButton(InventoryItemSlot itemSlot)
    {
        if(_accessoryItemSlotList[_currentItemSlotIndex] == itemSlot)
        {
            return;
        }
        else
        {
            _accessoryItemSlotList[_currentItemSlotIndex].UnSelectItemSlot();
            _accessoryItemSlotList[_currentItemSlotIndex] = itemSlot;
            _accessoryItemSlotList[_currentItemSlotIndex].SelectItemSlot();
        }
    }

    public void OnClickApplyButton()
    {
        _customizingCharacter.GetComponent<Image>().sprite = _accessoryItemSlotList[_currentItemSlotIndex].p_CharacterSprite;
        _inventory.GetComponent<AccessoryInventory>().p_CurrentItemIndex = _currentItemSlotIndex;
    }

    public void OnClickExitButton()
    {
        UIManager.p_UIManager.InventoryUnActivate();
    }
}
