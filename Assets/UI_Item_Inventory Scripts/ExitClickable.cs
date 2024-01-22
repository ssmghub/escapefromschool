using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExitClickable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static bool onButton;

    public void OnExitClicked()
    {
        Debug.Log ("Exit Button Clicked");

        Application.Quit(); // Ref: https://stackoverflow.com/questions/30235248/quitapplication-button-on-unity
        
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void OnPointerEnter(PointerEventData eventData) // Ref: http://t.csdn.cn/b3Wbw
    {
        Debug.Log("Exit Button on");
        ExitClickable.onButton = true; //for fire1 key click test
        
    }

    public void OnPointerExit(PointerEventData eventData) // Ref: http://t.csdn.cn/b3Wbw
    {
        ExitClickable.onButton = false; //for fire1 key click test
    }
}
