using UnityEngine;
using System.Collections;

//public enum MyState {
//	STATE_STANDING,
//	STATE_JUMPING,
//	STATE_DUCKING,
//	STATE_DIVING
//}

public class MyAction7 : MonoBehaviour {

    float gravity = 0.0f;   // 중력의 값
    Vector3 velocity;       // 캐릭터의 현재 높이 저장값
	int chargeTime = 0;
	const int MAX_CHARGE = 20;

	MyState state = MyState.STATE_STANDING;

    void Start() 
	{
        velocity = transform.position;
    }

    void Update()
    {
		switch (state) {
		case MyState.STATE_STANDING:
			if (Input.GetKeyDown(KeyCode.Space))
			{
				state = MyState.STATE_JUMPING;
				StartCoroutine("HandleJump");
			} else if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				chargeTime = 0;

				state = MyState.STATE_DUCKING;
				StartCoroutine("HandleDown");
			}
			break;
		case MyState.STATE_JUMPING:
			if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				state = MyState.STATE_DIVING;
				StartCoroutine("HandleAttack");
			}
			break;
		case MyState.STATE_DUCKING:
			if (Input.GetKeyUp(KeyCode.DownArrow))
			{
				state = MyState.STATE_STANDING;
				StartCoroutine("HandleStand");
			}

			chargeTime ++;
			if ( chargeTime > MAX_CHARGE ) {
				// 스킬 발동;
				state = MyState.STATE_STANDING;
				StartCoroutine("HandleSkill");
			}

			break;
		default:
			break;
		}
    }

    IEnumerator HandleJump()
    {
        gravity = 0.7f;

        while (true)
        {
			if (state == MyState.STATE_DIVING) {
				break;
			}

            velocity.y = velocity.y + gravity;

            transform.position = velocity;

            if (velocity.y < 1.0f)
            {
                break;
            }

            gravity = gravity - 0.1f;

            yield return new WaitForSeconds(0.05f);
        }

		gravity = 0.0f;
		velocity.y = 1.0f;
		transform.position = velocity;
		state = MyState.STATE_STANDING;

		yield return null;
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

	IEnumerator HandleAttack()
	{
		transform.position = new Vector3(0, 0.2f, 0);
		yield return new WaitForSeconds(0.1f);
		transform.position = new Vector3(0, 1.2f, 0);
		yield return new WaitForSeconds(0.1f);
		transform.position = new Vector3(0, 0.2f, 0);
		yield return new WaitForSeconds(0.1f);

		transform.position = new Vector3(0, 1.0f, 0);

		state = MyState.STATE_STANDING;
	}

	IEnumerator HandleSkill()
	{
		transform.Rotate(Vector3.right * -90.0f);
		transform.Translate(Vector3.forward * 3.0f);
		yield return new WaitForSeconds(0.3f);

		transform.position = new Vector3(0, 1.0f, 0);
	}
}
