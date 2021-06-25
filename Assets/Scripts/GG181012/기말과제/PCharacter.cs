using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GG181012;

public class PCharacter : Character

{
    //���Ŭ����
    [SerializeField] PCBehaviorTree player_Control;
    //[SerializeField] Gun clocksGun;
    //Gun currentGun;



    //[SerializeField] bool isCurrentSelectedCharacter;


    #region Properties
    public PCBehaviorTree Player_Control { get { return player_Control; } set { player_Control = value; } }
    //public Gun CurrentGun { get { return currentGun; } set { } }


    #endregion


    override protected void Awake()
    {
        base.Awake();

        ///Control State


        ///���ȼ���(�ӽ�)
        Now_Speed = Defult_Move_Speed;

        //Defult state
        CurrentState = IdleState;
        IsIdle = true;
    }


    private void Start()
    {

        //ĳ���� �⺻ �ִϸ��̼� (Idle)
        MyAnimator.runtimeAnimatorController = IdleState.AnimatorController_CharacterState;
        Look_Direction = new Vector3(-1, 0, 0);
        Attack_Direction = new Vector3(-1, 0, 0);
        //prevMoveDirection_X = 1;
        //���� ����(�ʱ�)
        //currentGun = clocksGun;
    }

    private void FixedUpdate()
    {
        CurrentState.Execution();
        CurrentState.Animation();
        CurrentState.Sound();
    }


    private void Update()
    {

        MyRigidbody.velocity = Vector3.zero;
         
        player_Control.ControlCommand();

        //CurrentState.Animation();

        //MyTimeResetEnd(timeManager.isTimeReset);
    }
}
