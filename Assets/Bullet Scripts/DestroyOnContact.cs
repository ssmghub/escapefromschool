using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour
{
    List<string> notDesList;

    void Start()
    {
        notDesList = new List<string>();
        notDesList.Add("EnemyBullet");
        notDesList.Add("TeacherBullet");
        // notDesList.Add("PlayerBullet");
        notDesList.Add("Enemy");
    }


    private void OnCollisionEnter(Collision collision)
    {
        // if(collision.gameObject.tag != "Enemy" || collision.gameObject.tag != "EnemyBullet")
        if (!notDesList.Contains(collision.gameObject.tag))
        {
            DestroyObject(gameObject);
        }
    }
}
