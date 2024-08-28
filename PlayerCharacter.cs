using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerCharacter : MonoBehaviour
{
    /// <summary>
    /// 물리 시뮬레이션 컴포넌트를 나타냅니다.
    /// </summary>
    private Rigidbody _Rigidbody;
    private Vector3 movement;

    private void Awake()
    {
        _Rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // 사용자 입력을 받습니다.
        PlayerInput();
        MoveXZ(movement);
        Jump();
    }

    /// <summary>
    /// 사용자 입력을 받는 메서드입니다.
    /// </summary>
    private void PlayerInput()
    {
        // WASD : 전후/좌우 이동
        float verticalAxis = Input.GetAxisRaw("Vertical");
        float horizontalAxis = Input.GetAxisRaw("Horizontal");

        // 스페이스바 : 점프 
        bool jumpInput = Input.GetButtonDown("Jump");

        // 마우스 회전 : 카메라 회전 제어
        float mouseXAxis = Input.GetAxis("Mouse X");
        float mouseYAxis = Input.GetAxis("Mouse Y");

        movement = new Vector3(horizontalAxis, 0, verticalAxis);
    }

    /// <summary>
    /// XZ 축 이동
    /// </summary>
    /// <param name="inputDirection">입력 축 값을 전달합니다.</param>
    private void MoveXZ(Vector3 inputDirection)
    {
        // 이동에 사용되는 값으로, 플레이어 캐릭터에게 가할 힘입니다.
        const float force = 5.0f;
        _Rigidbody.AddForce(inputDirection.normalized * force, ForceMode.Force);
    }

    /// <summary>
    /// 플레이어 캐릭터 점프
    /// </summary>
    private void Jump()
    {
        const float jumpforce = 5.0f;
        if (Input.GetKeyDown(KeyCode.Space))
        _Rigidbody.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
    }
}
