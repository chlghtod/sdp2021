using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightRange : MonsterRange
{




    private void Update()
    {
        InSightRange();
    }

    void InSightRange()
    {
            //if (target != null)
            //{
            //    character.isInSightRange = true;

            //    Vector3 chase_Direction = target.transform.position - character.transform.position;

            //    chase_Direction.z = 0;
            //    chase_Direction = chase_Direction.normalized;



            //    character.Move_Direction = chase_Direction;


            //    //Debug.Log(target.name + "시야범위 들어옴");
            //}
            //else
            //{
            //    character.isInSightRange = false;

            //    character.Move_Direction = Vector3.zero;
            //    //Debug.Log("시야범위에 아무도 없음");
            //}
        

    }

}
