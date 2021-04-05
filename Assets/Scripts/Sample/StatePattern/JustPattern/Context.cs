using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Context 클래스
// 몬스터 클래스
public class Monster
{
    private JustState state;

    // Constructor
    public Monster(JustState state)
    {
        this.state = state;
    }

    public void setState(JustState state)
    {
        this.state = state;
    }

    public void act()
    {
        state.Action();
    }
};
