using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using TMPro; // required to use the Text class
using UnityEngine.UI;

public class Ene_Destroyable : MonoBehaviour
{
    // For Time Bonus
    GameController gameController; 

    //Damage System
    public Slider healthBar;

    // For Seperate Enemy Health
    public EnemyHealth enemyHealth;

    
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

    // Update is called once per frame
    void Update()
    {
        //Health: Bar
        healthBar.maxValue = 100.0f;
        healthBar.minValue = 0.0f;

        if(enemyHealth.health <= 0)
        {
            healthBar.value = 0;
        }
        else
        {
            healthBar.value = enemyHealth.health; 
        }
    }

    public int timeBonus = 10;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            Debug.Log("Ene damage - 25");
            enemyHealth.health -= 25; 

            if(enemyHealth.health <= 0)
            {
                DestroyObject(gameObject);
            }
        }
    }
    private void OnDestroy()
    {
        // tell the game controller
        if (gameController != null)
        {
            gameController.TargetDestroyed(timeBonus);
        }
    }
}
