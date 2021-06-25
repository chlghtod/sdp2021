using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GG181012;

namespace GG181012
{



    public class State_Attack : GG181012.State
    {
        [SerializeField] GameObject meleeAttackObject;
        protected float nowTime;

        [SerializeField] ObjectPool objectPool;

        public override void Execution()
        {
            //�ִϸ��̼ǿ� �Լ� �� ��




        }

        public void Attack_Start()
        {
            //����
            objectPool.EnableObject(CharacterRef.Attack_Direction);
        }
        public void Attack_End()
        {
            CharacterRef.IsAttack = false;
        }

        public override void Animation()
        {
            if (!(AnimatorController_CharacterState == null))
            {
                CharacterRef.MyAnimator.runtimeAnimatorController = AnimatorController_CharacterState;
                CharacterRef.MyAnimator.SetFloat("Direction_X", CharacterRef.Attack_Direction.x);
                CharacterRef.MyAnimator.SetFloat("Direction_Y", CharacterRef.Attack_Direction.y);

                //CharacterRef.MyAnimator.speed = CharacterRef.Right_Hand.WeaponSpeed;

                //CharacterRef.Right_Hand.StateAction(CharacterRef.Right_Hand.AinmationController_Attack, CharacterRef.Attack_Direction, CharacterRef.Right_Hand.WeaponSpeed);
                //CharacterRef.Right_Hand.WeaponEffect.StateEffect(CharacterRef.Right_Hand.WeaponEffect.AinmationController_Attack, CharacterRef.Attack_Direction, CharacterRef.Right_Hand.WeaponSpeed);

                //������ �ٶ󺸴� ���� ������
                CharacterRef.Move_Direction = CharacterRef.Attack_Direction;

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
}
