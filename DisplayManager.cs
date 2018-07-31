using UnityEngine;
using UnityEngine.UI;

public class DisplayManager : MonoBehaviour
{
    public int cameraMode;
    public string pokName;
    public string trainerName = "Dexter";
    public bool playersTurn;
    public Button item;
    public GameObject optionsMenu;
    public GameObject battleMenu;
    public GameObject fightMenu;
    public GameObject itemMenu;
    public GameObject battleStatisticMenu;
    //Script initializing
    private MoveManager moveScript;
    private GameObject trainerScriptHolder;
    private TrainerManager trainerScript;
    private FightMenuManager fightMenuScript;

    void Awake()
    {
        trainerScriptHolder = GameObject.Find(trainerName);
        moveScript = GetComponent <MoveManager>();
        trainerScript = trainerScriptHolder.GetComponent<TrainerManager>();
        fightMenuScript = GetComponent<FightMenuManager>();
    }
    void Update()
    {
        Esc();
        if (cameraMode == 0) //Camera Movement Mode
        {
            battleMenu.SetActive(false);
            optionsMenu.SetActive(false);
            moveScript.MoveCamera();
        }
        else if (cameraMode == 1) //Battle Menu Mode
        {
            battleMenu.SetActive(true);
            if (trainerScript.trainerSelected == false)
            {
                item.interactable = false;
            }
            else
            {
                item.interactable = true;
            }
        }
        else if (cameraMode == 2) //Escape Menu Mode
        {
            optionsMenu.SetActive(true);
        }
        else if (cameraMode == 3) //Fight Menu
        {
            battleMenu.SetActive(false);
            fightMenu.SetActive(true);
            //Read Pokemon selected moves
            //Print pokemon selected moves
        }
        else if (cameraMode == 4) //Item Menu
        {
            itemMenu.SetActive(true);
        }
        else if (cameraMode == 5) //Stats on attack
        {
            battleStatisticMenu.SetActive(true);
        }
        else if (cameraMode == 6) //Stats on item
        {
            itemMenu.SetActive(false);
        }
        else if (cameraMode == 7) //Move shows arrows and makes blue spaces and red spaces over tiles
        {
            battleMenu.SetActive(false);
            moveScript.MoveSelectedPokemon(); //Add Features with blue and red and arrows
        }
    }
    void Esc()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (cameraMode == 0)
            {
                cameraMode = 2;
            }
            else if (cameraMode == 1)
            {
                battleMenu.SetActive(false);
                cameraMode = 0;
            }
            else if (cameraMode == 2)
            {
                cameraMode = 0;
            }
            else if (cameraMode == 3)
            {
                fightMenu.SetActive(false);
                cameraMode = 1;
            }
            else if (cameraMode == 4)
            {
                itemMenu.SetActive(false);
                cameraMode = 1;
            }
            else if (cameraMode == 5)
            {
                battleStatisticMenu.SetActive(false);
                cameraMode = 3;
                fightMenuScript.ExitFirstButtonClick();
            }
            else if (cameraMode == 6)
            {
                cameraMode = 4;
            }
        }
    }
}