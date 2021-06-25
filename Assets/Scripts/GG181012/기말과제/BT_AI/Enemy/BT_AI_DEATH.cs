using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_AI_DEATH : BT_Leaf
{
    public override bool Run()
    {
        character.IsAttack = false;
        character.IsMove = false;
        character.IsIdle = false;
        return true;
    }
}
