using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public float checkRate = 0.05f;
    private float lastCheckTime;
    public float maxCheckDistance;
    public LayerMask layerMask;

    public GameObject curInteractGameObject;
    private IInteractable curInteractable;

    public TextMeshProUGUI promptTxt;
    private Camera camera;
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxCheckDistance, layerMask))
        {
            if(hit.collider.gameObject != curInteractGameObject)
            {
                curInteractGameObject = hit.collider.gameObject;
                curInteractable = hit.collider.GetComponent<IInteractable>();
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
    private void SetPromptText()
    {
        promptTxt.gameObject.SetActive(true);
        promptTxt.text = curInteractable.GetInteractPrompt();
    }
}
