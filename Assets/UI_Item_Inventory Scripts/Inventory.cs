using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    List<IInventoryItem> items = new List<IInventoryItem>();

    public event EventHandler<InventoryEventArgs> ItemAdded;
    public event EventHandler<InventoryEventArgs> ItemUsed;
    public event EventHandler<InventoryEventArgs> bulletItemUsed;

    private int itemNumLimit = 7;
    // add a var to make code more clear
    private int currentItemNum = 0;

    public void addItem(IInventoryItem item)
    {
        if(currentItemNum < itemNumLimit)
        {
            Debug.Log("inventory adding Item");

            items.Add(item);
            currentItemNum += 1; 

            item.onPickup();

            // broadcast event to hud
            if (ItemAdded != null)
            {
                ItemAdded.Invoke(this, new InventoryEventArgs(item));
            }
        }
        else
        {
            Debug.Log("! NO inventory remain: CANNOT add Item now");
        }
        
    }

    public void useItem(IInventoryItem item)
    {
        if(items.Contains(item) && currentItemNum > 0)
        {
            items.Remove(item);
            currentItemNum -= 1; 

            if (ItemUsed != null)
            {
                ItemUsed.Invoke(this, new InventoryEventArgs(item));
            }
        }
    }

    public void useBulletItem(IInventoryItem item)
    {
        if(items.Contains(item) && currentItemNum > 0)
        {
            items.Remove(item);
            currentItemNum -= 1; 

            if (bulletItemUsed != null)
            {
                bulletItemUsed.Invoke(this, new InventoryEventArgs(item));
            }
        }
    }

}
