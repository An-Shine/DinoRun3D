using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoPostiionController : MonoBehaviour
{
    
    public float initialRadius = 1f;
    public float radiusGrowth = 0.5f;
    public float angleIncrement = 137.508f;
    public Transform raptors;  // raptor 를 관리할 부모 오브젝트
    public GameObject raptorPrefabs; //추가할 raptor 프리팹
    public int visibleCount; // 보여주고싶은 갯수를 입력하면 이 갯수만큼만 dino 표시
    float angleStep;


    void Start()
    {
        
    }

   
    void Update()
    {
        SetDinoPosition();
        
       


    }
    public void SetDinoPosition()
    {
        for (int i = 0; i < raptors.childCount; i++)
        {
            if ( i >=visibleCount)
            {
                raptors.GetChild(i).gameObject.SetActive(false);
                continue;
            }
            else
            {
                float currentRadius = initialRadius + (radiusGrowth * i); // 반지름이 점점 커짐
                float angle = i * angleIncrement; // 골든 각도로 각도가 점점 증가

                //각도를 라디안 단위로 변환 후 좌표계산
                float x = Mathf.Cos(angle * Mathf.Deg2Rad) * currentRadius;
                float z = Mathf.Sin(angle * Mathf.Deg2Rad) * currentRadius;

                //위치설정
                raptors.GetChild(i).localPosition = new Vector3(x, 0, z);

            }
        }
    }

    
    public void SetDoorCalc(DoorType doorType, int doorNumber)
        //값을 받아서 계산할수있는 함수
    {
        if (doorType.Equals(DoorType.Plus))
        {
            PlusRaptor(doorNumber);
        }
        else if (doorType.Equals(DoorType.Minus))
        {
            MinusRaptor(doorNumber);
        }
        else if (doorType.Equals(DoorType.Times))
        {
            int raptorNum = (raptors.childCount * doorNumber) - raptors.childCount;
            PlusRaptor(raptorNum);
        }
        else if (doorType.Equals(DoorType.Division))
        {
            int raptorNum = raptors.childCount - (raptors.childCount / doorNumber);
            MinusRaptor(raptorNum);
        }
    }
    private void PlusRaptor(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Instantiate(raptorPrefabs, raptors);
        }
        
        

    }
    private void MinusRaptor(int number)
    {
        if(number > raptors.childCount) //빼려는 숫자가 나의 raptor 숫자보다 클때
        {
            number = raptors.childCount; //자기자신의 숫자로 세팅(빼면 0이되도록)
        }
        int raptorNumber = raptors.childCount; // 현재 나의 raptor숫자를 구하고
        for(int i = raptorNumber-1; i>=(raptorNumber-number); i--) // Getchild에서 가져오는게 0번부터기때문에 1빼주기
        {
            Destroy(raptors.GetChild(i).gameObject);  //맨마지막 오브젝트부터 삭제
        }

    }

    /*private void SetDinoPosition()
    {

        for (int i = 0; i < raptors.childCount; i++)
        {
            if (i >= visibleCount)
            {
                raptors.GetChild(i).gameObject.SetActive(false);
                continue;
            }
            else
            {
                if (raptors.childCount >= visibleCount)
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




    }*/



}
