using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GG181012;

namespace GG181012
{


    public class ENPCharacter : Character
    {
        //사용클래스
        [SerializeField] ENPCBehaviorTree enemy_AI;
        //[SerializeField] BOSSBehaviorTree bOSSBehaviorTree;





        #region Properties
        public ENPCBehaviorTree Enemy_AI { get { return enemy_AI; } set { enemy_AI = value; } }
        #endregion


        override protected void Awake()
        {
            base.Awake();

            Now_Speed = Defult_Move_Speed;
            Now_Physical_Attack_Power = defult_Physical_Attack_Power;
            CurrentState = IdleState;
            IsIdle = true;


        }
        private void Start()
        {

            //캐릭터 기본 애니메이션 (Idle)
            if (IdleState.AnimatorController_CharacterState != null)
            {
                MyAnimator.runtimeAnimatorController = IdleState.AnimatorController_CharacterState;
            }
            prevMoveDirection_X = 1;
            //시작 무기(초기)
        }

        private void FixedUpdate()
        {
            CurrentState.Sound();
            CurrentState.Execution();
        }

        private void Update()
        {
            MyRigidbody.velocity = Vector3.zero;
            enemy_AI.ControlCommand();
            CurrentState.Animation();
        }
    }
}