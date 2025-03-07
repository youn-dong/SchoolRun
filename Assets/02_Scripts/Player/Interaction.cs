using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    public float checkRate = 0.05f;
    private float lastCheckTime;
    public float maxCheckDistance;
    public LayerMask layerMask;

    public GameObject curInteractGameObject;
    private IInteractable curInteractable;

    public TextMeshProUGUI promptTxt;

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
        if(context.phase == InputActionPhase.Started && curInteractable != null)
        {
            curInteractable.OnInteract();
            curInteractGameObject = null;
            curInteractable = null;
            promptTxt.gameObject.SetActive(false);
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
                    SetPromptText();
                    //Ray에 담겨있는 게임오브젝트가 새로운 거라면 프롬포트를 출력해줘라.
                }
            }
            else
            {
                curInteractable = null;
                curInteractGameObject = null;
                promptTxt.gameObject.SetActive(false);
            }
        }
    }
}

