using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemMenuManager : MonoBehaviour
{
    public Text title;
    private DisplayManager displayScript;

    void Awake()
    {
        displayScript = GetComponent<DisplayManager>();
    }
    public void ItemButtonClick()
    {
        displayScript.cameraMode = 4;
    }
    public void ExitButtonClicked()
    {
        displayScript.cameraMode = 1;
        displayScript.itemMenu.SetActive(false);
        title.text = "BAG";
    }
    public void PokeballButtonClicked()
    {
        title.text = "POKEBALLS";
        //Load user pokeballs
    }
    public void PotionButtonClicked()
    {
        title.text = "POTIONS";
        //Load user potions
    }
    public void BerriesButtonClicked()
    {
        title.text = "BERRIES";
        //Load user berries
    }

}
