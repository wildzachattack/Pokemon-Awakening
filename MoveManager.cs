using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class MoveManager : MonoBehaviour
{
    public GameObject spotTracker;
    public int xCount; //How many x spots moved from start
    public int yCount; //How many y spots moved from start
    public int tempX; //Value of x direction being attempted
    public int tempY; //Value of x direction being attempted
    private int move; //Assigned to move speed of selected pokemon
    private const int blockingLayer = 11;
    private const int characterLayer = 14;
    private Vector2 StartSpot;
    private Vector2 NorthDirection = new Vector2(0, 1); //Sets y to 1 so direction is north;
    private Vector2 EastDirection = new Vector2(1, 0); //Sets x to 1 so direction is east
    private Vector2 SouthDirection = new Vector2(0, -1); //Sets y to -1 so direction is south
    private Vector2 WestDirection = new Vector2(-1, 0); //Sets x to -1 so direction is west
    //Setting Up move for character and collisions
    public int spotCounter = 0;
    private BoxCollider2D boxCollider;
    private TilemapCollider2D flyOverTiles;
    private TilemapCollider2D surfOverTiles;
    private GameObject flyOverLayer;
    private GameObject surfOverLayer;
    public IList<Vector2> beenHere = new List<Vector2>();
    //Setting up red and blue objects
    public Transform moveSpot;
    public Transform hitSpot;
    public GameObject blueSpot;
    public GameObject redSpot;
    private Vector2 paintTile;
    private int[,] mapSpots;
    //initializing script stuff
    private DisplayManager displayScript;
    private WaitManager waitScript;
    private PokemonManager pokemonScript;
    private GameObject pokemonScriptHolder;
    private BoxCollider2D pokemonCollider;
    private Animator pokemonAnimation;

    void Awake()
    {
        flyOverLayer = GameObject.Find("GroundBlockingLayer");
        surfOverLayer = GameObject.Find("Water");
        flyOverTiles = flyOverLayer.GetComponent<TilemapCollider2D>();
        surfOverTiles = surfOverLayer.GetComponent<TilemapCollider2D>();
        displayScript = GetComponent<DisplayManager>();
        boxCollider = GetComponent<BoxCollider2D>();
        waitScript = GetComponent<WaitManager>();
    }
    void Update()
    {
        pokemonScriptHolder = GameObject.Find(displayScript.pokName);
        pokemonScript = pokemonScriptHolder.GetComponent<PokemonManager>();
        pokemonAnimation = pokemonScriptHolder.GetComponent<Animator>();
        pokemonCollider = pokemonScriptHolder.GetComponent<BoxCollider2D>();
    }
    public void MoveButtonClick()
    {
        xCount = 0;
        yCount = 0;
        spotCounter = 0;
        displayScript.cameraMode = 7;
        move = pokemonScript.movementSpaces;
        beenHere.Clear();
        FloodCounter();
        AddShade();
    }
    public void MoveSelectedPokemon()
    {
        if (pokemonScript.canFly == false) //Read selected pokemon if fly bool
        {
            flyOverTiles.enabled = true;
            surfOverTiles.enabled = true;
        }
        if (pokemonScript.canSurf == true) //Read seleted pokemon if surf bool
        {
            surfOverTiles.enabled = false;
        }
        StartSpot = transform.position;
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            CheckPokemonMove(NorthDirection);
            pokemonAnimation.ResetTrigger("Idle");
            pokemonAnimation.SetTrigger("North");
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            CheckPokemonMove(EastDirection);
            pokemonAnimation.ResetTrigger("Idle");
            pokemonAnimation.SetTrigger("East");
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            CheckPokemonMove(SouthDirection);
            pokemonAnimation.ResetTrigger("Idle");
            pokemonAnimation.SetTrigger("South");
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            CheckPokemonMove(WestDirection);
            pokemonAnimation.ResetTrigger("Idle");
            pokemonAnimation.SetTrigger("West");
        }
        else if (Input.GetKey(KeyCode.Escape))
        {
            DeleteColors();
            AnimationSetIdle();
            flyOverTiles.enabled = false;
            surfOverTiles.enabled = false;
            pokemonScriptHolder.transform.position = pokemonScriptHolder.transform.position - new Vector3(xCount, yCount); //Pokemon reset spot to before move button was clicked
            spotTracker.transform.position = StartSpot - new Vector2(xCount, yCount); //Camera reset spot to before move button was clicked
            displayScript.cameraMode = 1;
        }
        else if (Input.GetKey(KeyCode.Return))
        {
            DeleteColors();
            AnimationSetIdle();
            pokemonScript.actionCount = pokemonScript.actionCount + 1;
            if (pokemonScript.actionCount == 1)
            {
                displayScript.cameraMode = 1;
            }
            else
            {
                waitScript.WaitButtonClick();
            }
        }
    }
    public void MoveCamera() //Moves selecter UI only and only blocking layer is UI blocking layer
    {
        flyOverTiles.enabled = false;
        surfOverTiles.enabled = false;
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            CheckCameraMove(NorthDirection);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            CheckCameraMove(EastDirection);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            CheckCameraMove(SouthDirection);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            CheckCameraMove(WestDirection);
        }
    }
    void AddShade()
    {
        if (pokemonScript.canFly == false) //Read selected pokemon if fly bool
        {
            flyOverTiles.enabled = true;
            surfOverTiles.enabled = true;
        }
        if (pokemonScript.canSurf == true) //Read seleted pokemon if surf bool
        {
            surfOverTiles.enabled = false;
        }
        DeactivateCollider();
        StartSpot = transform.position;
        mapSpots = new int[(move * 2) + 1, (move * 2) + 1];
        mapSpots[move, move] = move;
        Instantiate(blueSpot, StartSpot, Quaternion.identity, moveSpot);
        
        /*for (int xpos = move + 1; xpos <= move * 2; xpos++)
        {
            for (int ypos = move; ypos <= move * 2; ypos++)
            {
                mapSpots[xpos, ypos] = move + (move - xpos) + (move - ypos);
                Vector2 spot = new Vector2(xpos - move, ypos - move);
                if (mapSpots[xpos, ypos] >= 0)
                {
                    Instantiate(blueSpot, StartSpot + spot, Quaternion.identity, moveSpot);
                }
            }
        }
        for (int yneg = move - 1; yneg >= 0; yneg--)
        {
            for (int xpos = move; xpos <= move * 2; xpos++)
            {
                mapSpots[xpos, yneg] = move + (move - xpos) - (move - yneg);
                Vector2 spot = new Vector2(xpos - move, yneg - move);
                if (mapSpots[xpos, yneg] >= 0)
                {
                    Instantiate(blueSpot, StartSpot + spot, Quaternion.identity, moveSpot);
                }
            }
        }
        for (int xneg = move - 1; xneg >= 0; xneg--)
        {
            for (int yneg = move; yneg >= 0; yneg--)
            {
                mapSpots[xneg, yneg] = move - (move - xneg) - (move - yneg);
                Vector2 spot = new Vector2(xneg - move, yneg - move);
                if (mapSpots[xneg, yneg] >= 0)
                {
                    Instantiate(blueSpot, StartSpot + spot, Quaternion.identity, moveSpot);
                }
            }
        }
        for (int ypos = move + 1; ypos <= move * 2; ypos++)
        {
            for (int xneg = move; xneg >= 0; xneg--)
            {
                mapSpots[xneg, ypos] = move - (move - xneg) + (move - ypos);
                Vector2 spot = new Vector2(xneg - move, ypos - move);
                if (mapSpots[xneg, ypos] >= 0)
                {
                    Instantiate(blueSpot, StartSpot + spot, Quaternion.identity, moveSpot);
                }
            }
        }*/
        ResetCollider();
    }
    void DeleteColors()
    {
        var bluechildren = new List<GameObject>();
        foreach (Transform child in moveSpot) bluechildren.Add(child.gameObject);
        bluechildren.ForEach(child => Destroy(child));

        var redChildren = new List<GameObject>();
        foreach (Transform child in hitSpot) redChildren.Add(child.gameObject);
        redChildren.ForEach(child => Destroy(child));
    }
    void CheckCameraMove(Vector2 direction) //Raycasts to see if the camera will hit walls
    {
        boxCollider.enabled = false;
        StartSpot = transform.position;
        RaycastHit2D hitLayer = Physics2D.Raycast(StartSpot, direction, 1, 1 << blockingLayer);
        if (hitLayer.collider)
        {
            boxCollider.enabled = true;
        }
        else
        {
            boxCollider.enabled = true;
            transform.position = StartSpot + direction;
        }
    }
    void CheckPokemonMove(Vector2 direction) //Raycasts to see if the pokemon will hit other pokemmon or walls 
    {
        DeactivateCollider();
        StartSpot = transform.position;
        RaycastHit2D hitCharacter = Physics2D.Raycast(StartSpot, direction, 1, 1 << characterLayer);
        RaycastHit2D hitLayer = Physics2D.Raycast(StartSpot, direction, 1, 1 << blockingLayer);
        if (hitCharacter.collider || hitLayer.collider)
        {
            ResetCollider();
        }
        else
        {
            tempX = (int)direction[0]; //reads the x value of direction to know to add to the xcounter
            tempY = (int)direction[1]; //reads the y value of direction to know to add to the ycounter
            ResetCollider();
            AnimationSetIdle();
            spotCounter = beenHere.Count; //Sets spotCounter to be equal to the size of the list
            if (spotCounter == 0)
            {
                beenHere.Add(StartSpot); //Adds starting spot to list
                xCount = tempX + xCount;
                yCount = tempY + yCount;
                beenHere.Add(StartSpot + direction); //Adds move as well
                transform.position = StartSpot + direction; //Moves the cameratracker
                pokemonScriptHolder.transform.position = StartSpot + direction; //Moves the pokemon
            }
            else if (spotCounter <= move + 1) //Makes sure you can move the amount of spaces move is
            {
                for (int x = 0; x <= spotCounter; x++)
                {
                    if (x == spotCounter)
                    {
                        xCount = tempX + xCount;
                        yCount = tempY + yCount;
                        beenHere.Add(StartSpot + direction);
                        transform.position = StartSpot + direction; //Moves the cameratracker
                        pokemonScriptHolder.transform.position = StartSpot + direction; //Moves the pokemon
                    }
                    else if (spotCounter == move + 1)
                    {

                    }
                    if (beenHere.Contains(StartSpot + direction))
                    {
                        xCount = tempX + xCount;
                        yCount = tempY + yCount;
                        while (beenHere.Count > x)
                        {
                            beenHere.RemoveAt(x);
                        }
                        transform.position = StartSpot + direction; //Moves the cameratracker
                        pokemonScriptHolder.transform.position = StartSpot + direction; //Moves the pokemon
                        spotCounter = x;
                    }
                }
            }
        }
    }
    void AnimationSetIdle() //Sets pokemon to idle position
    {
        pokemonAnimation.ResetTrigger("North");
        pokemonAnimation.ResetTrigger("East");
        pokemonAnimation.ResetTrigger("South");
        pokemonAnimation.ResetTrigger("West");
        pokemonAnimation.SetTrigger("Idle");
    }
    void ResetCollider() //Sets collider to active for boxcollider and pokemon collider
    {
        boxCollider.enabled = true;
        pokemonCollider.enabled = true;
    }
    void DeactivateCollider() //Sets collider to inactive for boxcollider and pokemon collider
    {
        boxCollider.enabled = false; //disable boxes so raycast doesn't self hit.
        pokemonCollider.enabled = false; //disable boxes so raycast doesn't self hit.
    }
    void FloodCounter()
    {
        StartSpot = transform.position;
    }
}