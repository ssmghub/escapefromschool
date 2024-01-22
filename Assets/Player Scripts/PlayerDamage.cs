using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    GameController gameController; 

    public static int health = 100; //Ref: http://t.csdn.cn/pdhoL

    
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            PlayerDamage.health -= 3; 
        }
        if (collision.gameObject.tag == "TeacherBullet")
        {
            PlayerDamage.health -= 7; 
        }
    }

}
