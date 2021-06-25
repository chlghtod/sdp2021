using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GG181012;

public class CharacterControl : MonoBehaviour
{


    //BehaviorTree for player controller
    protected BT_Selector sel_CharacterState; // ��ü Ʈ��
    protected BT_Selector sel_Hit_Status_Branch; // ���� �׼� �б� ������
    protected BT_Sequence seq_Input_Status_Branch; // �Է� �׼� �б� ������



    protected BT_Selector sel_Status_Replacement_Branch; //�������ͽ� ���� �б� ������

    protected BT_Action_IDLE action_IDLE; // �⺻ �׼�
    protected BT_Action_INPUT action_INPUT; // �Է� �׼�



    protected BT_Action_MOVE action_MOVE; // �̵� �׼�
    protected BT_Action_ATTACK action_ATTACK; // ���� �׼�



    //AI���� ����� ���
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
