using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoorSwitch : MonoBehaviour
{
    public Door doorObject;
    int enemyTotalNum; 
    public static bool winOpenDoor;
    
    private void OnTriggerEnter(Collider other)
    {
        FinalDoorSwitch.winOpenDoor = false;

        enemyTotalNum = GameObject.FindObjectsOfType<Cor_Destroyable>().Length + GameObject.FindObjectsOfType<Ene_Destroyable>().Length + GameObject.FindObjectsOfType<Tea_Destroyable>().Length; 
        
        if(other.gameObject.tag == "RealKey")
        {
            if(enemyTotalNum == 0)
            {
                // Debug.Log("enter trigger");
                doorObject.Open();
                FinalDoorSwitch.winOpenDoor = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "RealKey")
        {
            // Debug.Log("exit trigger");
            doorObject.Close();
        }
    }
}
