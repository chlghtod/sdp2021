using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GG181012;

public class BT_AI_ATTACK : BT_Leaf
{
    public override bool Run()
    {
        //character.CurrentState = character.AttackState;
        character.IsAttack = true;
        character.IsMove = false;
        character.IsIdle = false;
        //Debug.Log("BT Attack 진입");
        return true;
    }
}