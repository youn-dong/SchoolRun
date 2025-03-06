using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float jumpForce = 20f;
    private Vector2 curMovementInput;
    private Rigidbody _rigidbody;
    public LayerMask groundLayerMask;

    private bool isGrounded;

    [Header("Animation")]
    private Animator animator;

    [Header("Look")]
    public Transform cameraContainer;
    public float minXLook;
    public float maxXLook;
    private float camCurXRot;
    public float lookSensivity;
    bool canLook = true;

    public float rotationSpeed;

    private Vector2 mouseDelta;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        isGrounded = GroundCheck();
        animator.SetBool("Grounded", isGrounded);
    }
    void FixedUpdate() //물리연산은 FixedUpdate 생명주기함수에서 하는것이 유리.
    {
        Move();
    }
    //private void LateUpdate()
    //{
    //    if (canLook)
    //    {
    //        CameraLook();
    //    }
    //}

    void Move()
    {

        // 1. 캐릭터 정지할때(캐릭터가 바라보고 있는 방향으로) 회전값
        // 2. 캐릭터가 이동할 때 

        Debug.Log(curMovementInput);
        // Vector3 dir = transform.forward * curMovementInput;// .y + transform.right * curMovementInput.x;
        // Vector3 dir = (transform.forward * curMovementInput.y+transform.right*curMovementInput.x).normalized;
        Vector3 dir = transform.forward*curMovementInput.y;
        dir *= moveSpeed;
        dir.y = _rigidbody.velocity.y; //점프시 중력을 유지해주기 위해서.

        _rigidbody.velocity = dir;
        if(curMovementInput.x > 0.0f)
        {
            transform.eulerAngles += Time.deltaTime * rotationSpeed * Vector3.up;
        }
        else if(curMovementInput.x<0.0f)
        {
            transform.eulerAngles -= Time.deltaTime * rotationSpeed * Vector3.up;
        }
        if (curMovementInput.y < 0.0f) // S 키 → 뒤로 이동 + 180도 회전
        {
            transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y + 180, 0);
        }
        //if(dir != Vector3.zero)
        //{
        //    Quaternion targetRotaion = Quaternion.LookRotation(dir);
        //    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotaion, Time.deltaTime * rotationSpeed);
        //}
        //if (curMovementInput.sqrMagnitude > 0)
        //{
        //    RotateChar();
        //}
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            Debug.Log("움직여라");
            curMovementInput = context.ReadValue<Vector2>();
            animator.SetFloat("MoveSpeed", moveSpeed);
        }
        else if(context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
            animator.SetFloat("MoveSpeed", 0);
        }
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log("Jump");
        if(context.phase == InputActionPhase.Started&&isGrounded)
        {
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    bool GroundCheck()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward*0.3f) + (transform.up*0.01f),Vector3.down),
                new Ray(transform.position + (-transform.forward * 0.3f) + (transform.up * 0.01f), Vector3.down),
                new Ray(transform.position + (transform.right*0.3f) + (transform.up*0.01f),Vector3.down),
                new Ray(transform.position + (-transform.right*0.3f) + (transform.up*0.01f),Vector3.down),
        };
        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.1f, groundLayerMask))
            {
                return true;
            }
        }
        return false;
    }

    void RotateChar()
    {
        //if (curMovementInput.magnitude > 0.1f)
        //{
        //    float targetAngle = Mathf.Atan2() * Mathf.Rad2Deg;
        //    //tan를 통해서 구한 값에 각을 곱해서 이동 방향의 각을 계산
        //    Quaternion targetRot = Quaternion.Euler(0, targetAngle, 0);

        //    transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, Time.deltaTime * rotationSpeed);
        //    //Lerp함수를 이용해서 원하는 targetAngle까지 rotationspeed와 시간에 맞춰 자연스럽게 회전하도록
        //}
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            mouseDelta = context.ReadValue<Vector2>();
        }
    }
    void CameraLook()
    {
        camCurXRot += mouseDelta.y * lookSensivity;
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
        cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0);

        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensivity,0);
    }
}
