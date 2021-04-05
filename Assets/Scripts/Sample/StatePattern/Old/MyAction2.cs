using UnityEngine;
using System.Collections;

public class MyAction2 : MonoBehaviour {

    float gravity = 0.0f;   // 중력의 값
    Vector3 velocity;       // 캐릭터의 현재 높이 저장값
    bool isJumping = false;

    void Start() 
	{
        velocity = transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isJumping)
            {
                // 점프 처리
                isJumping = true;
                StartCoroutine("HandleJump");
            }
        }
    }

    IEnumerator HandleJump()
    {
        gravity = 0.7f;

        while (true)
        {
            velocity.y = velocity.y + gravity;

            transform.position = velocity;

            if (velocity.y < 1.0f)
            {
                velocity.y = 1.0f;
                gravity = 0.0f;
                isJumping = false;
                break;
            }

            gravity = gravity - 0.1f;

            yield return new WaitForSeconds(0.05f);
        }
    }
}
