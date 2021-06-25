using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GG181012;
public class ENPCBehaviorTree : CharacterControl
{
    //이 클래스는 ENPC AI의 기본이 되는 클래스이다.
    //이 클래스를 상속 받아 다양한 AI 클래스를 만들어서 사용하도록 한다.

    protected ENPCharacter character;


    private void Awake()
    {
        character = transform.parent.GetComponent<ENPCharacter>();
        character.Enemy_AI = GetComponent<ENPCBehaviorTree>();

        //분기 노드
        seq_AI = gameObject.AddComponent<BT_Sequence>();
        sel_Stat_Selector = gameObject.AddComponent<BT_Selector>();
        sel_Status_Replacement_Branch = gameObject.AddComponent<BT_Selector>();
        seq_Attack_Range = gameObject.AddComponent<BT_Sequence>();
        seq_Sight_Range = gameObject.AddComponent<BT_Sequence>();

        //상태 선택 노드(리프)
        AI_ATTACK_RANGE = gameObject.AddComponent<BT_AI_ATTACK_RANGE>();
        AI_ATTACK = gameObject.AddComponent<BT_AI_ATTACK>();
        AI_SIGHT_RANGE = gameObject.AddComponent<BT_AI_SIGHT_RANGE>();
        AI_CHASE = gameObject.AddComponent<BT_AI_CHASE>();
        AI_IDLE = gameObject.AddComponent<BT_AI_IDLE>();
        //AI_DEATH = gameObject.AddComponent<BT_AI_DEATH>();

        //상태 전환 노드(리프)
        action_ATTACK = gameObject.AddComponent<BT_Action_ATTACK>();
        action_MOVE = gameObject.AddComponent<BT_Action_MOVE>();
        action_IDLE = gameObject.AddComponent<BT_Action_IDLE>();

        //상태 선택 노드와 상태 전환 노드를 정리해서 하나로 합칠수 있을거 같음.
    }

    private void Start()
    {
        //AI controller
        seq_AI.AddChildNode(sel_Stat_Selector);
        seq_AI.AddChildNode(sel_Status_Replacement_Branch);


        sel_Stat_Selector.AddChildNode(seq_Attack_Range);
        sel_Stat_Selector.AddChildNode(seq_Sight_Range);
        sel_Stat_Selector.AddChildNode(AI_IDLE);
        //sel_Stat_Selector.AddChildNode(AI_DEATH);

        seq_Attack_Range.AddChildNode(AI_ATTACK_RANGE);
        seq_Attack_Range.AddChildNode(AI_ATTACK);

        seq_Sight_Range.AddChildNode(AI_SIGHT_RANGE);
        seq_Sight_Range.AddChildNode(AI_CHASE);

        sel_Status_Replacement_Branch.AddChildNode(action_ATTACK); // 공격 액션
        sel_Status_Replacement_Branch.AddChildNode(action_MOVE); //이동 액션
        sel_Status_Replacement_Branch.AddChildNode(action_IDLE); // 대기

    }

    public override void ControlCommand()
    {
        if(seq_AI != null)
        {
            seq_AI.Run();
        }
        else
        {
            return;
        }

    }
}
