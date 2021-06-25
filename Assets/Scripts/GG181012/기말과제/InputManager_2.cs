using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GG181012
{

    public class InputManager_2 : MonoBehaviour
    {

        PCharacter character;
        //Ű�ڵ� �з��� keyName
        //Dictionary ���

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


        //���� �Է� ����
        //float horizontal;
        //float vertical;
        //float preHorizontal;

        //��ư Up ������ ����
        //bool isPress;

        //���콺 �Է� ���� ����
        //Camera myCamera;
        //Vector3 mousePosition;



        private void Start()
        {
            //Dictionary �̿��� �Է� Ű ����
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

        void ButtonActionDown(keyName name) // �������� �ѹ��� �����ϴ°ɷ� ó��, ���⼭ ó������.
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

