using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IInventoryItem
{
    string itemName { get; }
    Sprite itemImage { get; }
    void onPickup();

    // void fullItemDisableCollider();
    // void enableCollider();
    
}

public class InventoryEventArgs: EventArgs
{
    public InventoryEventArgs(IInventoryItem item)
    {
        this.item = item;
    }
    public IInventoryItem item;
}
