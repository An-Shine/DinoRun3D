using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoFollowCamera : MonoBehaviour
{
    public Transform target;  // 따라갈 오브젝트(Dino)
    public Vector3 offset;  // 카메라가 일정거리를 유지하기 위한 거리두기 만큼의 차이

    void Start()
    {
        offset = target.position - transform.position;  // 나(Camera)가 Target(Dino)와 얼만큼 떨어져 있는지 차이
    }

    void LateUpdate()
    {
        // 방어코드
        if (target != null)
        {
            // 카메라의 새로운 위치를 계산(Dino가 좌, 우로 움직여도 z축만 따라감)
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, target.position.z - offset.z);

            // 카메라 위치를 업데이트
            transform.position = newPosition;
        }
    }
}
