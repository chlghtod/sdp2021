﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ConcreteStateB 클래스
// 공격
public class Attack : JustState
{
    public void Action()
    {
        Debug.Log("공격 !!!");
    }
}
