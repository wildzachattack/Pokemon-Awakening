using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class TitleScreen : MonoBehaviour
{
    public Text flashingText;
    public Text slideIn;
    private const int MainMenu = 1;

    void Start()
    {
        StartCoroutine(Text());
    }

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0)) //If Key is activated
        {
            SceneManager.LoadScene(MainMenu);
        }
    }
    private IEnumerator Text()
    {
        slideIn.text = "AWAKENING";
        yield return new WaitForSeconds(2f);
        while (true)
        {
            flashingText.text = "PRESS" + "ENTER";
            yield return new WaitForSeconds(0.75f);
            flashingText.text = "";
            yield return new WaitForSeconds(0.75f);
        }
    }
}