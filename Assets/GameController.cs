using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public float timeLeftMin = 10.0f;
    public float timeLeftSec = 1.0f;
    int timeLeftMinPart = 0;
    int timeLeftSecPart = 0;
    float timeLeft = 0; // timeLeft = timeLeftMin * 60;

    string timeLeftMinPartTxt;
    string timeLeftSecPartTxt;

    // the Text element on the Canvas
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI bulletText;
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI enemyText;
    public TextMeshProUGUI gunsigntText;

    public TextMeshProUGUI playerHealthText;
    public Slider playerHealthBar;


    //For Centre Exit Button Display after Game Over or Time Out
    public Button exitButton; 
    public TextMeshProUGUI exitBtText;
    //Middle Button
    public Button midStopButton; 
    public TextMeshProUGUI midStopBtText;
    public Button midExitButton; 
    public TextMeshProUGUI midExitBtText;

    public void notMiddleBtDisplay()
    {
        // Middle Stop&Exit Button Not Display During Game
        midStopButton.image.enabled = false;
        midStopBtText.enabled = false;
        midExitButton.image.enabled = false;
        midExitBtText.enabled = false;
    }

    public void isExitBtDisplay()
    {
        // Exit Button Display
        exitButton.image.enabled = true;
        exitBtText.enabled = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void notExitBtDisplay()
    {
        // Exit Button Not Display During Game
        exitButton.image.enabled = false;
        exitBtText.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
    }



    // Start is called before the first frame update
    void Start()
    {
        // // always show Middle Buttons during game
        // isMiddleBtDisplay();

        // Exit Button won't show furing game play
        notExitBtDisplay();

        timeLeft = timeLeftMin * 60 + timeLeftSec; 
    }


    int enemyTotalNum; 
    float playerHealthBarNum;


    // Update is called once per frame
    void Update()
    {
        //Time Calculation
        timeLeft -= Time.deltaTime;
        timeCalculateSec();
        timeCalculateMin();

        //enemyNum
        enemyTotalNum = GameObject.FindObjectsOfType<Ene_Destroyable>().Length + GameObject.FindObjectsOfType<Tea_Destroyable>().Length + GameObject.FindObjectsOfType<Cor_Destroyable>().Length; 
        enemyText.text = "Enemy Number:  " + enemyTotalNum.ToString("0"); 
        
        //bulletNum
        bulletText.text = "Bullet Number:  " + PlayerHandActions.currentBulletNum.ToString("0"); 

        if(PlayerHandActions.currentBulletNum == 0)
        {
            bulletText.color = Color.red;
        }
        else
        {
            bulletText.color = Color.white;
        }

        //PlayerHealth: Bar
        playerHealthBar.maxValue = 100.0f;
        playerHealthBar.minValue = 0.0f;

        playerHealthBarNum = PlayerDamage.health; 

        if(playerHealthBarNum <= 0)
        {
            playerHealthBar.value = 0;
            playerHealthText.color = Color.red; 
            playerHealthText.text = "Your Health:  0 / 100"; 
        }
        else
        {
            playerHealthBar.value = playerHealthBarNum; 
            playerHealthText.color = Color.white; 
            //PlayerHealth: Text
            playerHealthText.text = "Your Health:  " + playerHealthBarNum.ToString("0") + " / 100"; 
        }

        
        if (timeLeft > 0)
        {
            timeText.text = "Time:  " + timeLeftMinPartTxt + ":" + timeLeftSecPartTxt;

            // When All Enemy Clear --> Win this Game: 
            if(playerHealthBarNum > 0)
            {
                if(enemyTotalNum == 0 && FinalDoorSwitch.winOpenDoor) //door open and clear enemy to win the game
                {
                    YouWin();
                }
            }
            else
            {
                GameOver();
            }
        }
        else
        {
            if(playerHealthBarNum > 0)
            {
                if(enemyTotalNum == 0 && FinalDoorSwitch.winOpenDoor) //door open and clear enemy to win the game
                {
                    WinTimeOut();
                }
            }
            else
            {
                GameOver();
            }
        }

    }

    // Time Form: 00:00
    void timeCalculateSec()
    {
        timeLeftSecPart = (int)(timeLeft) % 60;

        if(timeLeftSecPart >= 10)
        {
            // format to a string with no decimal places
            timeLeftSecPartTxt = timeLeftSecPart.ToString("0");
        }
        else
        {
            timeLeftSecPartTxt = "0" + timeLeftSecPart.ToString("0");
        }
    }

    void timeCalculateMin()
    {
        timeLeftMinPart = (int)timeLeft / 60;

        if(timeLeftMinPart <= 9)
        {
            timeLeftMinPartTxt = "0" + timeLeftMinPart.ToString("0");
        }
        else
        {
            timeLeftMinPartTxt = timeLeftMinPart.ToString("0");
        }
    }

    void YouWin()
    {
        resultText.text = "You Win!"; 
        gunsigntText.text = " ";

        Time.timeScale = 1;

        // Show Button for Exit Game
        notMiddleBtDisplay();
        isExitBtDisplay();
    }

    void WinTimeOut()
    {
        resultText.text = "Time Out"; 
        gunsigntText.text = " ";
        // Stop Game
        Time.timeScale = 0; // Ref: http://t.csdn.cn/Uihp2
        
        // Show Button for Exit Game
        notMiddleBtDisplay();
        isExitBtDisplay();
    }

    void GameOver()
    {
        timeText.color = Color.red;
        timeText.text = "Time:  00:00";

        resultText.color = Color.red;
        resultText.text = "Game Over";

        gunsigntText.text = " ";

        // Stop Game
        Time.timeScale = 0; // Ref: http://t.csdn.cn/Uihp2
        
        // Show Button for Exit Game
        notMiddleBtDisplay();
        isExitBtDisplay();
    }

    // Time Bonus
    public void TargetDestroyed(int timeBonus)
    {
        timeLeft += timeBonus;
        if(timeText.color == Color.white || timeText.color == Color.blue)
        {
            timeText.color = Color.yellow; // help tell people add Time Bonus(turn Yellow or Blue)
        }
        else
        {
            timeText.color = Color.blue; // help tell people add Time Bonus(turn Yellow or Blue)
        }
    }

}