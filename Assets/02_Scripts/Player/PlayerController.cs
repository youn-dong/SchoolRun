using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed; //움직임 속도
    public float jumpForce = 20f; //기본점프력
    private Vector2 curMovementInput;
    private Rigidbody _rigidbody; 
    public LayerMask groundLayerMask; //Player가 확인 가능한 Ray

    private bool isGrounded;

    private Animator animator;

    [Header("Player 좌,우 회전속도")]
    public float rotationSpeed;

    private Vector2 mouseDelta;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        isGrounded = GroundCheck(); //Ray를 통한 계속적인 점프가능조건 체크
        animator.SetBool("Grounded", isGrounded);
    }
    void FixedUpdate() //물리연산은 FixedUpdate 생명주기함수에서 하는것이 유리.
    {
        Move();
    }

    void Move() //W,A,S,D키를 통한 Player 이동 구현
    {
        Vector3 dir = transform.forward * curMovementInput.y;
        dir *= moveSpeed;
        dir.y = _rigidbody.velocity.y; //점프시 중력을 유지해주기 위해서.

        _rigidbody.velocity = dir;
        if (curMovementInput.x > 0.0f)
        {
            transform.eulerAngles += Time.deltaTime * rotationSpeed * Vector3.up;
        }
        else if (curMovementInput.x < 0.0f)
        {
            transform.eulerAngles -= Time.deltaTime * rotationSpeed * Vector3.up;
        }
        if (curMovementInput.y < 0.0f) // S 키를 통한 180도 회전
        {
            transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y + 180, 0);
        }
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
            if(ChracterManager.Instance.Player.conditions.stamina.curValue <5f) //점프할 수 있는 스태미나가 없는 경우
            {
                Debug.Log("Jump할 Stamina가 없습니다.");
                return;
            }
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            ChracterManager.Instance.Player.conditions.DecreaseStamina(5f); //점프시 스태미너가 5씩 감소하도록 
        }
    }
    bool GroundCheck() // 플레이어의 위치로부터 받는 Ray를 통한 IsGrounded의 Bool값을 반환
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
            if (Physics.Raycast(rays[i], 0.5f, groundLayerMask))
            {
                return true;
            }
        }
        return false;
    }
    //private void OnDrawGizmos() //Ray의 범위를 확인하기 위한 로직
    //{
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    Debug.DrawRay(ray.origin,ray.direction*3,Color.white);
    //}
}
