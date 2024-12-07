using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoFollowCamera : MonoBehaviour
{
    public Transform target;  // ���� ������Ʈ(Dino)
    public Vector3 offset;  // ī�޶� �����Ÿ��� �����ϱ� ���� �Ÿ��α� ��ŭ�� ����

    void Start()
    {
        offset = target.position - transform.position;  // ��(Camera)�� Target(Dino)�� ��ŭ ������ �ִ��� ����
    }

    void LateUpdate()
    {
        // ����ڵ�
        if (target != null)
        {
            // ī�޶��� ���ο� ��ġ�� ���(Dino�� ��, ��� �������� z�ุ ����)
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, target.position.z - offset.z);

            // ī�޶� ��ġ�� ������Ʈ
            transform.position = newPosition;
        }
    }
}
