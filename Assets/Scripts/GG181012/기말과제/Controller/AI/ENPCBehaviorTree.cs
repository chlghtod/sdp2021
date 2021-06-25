using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GG181012;
public class ENPCBehaviorTree : CharacterControl
{
    //�� Ŭ������ ENPC AI�� �⺻�� �Ǵ� Ŭ�����̴�.
    //�� Ŭ������ ��� �޾� �پ��� AI Ŭ������ ���� ����ϵ��� �Ѵ�.

    protected ENPCharacter character;


    private void Awake()
    {
        character = transform.parent.GetComponent<ENPCharacter>();
        character.Enemy_AI = GetComponent<ENPCBehaviorTree>();

        //�б� ���
        seq_AI = gameObject.AddComponent<BT_Sequence>();
        sel_Stat_Selector = gameObject.AddComponent<BT_Selector>();
        sel_Status_Replacement_Branch = gameObject.AddComponent<BT_Selector>();
        seq_Attack_Range = gameObject.AddComponent<BT_Sequence>();
        seq_Sight_Range = gameObject.AddComponent<BT_Sequence>();

        //���� ���� ���(����)
        AI_ATTACK_RANGE = gameObject.AddComponent<BT_AI_ATTACK_RANGE>();
        AI_ATTACK = gameObject.AddComponent<BT_AI_ATTACK>();
        AI_SIGHT_RANGE = gameObject.AddComponent<BT_AI_SIGHT_RANGE>();
        AI_CHASE = gameObject.AddComponent<BT_AI_CHASE>();
        AI_IDLE = gameObject.AddComponent<BT_AI_IDLE>();
        //AI_DEATH = gameObject.AddComponent<BT_AI_DEATH>();

        //���� ��ȯ ���(����)
        action_ATTACK = gameObject.AddComponent<BT_Action_ATTACK>();
        action_MOVE = gameObject.AddComponent<BT_Action_MOVE>();
        action_IDLE = gameObject.AddComponent<BT_Action_IDLE>();

        //���� ���� ���� ���� ��ȯ ��带 �����ؼ� �ϳ��� ��ĥ�� ������ ����.
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

        sel_Status_Replacement_Branch.AddChildNode(action_ATTACK); // ���� �׼�
        sel_Status_Replacement_Branch.AddChildNode(action_MOVE); //�̵� �׼�
        sel_Status_Replacement_Branch.AddChildNode(action_IDLE); // ���

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
