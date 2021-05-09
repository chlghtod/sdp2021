using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GG181012_InputManager : MonoBehaviour
{


    //키코드 분류용 keyName
    //Dictionary 사용

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


    //방향 입력 변수
    //float horizontal;
    //float vertical;
    //float preHorizontal;

    //버튼 Up 감지용 변수
    //bool isPress;

    //마우스 입력 방향 계산용
    //Camera myCamera;
    //Vector3 mousePosition;


    public bool isKeySet; // 키 설정 모드

    public GG181012_ButtonManager settingButton; // 설정중인 버튼

    GG181012_Command Q;
    GG181012_Command W;
    GG181012_Command E;



    private void Start()
    {
        //Dictionary 이용한 입력 키 감지
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
            //입력 감지
            foreach (var dic in keyDictionary)
            {
                if (Input.GetKeyDown(dic.Key))
                {
                    ButtonActionDown(dic.Value);


                    //Debug.Log(dic.Key + " 키 눌렀다");
                }
                if (Input.GetKey(dic.Key))
                {
                    activeInputs.Remove(dic.Key); // 중복 입력 방지
                    activeInputs.Add(dic.Key); // 활성화 된 키 추가, 액티브에는 하나의 키는 하나만 존재
                    pressedInput.Add(dic.Key); // 이번 업데이트에 눌렸던  모든 키

                    //Debug.Log(dic.Key + " 키 누르는 중");

                    ButtonAction(dic.Value);


                }
            }
        }

        foreach (var code in activeInputs)
        {
            releasedInput.Add(code); // 활성화 된 모든 키 추가

            if (!pressedInput.Contains(code))
            {
                releasedInput.Remove(code);

                //Debug.Log(code + " 키 풀림.");

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

    void ButtonActionDown(keyName name) // 눌렀을때 한번만 실행하는걸로 처리, 여기서 처리하자.
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
