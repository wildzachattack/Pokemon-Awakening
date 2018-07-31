using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightMenuManager : MonoBehaviour
{
    public Button move1;
    public Button move2;
    public Button move3;
    public Button move4;
    public Text textBox1;
    public Text textBox2;
    public Text textBox3;
    public Text textBox4;
    private int buttonCount = 0;
    private GameObject pokemonScriptHolder;
    private DisplayManager displayScript;
    private PokemonManager pokemonScript;

    void Awake()
    {
        displayScript = GetComponent<DisplayManager>();
    }
    void Update()
    {
        pokemonScriptHolder = GameObject.Find(displayScript.pokName);
        pokemonScript = pokemonScriptHolder.GetComponent<PokemonManager>();
    }
    public void Button1()
    {
        if (buttonCount == 0)
        {
            AttackMoveClick();
            move2.interactable = false;
            move3.interactable = false;
            move4.interactable = false;
            textBox1.text = "CONFIRM";
            textBox2.text = "";
            textBox3.text = "";
            textBox4.text = "";
        }
        else
        {
            //This will call the confirmation of the attack
            //Calculates damage done to character if hit
        }
    }
    public void Button2()
    {
        if (buttonCount == 0)
        {
            AttackMoveClick();
            move1.interactable = false;
            move3.interactable = false;
            move4.interactable = false;
            textBox1.text = "";
            textBox2.text = "CONFIRM";
            textBox3.text = "";
            textBox4.text = "";
        }
        else
        {

        }
    }
    public void Button3()
    {
        if (buttonCount == 0)
        {
            AttackMoveClick();
            move1.interactable = false;
            move2.interactable = false;
            move4.interactable = false;
            textBox1.text = "";
            textBox2.text = "";
            textBox3.text = "CONFIRM";
            textBox4.text = "";
        }
        else
        {

        }
    }
    public void Button4()
    {
        if (buttonCount == 0)
        {
            AttackMoveClick();
            move1.interactable = false;
            move2.interactable = false;
            move3.interactable = false;
            textBox1.text = "";
            textBox2.text = "";
            textBox3.text = "";
            textBox4.text = "CONFIRM";
        }
        else
        {

        }
    }
    void AttackMoveClick()
    {
        buttonCount = buttonCount + 1;
        displayScript.cameraMode = 5;
    }
    public void ExitFirstButtonClick()
    {
        buttonCount = buttonCount - 1;
        move1.interactable = true;
        move2.interactable = true;
        move3.interactable = true;
        move4.interactable = true;
        //Maybe add soemthing to reload text of attack names so CONFIRM doesn't stay there
    }
}
