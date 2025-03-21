using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    [Header("상호작용")]
    public float checkRate = 0.05f; //Lay를 통해서 확인할 시간
    private float lastCheckTime; //체크시간
    public float maxCheckDistance; //상호작용 최대 거리
    public LayerMask layerMask; //감지할 수 있는 레이어
    public GameObject curInteractGameObject; //현재 상호작용중인 GameObject

    public TextMeshProUGUI promptTxt; //상호작용시 Text

    private IInteractable curInteractable; //상호작용 가능 가변(소유)아이템

    private IInterEnvironment curEnvironment; //상호작용 가능 고정아이템

    // Update is called once per frame
    void Update()
    {
        CheckInteraction();
    }
    private void SetPromptText()
    {
        promptTxt.gameObject.SetActive(true);
        promptTxt.text = curInteractable.GetInteractPrompt();
    }
    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            if(curInteractable != null)
            {
                curInteractable.OnInteract(); //소유아이템과 상호작용
                ClearPrompt();
            }
            else if(curEnvironment != null)
            {
                curEnvironment.OnInteractEnvironment();
                ClearPrompt();
            }
           
        }
    }
    public void CheckInteraction()
    {
        if (Time.time - lastCheckTime > checkRate)
        {
            lastCheckTime = Time.time;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, maxCheckDistance, layerMask))
            {
                if (hit.collider.gameObject != curInteractGameObject)
                {
                    curInteractGameObject = hit.collider.gameObject;
                    curInteractable = hit.collider.GetComponent<IInteractable>();
                    curEnvironment = hit.collider.GetComponent<IInterEnvironment>();

                    if(curInteractable !=null)
                    {
                        promptTxt.gameObject.SetActive(true);
                        SetPromptText();
                    }
                    else if(curEnvironment != null)
                    {
                        promptTxt.gameObject.SetActive(true);
                        promptTxt.text = "마우스 우클릭을 통한 상호작용!";
                    }
                    else
                    {
                        ClearPrompt();
                    }
                }
            }
            else
            {
                ClearPrompt();
            }
        }
    }
    public void ClearPrompt()
    {
        curInteractable = null;
        curInteractGameObject = null;
        curEnvironment = null;
        promptTxt.gameObject.SetActive(false);
    }
}

