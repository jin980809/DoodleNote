using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using static UnityEditor.Progress;

public class AccessoryInventory : MonoBehaviour
{
    [SerializeField]
    private List<AccessoryItem> _accessoryItemList;

    [SerializeField]
    private GameObject _startItemPrefab;

    private int _currentItemIndex;

    void Start()
    {    
        int count = DataManager1.p_DataManager1._saveData._saveAccessoryItemID.Count;

        if (count >= 1)
        {
            for (int i = 0; i < count; ++i)
            {
                AccessoryItem item = InventoryItemInstanceManager.p_ItemManager.GetAccessory(DataManager1.p_DataManager1._saveData._saveAccessoryItemID[i]);

                if (item != null && !_accessoryItemList.Find(element => element.p_ItemSprite == item.p_ItemSprite))
                {
                    _accessoryItemList.Add(item);
                    UIManager.p_UIManager.GetInventoryPanel().AddItemSlot(item);                  
                }
            }
        }
        else
        {
            var item = Instantiate(_startItemPrefab);
            _accessoryItemList.Add(item.GetComponent<AccessoryItem>());
            UIManager.p_UIManager.GetInventoryPanel().AddItemSlot(item.GetComponent<AccessoryItem>());
        }
    }

    private void Awake()
    {   
       
    }

    void Update()
    {
        
    }

    public AccessoryItem GetCurrentItem()
    {
        if (_accessoryItemList[_currentItemIndex] != null)
        {
            return _accessoryItemList[_currentItemIndex];
        }

        return null;     
    }

    public List<AccessoryItem> GetAllItems()
    {    
        return _accessoryItemList;
    }

    public void AddItem(AccessoryItem NewItem)
    {
        if (_accessoryItemList.Find(element => element == NewItem) == null)
        {
            _accessoryItemList.Add(NewItem);
            UIManager.p_UIManager.GetInventoryPanel().AddItemSlot(NewItem);
        }
        else
        {
            //Already Included
        }
    }

    public int p_CurrentItemIndex
    {
        get
        {
            return _currentItemIndex;
        }
        set
        {
            _currentItemIndex = value;
        }
    }
}
