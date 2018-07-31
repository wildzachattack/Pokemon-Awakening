using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokemonManager : MonoBehaviour
{
    //Changes throughout turns
    public int actionCount;
    //Random stats (IV)
    protected int hitPointsIV;
    protected int attackIV;
    protected int defenseIV;
    protected int attackSPIV;
    protected int defenseSPIV;
    protected int speedIV;
    //Actual Stats of Pokemon
    public int hitPointsDisplayMax;
    public int hitPointsDisplayCurrent;
    public int attackDisplay;
    public int defenseDisplay;
    public int attackSPDisplay;
    public int defenseSPDisplay;
    public int speedDisplay;
    public int movementSpaces;
    public int level;
    public int experience;
    public int maxXP;
    //Unique variables
    public int dexNumber;
    public string characterName;
    public int hitPointsBase;
    public int attackBase;
    public int defenseBase;
    public int attackSPBase;
    public int defenseSPBase;
    public int speedBase;
    public bool canFly;
    public bool canSurf;
    public string[] pokemonType = new string[2]; //Holds up to two types to represent the pokemon
    //Unknown/unestablished but needed
    public IList<PokemonAttacksManager.AttackMove> attackList = new List<PokemonAttacksManager.AttackMove>(); //Holds the pokemosn four usable moves
    public IList<string> nonVolatileStatus = new List<string>(); //Only one (ie Poison, Burn, Freeze, etc)
    public IList<string> volatileStatus = new List<string>(); //As many as effected by (ie leach seed, bind, etc)
    //Display character stats
    private GameObject nameDisplay;
    private GameObject lvlDisplay;
    private GameObject HPDisplay;
    private GameObject HPFill;
    private GameObject XPFill;
    private Sprite pkmImageDisplay;
    //Script definement
    protected PokemonAttacksManager pokemonMoveScript;
    protected GameObject displayScriptHolder;
    protected DisplayManager displayScript;

    protected void Awake()
    {
        displayScriptHolder = GameObject.Find("CameraTracker");
        pokemonMoveScript = GetComponent<PokemonAttacksManager>();
        displayScript = displayScriptHolder.GetComponent<DisplayManager>();
    }
    protected void Start()
    {
        CreateStats(15);
    }
    //Call functions as needed
    public void CreateStats(int lvl)//Call when creating character
    {
        //Instantiate(Resources.Load("Prefabs/" + pkmPrefab));
        RandomIV();
        level = lvl;
        CalculateStats();
        hitPointsDisplayCurrent = hitPointsDisplayMax;
        experience = 0;
        maxXP = level * 50;
    }
    private void RandomIV()//Call inside GetStats(lvl)
    {
        hitPointsIV = Random.Range(0, 31);
        attackIV = Random.Range(0, 31);
        defenseIV = Random.Range(0, 31);
        attackSPIV = Random.Range(0, 31);
        defenseSPIV = Random.Range(0, 31);
        speedIV = Random.Range(0, 31);
    }
    public void LevelUp()//Call when xp is over (lvl * 50)
    {
        int tempHP = (((((hitPointsBase + hitPointsIV) * 2) * level) / 100) + level + 10);
        CalculateStats();
        hitPointsDisplayCurrent = hitPointsDisplayCurrent + (hitPointsDisplayMax - tempHP);
        experience = experience - maxXP;
        level = level + 1;
        maxXP = level * experience;
    }
    private void CalculateStats()//Called in get stats
    {
        hitPointsDisplayMax = (((((hitPointsBase + hitPointsIV) * 2) * level) / 100) + level + 10);
        attackDisplay = (((((attackBase + attackIV) * 2) * level) / 100) + 5);
        defenseDisplay = (((((defenseBase + defenseIV) * 2) * level) / 100) + 5);
        attackSPDisplay = (((((attackSPBase + attackSPIV) * 2) * level) / 100) + 5);
        defenseSPDisplay = (((((defenseSPBase + defenseSPIV) * 2) * level) / 100) + 5);
        speedDisplay = (((((speedBase + speedIV) * 2) * level) / 100) + 5);
        movementSpaces = (Mathf.CeilToInt(speedDisplay / 12)) + 1;
        if (movementSpaces > 10)
        {
            movementSpaces = 10;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        displayScript.pokName = transform.name;
        if (Input.GetKey(KeyCode.Return) && (displayScript.cameraMode == 0) && actionCount < 2)
        {
            displayScript.cameraMode = 1;
        }
        else if (displayScript.cameraMode == 0)
        {
            pkmImageDisplay = gameObject.GetComponent<SpriteRenderer>().sprite;
            GameObject image = GameObject.Find("TheCharacter");
            image.GetComponent<Image>().sprite = pkmImageDisplay;
            HPFill = GameObject.Find("HealthCurrent");
            HPFill.GetComponent<Image>().fillAmount = (float)hitPointsDisplayCurrent / (float)hitPointsDisplayMax;
            if (HPFill.GetComponent<Image>().fillAmount <= 0.275)
            {
                HPFill.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/UI Stuff/UI_Fill_Red");
            }
            else if (HPFill.GetComponent<Image>().fillAmount <= 0.6 && HPFill.GetComponent<Image>().fillAmount > 0.275)
            {
                HPFill.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/UI Stuff/UI_Fill_Orange");
            }
            else
            {
                HPFill.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/UI Stuff/UI_Fill_Green");
            }
            XPFill = GameObject.Find("XPCurrent");
            XPFill.GetComponent<Image>().fillAmount = (float)experience / (float)maxXP;
            nameDisplay = GameObject.Find("NameDisplayHolder");
            nameDisplay.GetComponent<Text>().text = characterName;
            lvlDisplay = GameObject.Find("LevelDisplayHolder");
            lvlDisplay.GetComponent<Text>().text = level.ToString();
            HPDisplay = GameObject.Find("HPDisplayHolder");
            HPDisplay.GetComponent<Text>().text = hitPointsDisplayCurrent.ToString() + "/" + hitPointsDisplayMax.ToString();
        }
    }
    public void Normal()
    {
        pokemonType = new string[1];
        pokemonType[0] = "NORMAL";
    }
    public void NormalFlying()
    {
        pokemonType[0] = "NORMAL";
        pokemonType[1] = "FLYING";
    }
 
    /*protected virtual void Attack()
    {

    }
    protected virtual void DisplayRange()
    {

    }
    protected virtual void AnimateMove() //Move object with arrow key direction and animates move
    {

    }*/
}