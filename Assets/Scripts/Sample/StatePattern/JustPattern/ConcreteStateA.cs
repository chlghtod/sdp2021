using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ConcreteStateA 클래스
// 이동
public class Move : JustState
{
    public void Action()
    {
        Debug.Log("이동 !!!");
    }
}
