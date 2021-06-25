using UnityEngine;


namespace GG181012

{

    public class Character : MonoBehaviour
    {
        private Rigidbody2D myRigidbody;
        private Animator myAnimator;
        public AudioSource audioSource;


        //���Ǿ� ��ȭ ���� �Ǵܿ�
        public bool isClear;

        //�̵� ����
        private Vector3 move_Direction;

        [SerializeField] private Vector3 attack_Direction;
        private Vector3 look_Direction;
        protected float prevMoveDirection_X;
        protected float prevMoveDirection_Y;

        //��� �ִϸ��̼� Ŭ�� ��ȣ
        public float AnimationNumber;



        #region Character Stat Variables

        [SerializeField] public float max_Health_Point; //�⺻ HP(�����)

        ///�ൿ�� ������ �ִ� ����
        ///���� ���ȿ� ������ ����(���������� ���� ����)
        [SerializeField] private float defult_Move_Speed; //�⺻ �̵��ӵ�
        private float now_Move_Speed;
        [SerializeField] protected float defult_Physical_Attack_Power; //�⺻ ���� ���ݷ�
        private float now_Physical_Attack_Power;
        [SerializeField] private float defult_Magic_Attack_Power; //�⺻ ���� ���ݷ�

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

        //����
        ///�б� ����
        public Rigidbody2D MyRigidbody { get { return myRigidbody; } }

        //�ִϸ��̼�
        public Animator MyAnimator { get { return myAnimator; } set { myAnimator = value; } }


        //ĳ���� �̸�


        //ĳ���� ����ġ


        //ĳ���� ���� ����ġ


        //ĳ���� ���� ����


        //ĳ���� �ڿ� ����


        //ĳ���� �ൿ ����
        //public  float Now_Attack_Width_Range { get { return now_Attack_Width_Range; } protected set { now_Attack_Width_Range = value; } }
        //public float Now_Attack_Length_Range { get { return now_Attack_Length_Range; } protected set { now_Attack_Length_Range = value; } }

        //�Ļ� Ŭ���������� ���� ����
        public float Defult_Move_Speed { get { return defult_Move_Speed; } set { defult_Move_Speed = value; } }
        public float Now_Speed { get { return now_Move_Speed; } set { now_Move_Speed = value; } }
        public float Now_Physical_Attack_Power { get { return now_Physical_Attack_Power; } protected set { now_Physical_Attack_Power = value; } }
        //public float Now_Defense_Power { get { return now_Physical_Defense_Power; } protected set { now_Physical_Defense_Power = value; } }

        public bool IsAttack { get { return isAttack; } set { isAttack = value; } }
        public bool IsIdle { get { return isIdle; } set { isIdle = value; } }
        public bool IsInput { get { return isInput; } set { isInput = value; } }
        public bool IsMove { get { return isMove; } set { isMove = value; } }



        public State CurrentState { get { return currentState; } set { currentState = value; } }

        //ĳ���� �ൿ ����
        ///�б� ����
        public State_Attack AttackState { get { return attackState; } }
        public State_Idle IdleState { get { return idleState; } }
        public State_Move MoveState { get { return moveState; } }
        //ĳ���� �̵� ����
        public Vector3 Move_Direction { get { return move_Direction; } set { move_Direction = value; } }
        public float PrevMoveDirection_X { get { return prevMoveDirection_X; } set { prevMoveDirection_X = value; } }
        public float PrevMoveDirection_Y { get { return prevMoveDirection_Y; } set { prevMoveDirection_Y = value; } }

        //���� ����
        public Vector3 Attack_Direction { get { return attack_Direction; } set { attack_Direction = value; } }

        //�ִ� ����
        public Vector3 Look_Direction { get { return look_Direction; } set { look_Direction = value; } }

        //���� ��� ���̾� ����ũ
        ///�б� ����



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