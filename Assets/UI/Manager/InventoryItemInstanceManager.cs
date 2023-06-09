using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemInstanceManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _InventoryItemInstanceList;

    void Start()
    {

    }

    private void Awake()
    {
        if(ItemInstanceManager == null)
        {
            ItemInstanceManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public AccessoryItem GetAccessory(int itemID)
    {
        var itemElement = _InventoryItemInstanceList.Find(element => element.GetComponent<AccessoryItem>()._itemID == itemID);

        if(itemElement != null)
        {
            return itemElement.GetComponent<AccessoryItem>();
        }

        return null;
    }

    public static InventoryItemInstanceManager p_ItemManager
    {
        get
        {
            return ItemInstanceManager;
        }
        set
        {
            ItemInstanceManager = value;
        }
    }

    public static InventoryItemInstanceManager ItemInstanceManager;
}
