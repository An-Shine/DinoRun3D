using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoFollowCamera : MonoBehaviour
{
    public Transform target; //따라갈 오브젝트(Dino)
    public Vector3 offset; //카메라가 일정거리를 유지하기 위한 거리두기 만큼의 차이
    public float speedZ;
    void Start()
    {
        offset = target.position - transform.position; // 나(카메라)가 Dino(Target)와 얼마나 떨어져있는지 차이    
    }

   
    void LateUpdate()
    {
        //방어코드
        if(target != null)
        {
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, target.position.z - offset.z);
            transform.position = newPosition;
        }
    }
}
