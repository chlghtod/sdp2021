using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_AI_IDLE : BT_Leaf
{
    public override bool Run()
    {
        //character.CurrentState = character.IdleState;
        character.IsAttack = false;
        character.IsMove = false;
        character.IsIdle = true;
        //Debug.Log("BT Idle 진입");
        return true;
    }
}
