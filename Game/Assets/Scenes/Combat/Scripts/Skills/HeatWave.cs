using UnityEngine;
using System.Collections.Generic;

public class HeatWave : Skill
{
    GameCharacter gc;


    //public HeatWave(GameCharacter gc) : base(gc, "Heat Wave", 1, 0, 1)
    //{

    public HeatWave(GameCharacter gc) : base(

        gc: gc,
        name: "Heat Wave",
        power: 0,
        manaCost: 0,
        skillCost: 1,
        description: "Damages all enemies"

        )
    {

        this.gc = gc;

    }


    public override bool Effect(GameCharacter target)
    {
        if (target == gc)
            return false;
        if (gc.Mana < manaCost)
            return false;

        gc.Mana -= manaCost;

        int damageDealt = Mathf.FloorToInt(gc.Magic * power);

        Combat combat = target.c;
        List<Enemy> enemies = combat.Enemies;

        foreach (GameCharacter enemy in enemies)
        {
            enemy.TakeDamage(Mathf.FloorToInt(damageDealt));
        }

        return true;
    }

}
