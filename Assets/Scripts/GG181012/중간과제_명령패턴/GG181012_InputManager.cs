using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GG181012_InputManager : MonoBehaviour
{


    //Ű�ڵ� �з��� keyName
    //Dictionary ���

    enum keyName
    {
        Number_1 = 0,
        Number_2 = 1,
        Number_3 = 2,
        Q = 4,
        W = 5,
        E = 6,
        ESC = 14
    }

    Dictionary<KeyCode, keyName> keyDictionary;

    protected List<KeyCode> activeInputs = new List<KeyCode>();


    //���� �Է� ����
    //float horizontal;
    //float vertical;
    //float preHorizontal;

    //��ư Up ������ ����
    //bool isPress;

    //���콺 �Է� ���� ����
    //Camera myCamera;
    //Vector3 mousePosition;


    public bool isKeySet; // Ű ���� ���

    public GG181012_ButtonManager settingButton; // �������� ��ư

    GG181012_Command Q;
    GG181012_Command W;
    GG181012_Command E;



    private void Start()
    {
        //Dictionary �̿��� �Է� Ű ����
        keyDictionary = new Dictionary<KeyCode, keyName>
            {
                {KeyCode.Keypad1, keyName.Number_1},
                {KeyCode.Keypad2, keyName.Number_2},
                {KeyCode.Keypad3, keyName.Number_3},
                {KeyCode.Q, keyName.Q},
                {KeyCode.W, keyName.W},
                {KeyCode.E, keyName.E},

                {KeyCode.Escape, keyName.ESC }
            };
        //Q = new GG181012_Command();
    }

    private void Update()
    {
        InputCommand();
    }

    public void InputCommand()
    {
        List<KeyCode> pressedInput = new List<KeyCode>();

        List<KeyCode> releasedInput = new List<KeyCode>();


        if (Input.anyKey || Input.anyKeyDown)
        {
            //�Է� ����
            foreach (var dic in keyDictionary)
            {
                if (Input.GetKeyDown(dic.Key))
                {
                    ButtonActionDown(dic.Value);


                    //Debug.Log(dic.Key + " Ű ������");
                }
                if (Input.GetKey(dic.Key))
                {
                    activeInputs.Remove(dic.Key); // �ߺ� �Է� ����
                    activeInputs.Add(dic.Key); // Ȱ��ȭ �� Ű �߰�, ��Ƽ�꿡�� �ϳ��� Ű�� �ϳ��� ����
                    pressedInput.Add(dic.Key); // �̹� ������Ʈ�� ���ȴ�  ��� Ű

                    //Debug.Log(dic.Key + " Ű ������ ��");

                    ButtonAction(dic.Value);


                }
            }
        }

        foreach (var code in activeInputs)
        {
            releasedInput.Add(code); // Ȱ��ȭ �� ��� Ű �߰�

            if (!pressedInput.Contains(code))
            {
                releasedInput.Remove(code);

                //Debug.Log(code + " Ű Ǯ��.");

                ButtonActionUp(keyDictionary[code]);
            }
        }

        activeInputs = releasedInput;
    }



    void Setting_Button(keyName name)
    {
        if (isKeySet)
        {
            switch (name)
            {
                case keyName.Q:
                    if(!(Q==null))
                    {
                        Q.button.ButtonNameInit();
                    }
                    if((settingButton.currentKey!=null))
                    {
                        settingButton.currentKey = null;
                    }
                    Q = settingButton.Set(ref Q);
                    settingButton.ButtonNameChange("Q");
                    break;
                case keyName.W:
                    if (!(W == null))
                    {
                        W.button.ButtonNameInit();
                    }
                    if ((settingButton.currentKey != null))
                    {
                        settingButton.currentKey = null;
                    }
                    W = settingButton.Set(ref W);
                    settingButton.ButtonNameChange("W");
                    break;
            }
        }
    }

    void ButtonAction(keyName name)
    {
        if (!isKeySet)
            switch (name)
            {

            }
    }

    void ButtonActionDown(keyName name) // �������� �ѹ��� �����ϴ°ɷ� ó��, ���⼭ ó������.
    {
        if (isKeySet)
        {
            Setting_Button(name);
        }
        else
        {
            switch (name)
            {
                case keyName.Q:
                    ButtonEvent_Q();
                    break;
                case keyName.W:
                    ButtonEvent_W();
                    break;
            }
        }
    }

    void ButtonActionUp(keyName name)
    {
        switch (name)
        {
            case keyName.Q:
                ButtonEvent_Q_UP();
                break;
        }
    }



    void ButtonEvent_Q()
    {
        if(!(Q==null))
        {

            Q.Excute();
        }

    }
    void ButtonEvent_Q_UP()
    {
        if (!(Q == null))
        {

        }
    }
    void ButtonEvent_W()
    {
        if (!(W == null))
        {

            W.Excute();
        }

    }
    void ButtonEvent_W_UP()
    {
        if (!(W == null))
        {

        }
    }



    public void SettingMod()
    {
        isKeySet = true;
       //Debug.Log("Set " + isKeySet);
    }

    public void Clear_Setting()
    {
        isKeySet = false;
        //Debug.Log("Set " + isKeySet);
    }

    public void Initialize_Key()
    {
        Q = null;
        W = null;
    }
}
