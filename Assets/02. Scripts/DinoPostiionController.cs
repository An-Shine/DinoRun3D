using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoPostiionController : MonoBehaviour
{
    public float radius = 1f; // 배치될 원의 반지름
    public float ratio = 0.1f; // 배치간격비율( 작을수록 촘촘)
    public Transform raptors;  // raptor 를 관리할 부모 오브젝트
    public int visibleCount; // 보여주고싶은 갯수를 입력하면 이 갯수만큼만 dino 표시
    float angleStep;


    void Start()
    {
        
    }

   
    void Update()
    {

        SetDinoPosition();
        /* for(int i = 0; i<transform.childCount; i++) //child 수를 셈
        {
            float zGap = i * 4;
            //transform.GetChild(i).position = Vector3.back * zGap;
            transform.GetChild(i).position = Vector3.back * -zGap;
        }          1열로 쭉~ 세우기
       */ 


    }

    private void SetDinoPosition()
    {
        
        for (int i = 0; i<raptors.childCount; i++)
        {
            if (i >= visibleCount)
            {
                raptors.GetChild(i).gameObject.SetActive(false);
                continue;
            }
            else
            {
                if(raptors.childCount >= visibleCount)
                {
                    angleStep = 360f / (visibleCount * ratio);
                }
                else
                {
                    angleStep = 360f / (raptors.childCount * ratio);
                }
                
                float angle = i * angleStep;  //각 개인자식 오브젝트의 배치각도계산
                float angleRad = Mathf.Deg2Rad * angle;  // x,z 축 좌표를 구해야함
                float x = Mathf.Cos(angleRad) * radius;
                float z = Mathf.Sin(angleRad) * radius;

                raptors.GetChild(i).localPosition = new Vector3(x, 0, z);
                
            }
           
        }

     
        
    }
    
}
