using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonAttacksManager : MonoBehaviour
{
    public class AttackMove
    {
        public string moveName;
        public string moveType;
        public string moveCategory;
        public int power;
        public int accuracy;
        public int maxPowerPoint;
        public int amountPowerPoint;

        public AttackMove(string moveN, string moveT, string moveC, int pow, int acc, int max, int amo)
        {
            moveName = moveN;
            moveType = moveT;
            moveCategory = moveC;
            power = pow;
            accuracy = acc;
            maxPowerPoint = max;
            amountPowerPoint = amo;
        }
    }
    void Absorb()
    {
        AttackMove absorb = new AttackMove("Absorb", "GRASS", "special", 20, 100, 25, 25);
        //attackName.Add(absorb);
    }
    void Acid()
    {
        AttackMove acid = new AttackMove("Acid", "POISON", "special", 40, 100, 30, 30);
        //attackName.Add(acid);
    }
	void AcidArmor()
    {
        AttackMove acidarmor = new AttackMove("Acid Armor", "POISON", "status", 0, 1000, 20, 20);
        //attackName.Add(acidarmor);
    }
    void Agility()
    {
        AttackMove agility = new AttackMove("Agility", "PSYCHIC", "status", 0, 1000, 30, 30);
        //attackName.Add(agility);
    }
    void Amnesia()
    {
        AttackMove amnesia = new AttackMove("Amnesia", "PSYCHIC", "status", 0, 1000, 20, 20);
        //attackName.Add(amnesia);
    }
    void AuroraBeam()
    {
        AttackMove aurorabeam = new AttackMove("Aurora Beam", "ICE", "special", 65, 100, 20, 20);
        //attackName.add(aurorabeam);
    }
    void Barrage()
    {
        AttackMove barrage = new AttackMove("Barrage", "NORMAL", "physical", 15, 85, 20, 20);
    }
    void Barrier()
    {
        AttackMove barrier = new AttackMove("Barrier", "PSYCHIC", "status", 0, 1000, 20, 20);
    }
    void Bide()
    {
        AttackMove bide = new AttackMove("Bide", "NORMAL", "physical", 0, 0, 10, 10);
    }
    void Bind()
    {
        AttackMove bind = new AttackMove("Bind", "NORMAL", "physical", 15, 85, 20, 20);
    }
    void Bite()
    {
        AttackMove bite = new AttackMove("Bite", "DARK", "physical", 60, 100, 25, 25);
    }
    void Blizzard()
    {
        AttackMove blizzard = new AttackMove("Blizzard", "ICE", "special", 110, 70, 5, 5);
    }
    void BodySlam()
    {
        AttackMove bodyslam = new AttackMove("Body Slam", "NORMAL", "physical", 85, 100, 15, 15);
    }
    void BoneClub()
    {
        AttackMove boneclub = new AttackMove("Bone Club", "GROUND", "physical", 65, 100, 20, 20);
    }
    void Bonemerang()
    {
        AttackMove boomerang = new AttackMove("Boomerang", "GROUND", "physical", 50, 100, 10, 10);
    }
    void Bubble()
    {
        AttackMove bubble = new AttackMove("Bubble", "WATER", "special", 40, 100, 30, 30);
    }
    void BubbleBeam()
    {
        AttackMove bubblebeam = new AttackMove("Bubble Beam", "WATER", "physical", 65, 100, 20, 20);
    }
    void Scratch()
    {
        AttackMove scratch = new AttackMove("Scratch", "NORMAL", "physical", 40, 100, 35, 35);
    }
    void Tackle()
    {
        AttackMove tackle = new AttackMove("Attack", "NORMAL", "physical", 40, 100, 35, 35);
    }
}
