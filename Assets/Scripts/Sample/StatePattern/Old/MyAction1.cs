using UnityEngine;
using System.Collections;

public class MyAction1 : MonoBehaviour {

    float gravity = 0.0f;   // 중력의 값
    Vector3 velocity;		// 캐릭터의 현재 높이 저장값

    void Start() 
	{
        velocity = transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 점프 처리
            StartCoroutine("HandleJump");
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
                break;
            }

            gravity = gravity - 0.1f;

            yield return new WaitForSeconds(0.05f);
        }
    }
}
