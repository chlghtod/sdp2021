using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GG181012
{

    public class InputManager_2 : MonoBehaviour
    {

        PCharacter character;
        //키코드 분류용 keyName
        //Dictionary 사용

        enum keyName
        {
            Right = 1,
            Down = 2,
            Left = 3,
            Up = 4,
            Attack = 5

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



        private void Start()
        {
            //Dictionary 이용한 입력 키 감지
            keyDictionary = new Dictionary<KeyCode, keyName>
            {
            {KeyCode.LeftArrow, keyName.Left },
            {KeyCode.DownArrow, keyName.Down },
            {KeyCode.RightArrow, keyName.Right },
            {KeyCode.UpArrow, keyName.Up },
            {KeyCode.A, keyName.Attack },

            };
            //Q = new GG181012_Command();

            character =GameObject.Find("Hero").gameObject.GetComponent<PCharacter>();
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





        void ButtonAction(keyName name)
        {
            switch (name)
            {
                case keyName.Left:
                    ButtonEvenet_Move_Start(new Vector2(-1, 0));
                    Debug.Log("MOVE");
                    break;
                case keyName.Right:
                    ButtonEvenet_Move_Start(new Vector2(1, 0));
                    Debug.Log("MOVE");
                    break;
                case keyName.Up:
                    ButtonEvenet_Move_Start(new Vector2(0, 1));
                    Debug.Log("MOVE");
                    break;
                case keyName.Down:
                    ButtonEvenet_Move_Start(new Vector2(0, -1));
                    Debug.Log("MOVE");
                    break;
            }
        }

        void ButtonActionDown(keyName name) // 눌렀을때 한번만 실행하는걸로 처리, 여기서 처리하자.
        {

            switch (name)
            {
                case keyName.Attack:
                    Debug.Log("ATTACK");
                    ButtonEvent_Attack();
                    break;

            }

        }

        void ButtonActionUp(keyName name)
        {
            switch (name)
            {
                case keyName.Left:
                    ButtonEvenet_Move_End();
                    Debug.Log("MOVE END");
                    break;
                case keyName.Right:
                    ButtonEvenet_Move_End();
                    Debug.Log("MOVE END");
                    break;
                case keyName.Up:
                    ButtonEvenet_Move_End();
                    Debug.Log("MOVE END");
                    break;
                case keyName.Down:
                    ButtonEvenet_Move_End();
                    Debug.Log("MOVE END");
                    break;
            }
        }

        void ButtonEvenet_Move_Start(Vector2 direction)
        {
            character.IsMove = true;
            character.IsIdle = false;
            
            character.Move_Direction = direction;
            character.Attack_Direction = direction;
        }
        void ButtonEvenet_Move_End()
        {
            character.IsMove = false;
            character.IsIdle = true;
        }
        void ButtonEvent_Attack()
        {
            character.IsAttack = true;
        }






    }
}

