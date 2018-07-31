using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitManager : MonoBehaviour
{
    private Animator pokemonAnimation;
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
        pokemonAnimation = pokemonScriptHolder.GetComponent<Animator>();
    }
    public void WaitButtonClick()
    {
        pokemonScript.actionCount = 2;
        //Read GameObject selected and set pokemonSelected or trainerSelected to false
        displayScript.cameraMode = 0;
        pokemonAnimation.SetBool("IdleWait", true);
    }
}

