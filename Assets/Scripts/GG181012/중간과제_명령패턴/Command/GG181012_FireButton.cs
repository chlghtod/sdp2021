using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GG181012_FireButton : GG181012_ButtonManager
{
    public GG181012_FireCommand fireCommand;

    private void Start()
    {
        button = GetComponent<Button>();
        inputManager = GameObject.Find("InputManager").GetComponent<GG181012_InputManager>();
        fireCommand = new GG181012_FireCommand();
        fireCommand.button =GetComponent<GG181012_ButtonManager>();
    }

    private void Update()
    {
        if (inputManager.isKeySet)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }
    }

    override public GG181012_Command Set(ref GG181012_Command command)
    {
        currentKey = command;
        return fireCommand;
    }
}
