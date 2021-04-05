using UnityEngine;
using System.Collections;

public class MyAction4 : MonoBehaviour {

    float gravity = 0.0f;   // 중력의 값
    Vector3 velocity;       // 캐릭터의 현재 높이 저장값
    bool isJumping = false;
	bool isDucking = false;

    void Start() 
	{
        velocity = transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
			if (!isJumping && !isDucking)
            {
                // 점프 처리
                isJumping = true;
                StartCoroutine("HandleJump");
            }
        } else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (!isJumping)
            {
				isDucking = true;
                // 엎드리기
                StartCoroutine("HandleDown");
            }
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
			if ( isDucking ) {
				isDucking = false;
				// 일어나기
				StartCoroutine("HandleStand");
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

    IEnumerator HandleDown()
    {
        transform.Rotate(Vector3.right * 90.0f);
        transform.position = new Vector3(0, 0.5f, 0);
        yield return null;
    }

    IEnumerator HandleStand()
    {
        transform.Rotate(Vector3.right * -90.0f);
        transform.position = new Vector3(0, 1.0f, 0);
        yield return null;
    }
}
