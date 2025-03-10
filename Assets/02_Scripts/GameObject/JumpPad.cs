using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [Header("Jump")]
    public float jumpForce;

    private void OnTriggerEnter(Collider other) //Ontrigger를 통한 Collider 충돌 여부 확인
    {
        if(other.CompareTag("Player")) //충돌은 Player만 가능하도록 Tag를 통한 설정
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                if(gameObject.CompareTag("DamagePad"))
                {
                    ChracterManager.Instance.Player.conditions.health.SubStract(10f); //데미지 패드를 밟을 때마다 10의 체력을 감소시키기.
                }
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
            
        }
        
    }

}
