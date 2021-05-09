using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GG181012_ButtonManager : MonoBehaviour
{

    protected Button button;
    public GG181012_Command  currentKey;
    protected GG181012_InputManager inputManager;


    public void Setting()
    {
        inputManager.settingButton = gameObject.GetComponent<GG181012_ButtonManager>();
    }

    virtual public GG181012_Command Set(ref GG181012_Command command)
    {
        return null;
    }
    public void ButtonNameChange(string name)
    {
        button.transform.GetChild(0).GetComponent<Text>().text = name;
    }
    public void ButtonNameInit()
    {
        button.transform.GetChild(0).GetComponent<Text>().text = "SetButton";
    }
}
