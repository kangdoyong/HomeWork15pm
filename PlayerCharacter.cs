using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class PlayerCharacter : MonoBehaviour
{
    // pitch 15 ~ 45
    // 바닥 레이어
    public LayerMask m_FloorLayer;

    // 점프 힘
    public float m_JumpPower = 100.0f;

    // 카메라 기준점
    public Transform m_CameraPivotTransform;

    [Range(-60.0f, 0.0f)]
    public float m_CameraPitchLimitMin = 15.0f;

    [Range(0.0f, 70.0f)]
    public float m_CameraPitchLimitMax;

    // 점프 중 상태
    private bool m_IsJump;

    // 카메라 회전(X : YawRotation / Y : PitchRotation)
    private Vector2 _CameraRotation;

    /// <summary>
    /// 물리 시뮬레이션 컴포넌트를 나타냅니다.
    /// </summary>
    private Rigidbody _Rigidbody;

    /// <summary>
    /// 플레이어 캐릭터의 충돌 영역
    /// </summary>
    private SphereCollider _SphereCollider;

    //private Vector3 movement;

    private void Awake()
    {
        _Rigidbody = GetComponent<Rigidbody>();
        _SphereCollider = GetComponent<SphereCollider>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // 사용자 입력을 받습니다.
        PlayerInput();
        //MoveXZ(movement);
        //Jump();

        // 바닥 확인
        CheckFloor();
    }

    private void FixedUpdate()
    {
        // 카메라 이동
        CameraTracking();
    }

    /// <summary>
    /// 사용자 입력을 받는 메서드입니다.
    /// </summary>
    private void PlayerInput()
    {
        // WASD : 전후/좌우 이동
        float verticalAxis = Input.GetAxisRaw("Vertical");
        float horizontalAxis = Input.GetAxisRaw("Horizontal");

        // 입력 축 값
        Vector3 inputAxis = new Vector3(horizontalAxis, 0, verticalAxis);

        // 스페이스바 : 점프 
        bool jumpInput = Input.GetButtonDown("Jump");

        // 마우스 회전 : 카메라 회전 제어
        float mouseXAxis = Input.GetAxis("Mouse X");
        float mouseYAxis = Input.GetAxis("Mouse Y");

        //movement = new Vector3(horizontalAxis, 0, verticalAxis);

        // 카메라 회전
        RotateCamera(mouseXAxis, mouseYAxis);

        // XZ 축 이동
        MoveXZ(inputAxis);

        // 점프
        if (jumpInput) Jump();

        if (CheckGameOver())
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // 씬 전환
            SceneManager.LoadScene("Sample03Scene");
        }
    }

    /// <summary>
    /// 입력 축 값을 월드 기준 방향으로 변환합니다.
    /// </summary>
    /// <param name="inputDirection">입력 축 값을 전달합니다.</param>
    /// <returns>월드 기준으로 변환한 방향값을 반환합니다.</returns>
    private Vector3 InputToWorldDirection(in Vector3 inputDirection)
    {
        Vector3 cameraForward = m_CameraPivotTransform.forward;
        cameraForward.y = 0.0f;
        cameraForward.Normalize();

        Vector3 worldForward = cameraForward * inputDirection.z;
        Vector3 worldRight = m_CameraPivotTransform.right * inputDirection.x;

        Vector3 worldDirection = (worldForward + worldRight);
        worldDirection.Normalize();

        return worldDirection;
    }

    /// <summary>
    /// XZ 축 이동
    /// </summary>
    /// <param name="inputDirection">입력 축 값을 전달합니다.</param> 
    private void MoveXZ(Vector3 inputDirection)
    {
        // 이동에 사용되는 값으로, 플레이어 캐릭터에게 가할 힘입니다.
        const float force = 100.0f;
        //_Rigidbody.AddForce(inputDirection.normalized * force, ForceMode.Force);

        // 입력 축 값을 월드 기준 방향으로 변환합니다.
        Vector3 direction = InputToWorldDirection(inputDirection);

        _Rigidbody.AddForce(direction * force);
    }

    /// <summary>
    /// 플레이어 캐릭터 점프
    /// </summary>
    private void Jump()
    {
        //const float jumpforce = 5.0f;
        //if (Input.GetKeyDown(KeyCode.Space))
        //_Rigidbody.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);

        // 점프중이라면, 함수 호출 종료.
        if (m_IsJump) return;
        _Rigidbody.AddForce(Vector3.up * m_JumpPower, ForceMode.Impulse);
    }

    /// <summary>
    /// 바닥을 확인합니다.
    /// </summary>
    private void CheckFloor()
    {
        float radius = _SphereCollider.radius - 0.05f;

        // 구체 영역의 중심 위치
        Vector3 center = transform.position + (Vector3.down * 0.1f);

        // Physics.OverlapSphere : 지정한 영역에 존재하는 충돌체를 감지하기 위하여 구체 영역을 생성합니다.
        Collider[] detectedFloors =  Physics.OverlapSphere(
            center, radius, m_FloorLayer, QueryTriggerInteraction.Ignore);

        // 감지한 충돌체가 존재한다면
        if (detectedFloors.Length > 0)
            m_IsJump = false;
        else m_IsJump = true;
    }

    /// <summary>
    /// 카메라를 회전시킵니다.
    /// </summary>
    /// <param name="mouseXAxis">마우스 입력 X 축 값을 전달합니다.</param>
    /// <param name="mousYAxis">마우스 입력 Y 축 값을 전달합니다.</param>
    private void RotateCamera(float mouseXAxis, float mousYAxis)
    {
        _CameraRotation.x += mouseXAxis;
        _CameraRotation.y -= mousYAxis;
        _CameraRotation.y = Mathf.Clamp(_CameraRotation.y,m_CameraPitchLimitMin, m_CameraPitchLimitMax);

        // 현재 카메라 회전을 얻습니다.
        Vector3 cameraCurrentRotation = m_CameraPivotTransform.eulerAngles;

        // 입력 축 값 적용
        cameraCurrentRotation.y = _CameraRotation.x;
        cameraCurrentRotation.x = _CameraRotation.y;
        m_CameraPivotTransform.eulerAngles = cameraCurrentRotation;
    }

    /// <summary>
    /// 카메라가 따라가도록 합니다.
    /// </summary>
    private void CameraTracking()
    {
        // 현재 카메라 기준점 위치
        Vector3 cameraPivotPosition = m_CameraPivotTransform.position;

        // 목적지
        Vector3 targetPosition = transform.position;

        // Lerp : 선형보간 함수
        Vector3 newPosition = Vector3.Lerp(cameraPivotPosition, targetPosition, 10.0f * Time.deltaTime);
        m_CameraPivotTransform.position = newPosition;

        // m_CameraPivotTransform.position = transform.position;
    }

    private bool CheckGameOver()
    {
        return (transform.position.y < -5.0f);
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        float radius = GetComponent<SphereCollider>().radius - 0.05f;

        // 구체 영역의 중심 위치
        Vector3 center = transform.position + (Vector3.down * 0.1f);

        // 다음으로 그릴 기즈모의 색상을 결정합니다.
        Gizmos.color = Color.red;

        // 선으로 구성된 구체를 그립니다.
        Gizmos.DrawWireSphere(center, radius);
    }
#endif
}
