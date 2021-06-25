using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GG181012;

public class BT_Action_INPUT : BT_Leaf
{
    InputManager_2 inputManager;

    private void Start()
    {
        inputManager = GameObject.Find("InputManager").GetComponent<InputManager_2>();
    }
    public override bool Run()
    {
        inputManager.InputCommand();

        return true;
    }
}