using UnityEngine;

namespace GG181012
{


    public abstract class State : MonoBehaviour
    {
        private Character characterRef;

        public bool isActive; // 유니티 에디터에서 어떤 상태 활성화 되어있는지 확인용

        protected Character CharacterRef { get { return characterRef; } private set { } }


        //캐릭터의 해당 상태 애니메이션 컨트롤러
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