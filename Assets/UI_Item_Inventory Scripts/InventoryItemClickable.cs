using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // required to use the Text class
using UnityEngine.EventSystems;

public class InventoryItemClickable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler // For check On Pointer
{
    public IInventoryItem item;
    public Inventory inventory;

    public static bool onButton;

    // Full Health Cannot Use Health Item Tip
    public TextMeshProUGUI fullHealthTip;
    
    public void OnItemClicked()
    {
        if (item != null)
        {
            Debug.Log("Using: " + item.itemName);

            if(item.itemName == "BulletBonus")
            {
                inventory.useBulletItem(item);
            }
            
            if(item.itemName == "HealthBonus")
            {    
                if(PlayerDamage.health < 100)
                {
                    inventory.useItem(item);
                }
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData) // Ref: http://t.csdn.cn/b3Wbw
    {
        Debug.Log("InventoryItemClickable Button on");

        InventoryItemClickable.onButton = true; //for fire1 key click test

        if(item.itemName == "HealthBonus")
        {   
            if(PlayerDamage.health >= 100)
            {
                fullHealthTip.color = Color.red; 
                fullHealthTip.text = "Full Health Can't Use Health Items";
            }
        }
        
    }

    public void OnPointerExit(PointerEventData eventData) // Ref: http://t.csdn.cn/b3Wbw
    {
        InventoryItemClickable.onButton = false; //for fire1 key click test

        fullHealthTip.text = "";
    }

}
