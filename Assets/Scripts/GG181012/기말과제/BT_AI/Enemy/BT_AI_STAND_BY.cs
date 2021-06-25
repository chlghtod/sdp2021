using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_AI_STAND_BY : BT_Leaf
{
    public override bool Run()
    {
        character.IsIdle = true;
        return true;
    }
}
