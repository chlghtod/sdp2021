using UnityEngine;


namespace GG181012

{

    public class Character : MonoBehaviour
    {
        private Rigidbody2D myRigidbody;
        private Animator myAnimator;
        public AudioSource audioSource;


        //엔피씨 대화 종료 판단용
        public bool isClear;

        //이동 방향
        private Vector3 move_Direction;

        [SerializeField] private Vector3 attack_Direction;
        private Vector3 look_Direction;
        protected float prevMoveDirection_X;
        protected float prevMoveDirection_Y;

        //출력 애니메이션 클립 번호
        public float AnimationNumber;



        #region Character Stat Variables

        [SerializeField] public float max_Health_Point; //기본 HP(생명력)

        ///행동에 영향을 주는 스탯
        ///선택 스탯에 영향을 받음(간접적으로 수정 가능)
        [SerializeField] private float defult_Move_Speed; //기본 이동속도
        private float now_Move_Speed;
        [SerializeField] protected float defult_Physical_Attack_Power; //기본 물리 공격력
        private float now_Physical_Attack_Power;
        [SerializeField] private float defult_Magic_Attack_Power; //기본 마법 공격력

        #endregion

        #region States

        [SerializeField] private State currentState;

        private State_Attack attackState;
        private State_Idle idleState;
        private State_Move moveState;


        #endregion

        #region Status enabled or not
        private bool isAttack;
        private bool isIdle;
        private bool isInput;
        private bool isMove;



        #endregion

        #region Equip


        #endregion

        #region Properties

        //물리
        ///읽기 전용
        public Rigidbody2D MyRigidbody { get { return myRigidbody; } }

        //애니메이션
        public Animator MyAnimator { get { return myAnimator; } set { myAnimator = value; } }


        //캐릭터 이름


        //캐릭터 경험치


        //캐릭터 스탯 경험치


        //캐릭터 선택 스탯


        //캐릭터 자원 스탯


        //캐릭터 행동 스탯
        //public  float Now_Attack_Width_Range { get { return now_Attack_Width_Range; } protected set { now_Attack_Width_Range = value; } }
        //public float Now_Attack_Length_Range { get { return now_Attack_Length_Range; } protected set { now_Attack_Length_Range = value; } }

        //파생 클래스에서만 쓰기 가능
        public float Defult_Move_Speed { get { return defult_Move_Speed; } set { defult_Move_Speed = value; } }
        public float Now_Speed { get { return now_Move_Speed; } set { now_Move_Speed = value; } }
        public float Now_Physical_Attack_Power { get { return now_Physical_Attack_Power; } protected set { now_Physical_Attack_Power = value; } }
        //public float Now_Defense_Power { get { return now_Physical_Defense_Power; } protected set { now_Physical_Defense_Power = value; } }

        public bool IsAttack { get { return isAttack; } set { isAttack = value; } }
        public bool IsIdle { get { return isIdle; } set { isIdle = value; } }
        public bool IsInput { get { return isInput; } set { isInput = value; } }
        public bool IsMove { get { return isMove; } set { isMove = value; } }



        public State CurrentState { get { return currentState; } set { currentState = value; } }

        //캐릭터 행동 상태
        ///읽기 전용
        public State_Attack AttackState { get { return attackState; } }
        public State_Idle IdleState { get { return idleState; } }
        public State_Move MoveState { get { return moveState; } }
        //캐릭터 이동 방향
        public Vector3 Move_Direction { get { return move_Direction; } set { move_Direction = value; } }
        public float PrevMoveDirection_X { get { return prevMoveDirection_X; } set { prevMoveDirection_X = value; } }
        public float PrevMoveDirection_Y { get { return prevMoveDirection_Y; } set { prevMoveDirection_Y = value; } }

        //공격 방향
        public Vector3 Attack_Direction { get { return attack_Direction; } set { attack_Direction = value; } }

        //애니 방향
        public Vector3 Look_Direction { get { return look_Direction; } set { look_Direction = value; } }

        //공격 대상 레이어 마스크
        ///읽기 전용



        #endregion








        protected virtual void Awake()
        {
            myRigidbody = GetComponent<Rigidbody2D>();

            //Animation
            myAnimator = GetComponent<Animator>();

            //audio
            //audioSource = GetComponent<AudioSource>();

            //State
            attackState = GetComponent<State_Attack>();
            idleState = GetComponent<State_Idle>();
            moveState = GetComponent<State_Move>();
        }

        private void Start()
        {
        }

    }
}