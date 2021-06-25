using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GG181012;

public class CharacterControl : MonoBehaviour
{


    //BehaviorTree for player controller
    protected BT_Selector sel_CharacterState; // 전체 트리
    protected BT_Selector sel_Hit_Status_Branch; // 경직 액션 분기 시퀸스
    protected BT_Sequence seq_Input_Status_Branch; // 입력 액션 분기 셀렉터



    protected BT_Selector sel_Status_Replacement_Branch; //스테이터스 변경 분기 셀렉터

    protected BT_Action_IDLE action_IDLE; // 기본 액션
    protected BT_Action_INPUT action_INPUT; // 입력 액션



    protected BT_Action_MOVE action_MOVE; // 이동 액션
    protected BT_Action_ATTACK action_ATTACK; // 공격 액션



    //AI에서 사용할 노드
    protected BT_Sequence seq_AI;
    protected BT_Sequence seq_Attack_Range;
    protected BT_Sequence seq_Sight_Range;
    protected BT_Selector sel_Stat_Selector;

    protected BT_AI_ATTACK_RANGE AI_ATTACK_RANGE;
    protected BT_AI_ATTACK AI_ATTACK;
    protected BT_AI_SIGHT_RANGE AI_SIGHT_RANGE;
    protected BT_AI_CHASE AI_CHASE;
    protected BT_AI_IDLE AI_IDLE;
    protected BT_AI_DEATH AI_DEATH;







    public virtual void ControlCommand()
    {

    }


}
