using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ActionManager : MonoBehaviour
{
    private DisplayManager displayScript;

    private void Awake()
    {
        displayScript = GetComponent<DisplayManager>();
    }
    public void ResumeButton()
    {
        displayScript.cameraMode = 0;
    }
    public void PokedexButton()
    {
        //Future Development
    }
    public void SaveButton()
    {
        //Save from that youtube video
    }
    public void EndButton()
    {
        //Player Turn equals false
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
