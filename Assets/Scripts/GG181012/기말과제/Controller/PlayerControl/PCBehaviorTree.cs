using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GG181012;

namespace GG181012
{


    public class PCBehaviorTree : CharacterControl
    {
        PCharacter character;
        private void Awake()
        {
            //부모 오브젝트 character 스크립트의 변수 연결 작업
            character = transform.parent.GetComponent<PCharacter>();
            character.Player_Control = GetComponent<PCBehaviorTree>();

            //분기 노드
            sel_CharacterState = gameObject.AddComponent<BT_Selector>();
            seq_Input_Status_Branch = gameObject.AddComponent<BT_Sequence>();
            sel_Status_Replacement_Branch = gameObject.AddComponent<BT_Selector>();

            //액션 노드
            action_ATTACK = gameObject.AddComponent<BT_Action_ATTACK>();
            action_IDLE = gameObject.AddComponent<BT_Action_IDLE>();
            action_INPUT = gameObject.AddComponent<BT_Action_INPUT>();
            action_MOVE = gameObject.AddComponent<BT_Action_MOVE>();
        }
        private void Start()
        {
            //Player controller

            //나중에 dead 먼저 연결 할 것.
            sel_CharacterState.AddChildNode(seq_Input_Status_Branch); //대기 액션

            seq_Input_Status_Branch.AddChildNode(action_INPUT); //입력 액션
            seq_Input_Status_Branch.AddChildNode(sel_Status_Replacement_Branch); //스테이터스 변경 분기

            sel_Status_Replacement_Branch.AddChildNode(action_ATTACK);
            sel_Status_Replacement_Branch.AddChildNode(action_MOVE); //이동 액션
            sel_Status_Replacement_Branch.AddChildNode(action_IDLE); // 대기
        }
        public override void ControlCommand()
        {
            sel_CharacterState.Run();
        }
    }
}