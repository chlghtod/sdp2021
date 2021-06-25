using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_AI_CHASE : BT_Leaf
{
    public override bool Run()
    {
        //character.CurrentState = character.MoveState;

        character.IsAttack = false;
        character.IsMove = true;
        character.IsIdle = false;

        //Debug.Log("BT Chase 진입");
        return true;
    }
}
