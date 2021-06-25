using UnityEngine;

namespace GG181012
{


    public abstract class State : MonoBehaviour
    {
        private Character characterRef;

        public bool isActive; // ����Ƽ �����Ϳ��� � ���� Ȱ��ȭ �Ǿ��ִ��� Ȯ�ο�

        protected Character CharacterRef { get { return characterRef; } private set { } }


        //ĳ������ �ش� ���� �ִϸ��̼� ��Ʈ�ѷ�
        [SerializeField] protected RuntimeAnimatorController animatorController_CharacterState;
        [SerializeField] protected float animation_Speed;


        public RuntimeAnimatorController AnimatorController_CharacterState { get { return animatorController_CharacterState; } }



        public AudioClip sound_1;
        public AudioClip sound_2;
        public AudioClip sound_3;


        protected virtual void Awake()
        {
            characterRef = GetComponent<Character>();
        }
        //private void Start()
        //{

        //}



        public abstract void Execution();

        public abstract void Animation();

        public abstract void Sound();

    }
}