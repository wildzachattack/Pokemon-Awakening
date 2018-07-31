using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightManager : MonoBehaviour
{
    private DisplayManager displayScript;

    void Awake()
    {
        displayScript = GetComponent<DisplayManager>();
    }
    public void FightButtonClick()
    {
        displayScript.cameraMode = 3;
        //Check action counter value, if zero, better hit & dam, auto waits unit
    }
}
