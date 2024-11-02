using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoFollowCamera : MonoBehaviour
{
    public Transform target; //���� ������Ʈ(Dino)
    public Vector3 offset; //ī�޶� �����Ÿ��� �����ϱ� ���� �Ÿ��α� ��ŭ�� ����
    public float speedZ;
    void Start()
    {
        offset = target.position - transform.position; // ��(ī�޶�)�� Dino(Target)�� �󸶳� �������ִ��� ����    
    }

   
    void LateUpdate()
    {
        //����ڵ�
        if(target != null)
        {
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, target.position.z - offset.z);
            transform.position = newPosition;
        }
    }
}
