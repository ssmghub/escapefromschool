using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private IEnumerator DoorAnimation(int targetAngle)
    {
        float originalAngle = transform.localEulerAngles.y;
        for (float r = 0.0f; r < 1.0f; r += 0.01f)
        {
            transform.localEulerAngles = new Vector3(0,
            // Mathf.LerpAngle(originalAngle, targetAngle, 5f/animationSpeed), 0);
            //help to gave a smooth movement: 0...50-->implement 插值
            Mathf.LerpAngle(originalAngle, targetAngle, r), 0);

            yield return null;
        }
    }

    public void Open()
    {
        Debug.Log("opening door");
        StartCoroutine(DoorAnimation(90));
    }
    public void Close()
    {
        Debug.Log("closing door");
        StartCoroutine(DoorAnimation(0));
    }
}
