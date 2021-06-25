using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonsterRange
{



    private void Update()
    {
        InAttackRange();
    }

    void InAttackRange()
    {
            //if (target != null)
            //{
            //    character.isInAttackRange = true;

            //    Vector3 attack_Direction = target.transform.Find("Hit_Pivot").transform.position - character.transform.Find("Weapon").position;

            //    attack_Direction.z = 0;
            //    character.Attack_Direction = attack_Direction.normalized;

            //    //Debug.Log(target.name + "공격범위 들어옴");
            //}
            //else
            //{
            //    character.isInAttackRange = false;

            //    character.Attack_Direction = Vector3.zero;
            //    //Debug.Log("공격범위에 아무도 없음");

            //}
        
    }
}
