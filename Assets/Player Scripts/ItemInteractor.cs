using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractor : MonoBehaviour
{
    public Inventory inventory = new Inventory();

    int addBullet = 25;
    int addHealth = 25;

    // Start is called before the first frame update
    public void Start()
    {
        inventory.ItemUsed += playerUseItem;
        inventory.bulletItemUsed += playerUseBulletItem;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        IInventoryItem item = hit.gameObject.GetComponent<IInventoryItem>();
        if(item!=null)
        {
            Debug.Log("Hit Item has Component <IInventoryItem>");
            inventory.addItem(item); // where inventory is the inventory object ref
        }
    }

    private void playerUseBulletItem(object sender, InventoryEventArgs e)
    {
        if(e.item.itemName == "BulletBonus")
        {
            PlayerHandActions.currentBulletNum += addBullet; //no limit
        }
    }

    private void playerUseItem(object sender, InventoryEventArgs e)
    {
        if(e.item.itemName == "HealthBonus")
        {

            PlayerDamage.health += addHealth; 

            if(PlayerDamage.health >= 100)
            {
                PlayerDamage.health = 100;
            }
        }
        
    }
    
}
