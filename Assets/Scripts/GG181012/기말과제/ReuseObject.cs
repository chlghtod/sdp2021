using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GG181012;

namespace GG181012
{ 
public class ReuseObject : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    ObjectPool parentObject;

    [SerializeField] string targetTag;
    [SerializeField] string myTag;


    [SerializeField] public bool isDie;
    float nowDelay;
    public float speed;
    [SerializeField] float lifeTime;
    Vector3 moveDirection;





    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        //Debug.Log("발사체 스타트()");
        parentObject = transform.parent.GetComponent<ObjectPool>();
        //gun = transform.parent.transform.parent.transform;
    }


    private void FixedUpdate()
    {
        RotationProjectile(moveDirection);
        BulletMove(moveDirection);
    }
    // Update is called once per frame
    void Update()
    {

        CheckLife(); // 오브젝트의 생존 여부 판단
        if (isDie)
        {
            parentObject.ReturnBullet();
        }
    }

    public void SetBullet(GameObject gameObject, Vector3 direction, float objectSpeed)
    {
        // 오브젝트 활성화 시 시작 위치 초기화
        
        this.gameObject.transform.position 
            = new Vector3(transform.parent.position.x, transform.parent.position.y, 0);
        moveDirection = direction;
        speed = objectSpeed;
    }
    void CheckLife() // 오브젝트의 생존 여부 판단
    {
        // 1. 오브젝트가 1초 이상 활성화 될 경우 죽었다고 판단한다.
        nowDelay += Time.deltaTime;
        if (nowDelay > lifeTime)
        {
            isDie = true;
            nowDelay = 0;
            // 계속 날라가서 사라지는 경우는 벽 뚫고 지나간 경우 밖에 없다.
            // 이 경우에 투사체의 콜라이더를 지워주기 때문에 죽었다고 확정 될 경우
            // 콜라이더를 다시 활성화 해서 오브젝트 풀로 돌려줘야한다.
            gameObject.GetComponent<CircleCollider2D>().enabled = true; 
        }
    }

    public void BulletMove(Vector3 direction)
    {
        Vector3 moveRes = direction * speed * Time.deltaTime;
        myRigidbody.MovePosition(transform.position + moveRes);
    }

    // 오브젝트가 활성화 될 때
    private void OnEnable()
    {
        myRigidbody.velocity = Vector3.forward * speed;
    }
    // 오브젝트가 비활성화 될 때
    private void OnDisable()
    {
        myRigidbody.Sleep();
    }

    void RotationProjectile(Vector3 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle-90));
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == targetTag)
        {
            isDie = true;
            if (collision == null)
            {
                Debug.Log("목표없음");
            }
            
            //collision.gameObject.GetComponent<Damageable>().HPdecrease(myGun.gunDamage);
            collision.gameObject.transform.parent.GetComponent<Character>().MyRigidbody.velocity = moveDirection;
            Debug.Log("명중");
            //parentObject.ReturnBullet();
        }
        //else if(collision.gameObject.tag=="Ground_Wall")
        //{
        //    //gameObject.GetComponent<CircleCollider2D>().enabled = false;
        //}
        //else if(collision.gameObject.tag==myTag)
        //{
        //    //임시 방편
        //    //클락을 통과 시킨 다음 몹은 관통 하면 안된다.
        //    //클락 통과 시키기 위해서 콜라이더를 지우면
        //    //이후에 콜라이더를 다시 활성화 시킬 조건을 만들어야함.
        //    //수정 필요.
        //    //gameObject.GetComponent<CircleCollider2D>().enabled = false;
        //}
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        //isDie = true;
    }
}
}