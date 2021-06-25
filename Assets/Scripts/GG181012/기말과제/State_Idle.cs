using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GG181012;

public class State_Idle : GG181012.State
{
    private void Awake()
    {
        base.Awake();
        //animation_Speed = 1;
    }
    public override void Execution()
    {
        //Debug.Log("Idle state");


    }

    public override void Animation()
    {
        if (!(AnimatorController_CharacterState == null))
        {
            CharacterRef.MyAnimator.runtimeAnimatorController = AnimatorController_CharacterState;

            CharacterRef.MyAnimator.SetFloat("Direction_X", CharacterRef.Move_Direction.x);
            CharacterRef.MyAnimator.SetFloat("Direction_Y", CharacterRef.Move_Direction.y);
            CharacterRef.PrevMoveDirection_X = CharacterRef.Move_Direction.x;
            CharacterRef.PrevMoveDirection_X = CharacterRef.Move_Direction.y;

            CharacterRef.MyAnimator.speed = animation_Speed;
        }
        else
        {
            return;
        }
    }

    public override void Sound()
    {
        return;
    }

}
