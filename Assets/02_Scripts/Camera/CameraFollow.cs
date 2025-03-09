using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    [Header("Camera")]    
    public Vector3 offset = new Vector3(0, -5f, -2); // Player로부터 떨어질 간격
    public float smoothSpeed = 5f; //플레이어를 따라 다니며 움직일 속도
    public int fieldOfView = 110; //카메라의 시야각을 설정하는 변수
    private void Start()
    {
        Camera.main.fieldOfView = fieldOfView; 
    }
    private void LateUpdate()
    {
        if (player != null)
        {
            Vector3 targetPosition = player.position + player.rotation * offset; //Player를 기준으로 카메라의 위치를 결정하기위한 연산
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);

            transform.LookAt(player.position); // 플레이어의 위치를 바라보도록 카메라의 위치를 결정
        }
    }
}
