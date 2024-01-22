using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public Door doorObject;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "RealKey")
        {
            // Debug.Log("enter trigger");
            doorObject.Open();
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
