using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // required to use the Text class
using UnityEngine.EventSystems;

public class StopClickable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public static bool onButton;
    
    // public Button stopButton; 
    public TextMeshProUGUI buttonText;
    string btTxt;
    bool isStop = true;

    public void OnStopClicked()
    {
        
        Debug.Log("Stop Button Clicked");
        
        onButton = true;

        // if(stopButton.text == "Stop")
        // btTxt = buttonText.text;
        // if(btTxt == "Stop")
        if(isStop)
        {
            isStop = false; // show "play"
            buttonText.text = "Play";
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0; // Stop Game

        }
        else
        // if(btTxt == "Play")
        {
            isStop = true; // show "stop"
            buttonText.text = "Stop";
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1; // Start Game
        }
        
    }

    public void OnPointerEnter(PointerEventData eventData) // Ref: http://t.csdn.cn/b3Wbw
    {
        Debug.Log("Stop Button on");
        StopClickable.onButton = true; //for fire1 key click test
        
    }

    public void OnPointerExit(PointerEventData eventData) // Ref: http://t.csdn.cn/b3Wbw
    {
        StopClickable.onButton = false; //for fire1 key click test
    }

}
