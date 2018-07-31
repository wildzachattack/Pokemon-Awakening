using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainerManager : MonoBehaviour
{
    public bool trainerSelected;

    private DisplayManager displayScript;
    private GameObject displayScriptHolder;

    void Awake()
    {
        displayScriptHolder = GameObject.Find("CameraTracker");
        displayScript = displayScriptHolder.GetComponent<DisplayManager>();
    }
    public class Trainer
    {
        public string characterName;
        public int level;
        public int hitPointsDisplay;
        public int attackDisplay;
        public int defenseDisplay;
        public int attackSPDisplay;
        public int defenseSPDisplay;
        public int speedDisplay;
        public int movement; //Number of movable tiles in a turn
        public int experience;
        public bool playerCharacter; //Is it you
        public GameObject[] usableAttacks; //What weapons you can use

        private static int hitPointsBase;
        private static int attackBase;
        private static int defenseBase;
        private static int attackSPBase;
        private static int defenseSPBase;
        private static int speedBase;

        public Trainer(string charN, int lvl, int hp, int atk, int def, int atkSP, int defSP, int spd, bool playChar)
        {
            hitPointsBase = hp;
            attackBase = atk;
            defenseBase = def;
            attackSPBase = atkSP;
            defenseSPBase = defSP;
            speedBase = spd;
            StatCalculation();
            characterName = charN;
            playerCharacter = playChar;
        }
        public void StatCalculation()
        {
            hitPointsDisplay = (((((hitPointsBase) * 3) * level) / 100) + level + 10);
            attackDisplay = (((((attackBase) * 3) * level) / 100) + 5);
            defenseDisplay = (((((defenseBase) * 3) * level) / 100) + 5);
            attackSPDisplay = (((((attackSPBase) * 3) * level) / 100) + 5);
            defenseSPDisplay = (((((defenseSPBase) * 3) * level) / 100) + 5);
            speedDisplay = (((((speedBase) * 3) * level) / 100) + 5);
            int tempMove = Mathf.CeilToInt(speedDisplay / 10);
            movement = tempMove;
            if (tempMove >= 10)
            {
                movement = 10;
            }
        }
        public void LevelUp()
        {
            if (level < 100 && (experience >= (100 * level)))
            {
                level = level + 1;
                StatCalculation();
                experience = experience - (level * 100);
            }
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKey(KeyCode.Return))
        {
            trainerSelected = true;
            displayScript.cameraMode = 1;
        }
        else if (displayScript.cameraMode == 0)
        {
            trainerSelected = false;
        }
    }
    void Dexter()
    {
        Trainer dexter = new Trainer("Dexter", 1, 50, 35, 35, 20, 20, 30, true);
    }
    /*protected override void Attack()
    {

    }
    protected override void DisplayRange()
    {
        
    }
    protected override void AnimateMove()
    {

    }
    void UseItem()
    {

    }
    void PickUpObject()
    {

    }*/
}
