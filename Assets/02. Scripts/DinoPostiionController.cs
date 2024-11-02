using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoPostiionController : MonoBehaviour
{
    public float radius = 1f; // 배치될 원의 반지름
    public float ratio = 0.1f; // 배치간격비율( 작을수록 촘촘)
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
        float angleStep = 360f / (transform.childCount*ratio); // 360도를 Dino 갯수로 나눈값, 각도의 증가값
        for (int i = 0; i<transform.childCount; i++)
        {
            float angle = i * angleStep;  //각 개인자식 오브젝트의 배치각도계산
            float angleRad = Mathf.Deg2Rad * angle;  // x,z 축 좌표를 구해야함
            float x = Mathf.Cos(angleRad) * radius;
            float z = Mathf.Sin(angleRad) * radius;

            transform.GetChild(i).localPosition = new Vector3(x, 0, z);
        }
    }

}
