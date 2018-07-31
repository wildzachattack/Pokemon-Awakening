using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScrollText : MonoBehaviour
{
    public GameObject downArrow;
    public TextAsset textFile;
    public Text theText;
    public string[] textLines;

    private int currentLine = 0;
    private int endAtLine = 0;
    private bool isTyping = false;
    private bool cancelType = false;
    private bool load = false;
    private const float typeSpeed = 0.05f;
    private const int Tutorial = 3;

    void Start ()
    {
		if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
            if (endAtLine == 0)
            {
                endAtLine = textLines.Length - 1;
            }
        }
    }
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!isTyping)
            {
                currentLine += 1;
                if (currentLine <= endAtLine)
                {
                    StartCoroutine(TextScroll(textLines[currentLine]));
                }
                else if (load)
                {
                    StartCoroutine(LoadScene());
                }
            }
            else if (isTyping && !cancelType)
            {
                cancelType = true;
            }
        }
    }

    private IEnumerator TextScroll(string textLine)
    {
        int letter = 0;
        theText.text = "";
        isTyping = true;
        cancelType = false;
        downArrow.SetActive(false);
        while (isTyping && !cancelType && (letter < textLine.Length - 1))
        {
            theText.text += textLine[letter];
            letter += 1;
            yield return new WaitForSeconds(typeSpeed);
        }
        theText.text = textLine;
        isTyping = false;
        cancelType = false;
        if (currentLine < endAtLine)
        {
            downArrow.SetActive(true);
        }
        else
        {
            load = true;
        }
    }
    private IEnumerator LoadScene()
    {
        SceneManager.LoadScene(Tutorial);
        yield return new WaitForSeconds(5f);
    }
}
