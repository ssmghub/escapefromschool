using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackSwitch : MonoBehaviour
{
    public Door doorObject;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            // Debug.Log("enter trigger");
            doorObject.Open();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            // Debug.Log("exit trigger");
            doorObject.Close();
        }
    }
}
