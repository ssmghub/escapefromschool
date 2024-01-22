using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudItemActions : MonoBehaviour
{
    public Inventory inventory = new Inventory();

    // Start is called before the first frame update
    void Start()
    {
        inventory.ItemAdded += InventoryItemAdded;
        inventory.ItemUsed += InventoryItemUsed;

        inventory.bulletItemUsed += InventoryItemUsed;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InventoryItemAdded(object sender, InventoryEventArgs e)
    {
        Debug.Log("subscribing ItemAdded()");

        Transform panel = transform.Find("InventoryHud/");
        foreach(Transform slot in panel)
        {
            Image image = slot.GetComponent<Image>();

            InventoryItemClickable button = slot.GetComponent<InventoryItemClickable>();
            
            if (image.sprite==null || !image.enabled)
            // if (!image.enabled)
            {
                image.enabled = true;
                image.sprite = e.item.itemImage;
                button.item = e.item;
                break;
            }
        }
    }

     private void InventoryItemUsed(object sender, InventoryEventArgs e)
    {
        Debug.Log("subscribing ItemUsed()");

        Transform panel = transform.Find("InventoryHud/");
        
        foreach(Transform slot in panel)
        {
            Image image = slot.GetComponent<Image>();

            InventoryItemClickable button = slot.GetComponent<InventoryItemClickable>();
            if(button.item == e.item)
            {
                if (image.sprite!=null || image.enabled)
                {
                    image.enabled = false;
                    button.item = null;
                    break;
                }
            }
        }
    }
}
