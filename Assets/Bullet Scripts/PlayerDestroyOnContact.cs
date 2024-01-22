using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroyOnContact : MonoBehaviour
{
    List<string> notDesList;

    void Start()
    {
        // notDesList = new List<string>();
        // // notDesList.Add("EnemyBullet");
        // // notDesList.Add("TeacherBullet");
        // notDesList.Add("PlayerBullet");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("PlayerBullet --> Enemy");
        }

        // destroy this object
        if (collision.gameObject.tag != "PlayerBullet")
        // if (!notDesList.Contains(collision.gameObject.tag))
        {
            DestroyObject(gameObject);
        }
    }
}
