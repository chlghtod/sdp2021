using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GG181012;

public class State_Move : GG181012.State
{
    float nowTime;
    private void Awake()
    {
        base.Awake();
        //animation_Speed = 1;
    }

    public override void Execution()
    {
        Vector3 moveRes = CharacterRef.Move_Direction * CharacterRef.Now_Speed * Time.deltaTime;
        CharacterRef.MyRigidbody.MovePosition(transform.position + moveRes);
        //Debug.Log("X : "+CharacterRef.Movement.x+" Y : "+CharacterRef.Movement.y);
    }

    public override void Animation()
    {
        if (!(AnimatorController_CharacterState == null))
        {
            CharacterRef.MyAnimator.runtimeAnimatorController = AnimatorController_CharacterState;


            CharacterRef.Look_Direction = CharacterRef.Move_Direction;
            



                CharacterRef.MyAnimator.SetFloat("Direction_X", CharacterRef.Look_Direction.x);
                CharacterRef.MyAnimator.SetFloat("Direction_Y", CharacterRef.Look_Direction.y);
                CharacterRef.PrevMoveDirection_X = CharacterRef.Look_Direction.x;
                CharacterRef.PrevMoveDirection_Y = CharacterRef.Look_Direction.y;
            
            CharacterRef.MyAnimator.speed = animation_Speed;
        }
        else
        {
            return;
        }
    }

    public override void Sound()
    {
        if (sound_1 != null)
        {
            nowTime += Time.deltaTime;
            if (nowTime > 0.3)
            {
                CharacterRef.audioSource.clip = sound_1;
                CharacterRef.audioSource.Play();
                nowTime = 0;
            }
        }
        return;
    }


}
