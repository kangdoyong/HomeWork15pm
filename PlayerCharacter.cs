using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerCharacter : MonoBehaviour
{
    /// <summary>
    /// ���� �ùķ��̼� ������Ʈ�� ��Ÿ���ϴ�.
    /// </summary>
    private Rigidbody _Rigidbody;
    private Vector3 movement;

    private void Awake()
    {
        _Rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // ����� �Է��� �޽��ϴ�.
        PlayerInput();
        MoveXZ(movement);
        Jump();
    }

    /// <summary>
    /// ����� �Է��� �޴� �޼����Դϴ�.
    /// </summary>
    private void PlayerInput()
    {
        // WASD : ����/�¿� �̵�
        float verticalAxis = Input.GetAxisRaw("Vertical");
        float horizontalAxis = Input.GetAxisRaw("Horizontal");

        // �����̽��� : ���� 
        bool jumpInput = Input.GetButtonDown("Jump");

        // ���콺 ȸ�� : ī�޶� ȸ�� ����
        float mouseXAxis = Input.GetAxis("Mouse X");
        float mouseYAxis = Input.GetAxis("Mouse Y");

        movement = new Vector3(horizontalAxis, 0, verticalAxis);
    }

    /// <summary>
    /// XZ �� �̵�
    /// </summary>
    /// <param name="inputDirection">�Է� �� ���� �����մϴ�.</param>
    private void MoveXZ(Vector3 inputDirection)
    {
        // �̵��� ���Ǵ� ������, �÷��̾� ĳ���Ϳ��� ���� ���Դϴ�.
        const float force = 5.0f;
        _Rigidbody.AddForce(inputDirection.normalized * force, ForceMode.Force);
    }

    /// <summary>
    /// �÷��̾� ĳ���� ����
    /// </summary>
    private void Jump()
    {
        const float jumpforce = 5.0f;
        if (Input.GetKeyDown(KeyCode.Space))
        _Rigidbody.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
    }
}
