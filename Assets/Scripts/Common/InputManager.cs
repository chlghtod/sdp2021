using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoSingleton<InputManager>
{
    public string terminateButtonName = "Cancel"; // 종료를 위한 버튼
    public string moveHorizontalAxisName = "Horizontal"; // 좌우 회전을 위한 입력축 이름
    public string moveVerticalAxisName = "Vertical"; // 앞뒤 움직임을 위한 입력축 이름

    public bool isTerminate { get; private set; }
    public Vector2 moveInput { get; private set; }
    public bool fire { get; private set; } 

    public float mouseZoom { get; private set; }
    public float mouseRotation { get; private set; }
    // Update is called once per frame
    void Update()
    {
        mouseRotation = Input.mouseScrollDelta.x;
        mouseZoom = Input.mouseScrollDelta.y;
        
        moveInput = new Vector2(Input.GetAxis(moveHorizontalAxisName), Input.GetAxis(moveVerticalAxisName));
        if (moveInput.sqrMagnitude > 1) moveInput = moveInput.normalized;

        isTerminate = Input.GetButtonDown(terminateButtonName);
    }
}
