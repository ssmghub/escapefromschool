using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // required to use the Text class
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartClickable : MonoBehaviour
{
    public void loadSchool(int currentSceneIndex)
    {
        Debug.Log("Start Button Clicked");

        SceneManager.LoadScene(currentSceneIndex);
    }
}
