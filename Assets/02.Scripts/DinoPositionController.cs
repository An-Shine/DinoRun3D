using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoPositionController : MonoBehaviour
{
    public Transform raptors;  // Raptor들을 관리할 부모 오브젝트
    public GameObject raptorPrefab;  // 추가할 Raptor 프리팹

    public float initialRadius = 1f; // 첫 오브젝트의 반지름
    public float radiusGrowth = 0.5f;  // 오브젝트 간 반지름 증가량
    public float angleIncrement = 137.508f;  // 각도 증가 비율 (보통 골든 앵글 사용)

    public int visibleCount;  // 보여주고 싶은 개수를 입력하면 이 개수만큼만 dino 표시

    void Start()
    {

    }

    void Update()
    {
        SetDinoPosition();
    }

    private void SetDinoPosition()
    {
        for (int i = 0; i < raptors.childCount; i++)
        {
            if (i >= visibleCount)
            {
                // 보이지 않는다.
                raptors.GetChild(i).gameObject.SetActive(false);
                continue;
            }
            else
            {
                float currentRadius = initialRadius + (radiusGrowth * i);   // 반지름이 점점 커짐

                float angle = i * angleIncrement; // 골든 각도로 각도가 점점 증가

                // 각도를 라디안 단위로 변환 후 좌표 계산
                float x = Mathf.Cos(angle * Mathf.Deg2Rad)*currentRadius;
                float z = Mathf.Sin(angle * Mathf.Deg2Rad) * currentRadius;

                // 위치 설정
                raptors.GetChild(i).localPosition = new Vector3(x, 0, z);
            }
        }
    }

    /*
    private void SetDinoPosition()
    {
        for (int i = 0; i < raptors.childCount; i++)
        {
            if (i >= visibleCount)
            {
                // 보이지 않는다.
                raptors.GetChild(i).gameObject.SetActive(false);
                continue;
            }
            else
            {
                if (raptors.childCount >= visibleCount)
                {
                    // 360도 각도를 Dino의 개수로 나눈 수로, 각도의 증가값이다.
                    angleStep = 360f / (visibleCount * ratio);
                }
                else
                {
                    // 360도 각도를 Dino의 개수로 나눈 수로, 각도의 증가값이다.
                    angleStep = 360f / (raptors.childCount * ratio);
                }

                float angle = i * angleStep;  //  자식 오브젝트 각 개인 배치 각도 계산

                // 각도를 라디안으로 계산
                float angleRad = Mathf.Deg2Rad * angle;

                //x와 z축 좌표를 구해야 한다.

                float x = Mathf.Cos(angleRad) * radius;   // 1
                float z = Mathf.Sin(angleRad) * radius;   // 0

                // 새로운 좌표로 자식 오브젝트를 위치신다.
                raptors.GetChild(i).localPosition = new Vector3(x, 0, z);
            }
        }
    }
    */

    // 값을 받아서 계산할 수 있는 함수 
    public void SetDoorCalc(DoorType doorType, int doorNumber)
    {
        if (doorType.Equals(DoorType.Plus))  // 더하기
        {
            PlusRaptor(doorNumber);
        }
        else if (doorType.Equals(DoorType.Minus)) // 빼기
        {
            MinusRaptor(doorNumber);
        }
        else if (doorType.Equals(DoorType.Times))  // 곱하기
        {
            int raptorNum = (raptors.childCount * doorNumber) - raptors.childCount;
            PlusRaptor(raptorNum);
        }
        else if (doorType.Equals(DoorType.Division))  // 나누기
        {
            int raptorNum = raptors.childCount - (raptors.childCount / doorNumber);
            MinusRaptor(raptorNum);
        }
    }

    private void PlusRaptor(int number)
    {
        for (int i = 0; i < number; i++) 
        {
            Instantiate(raptorPrefab, raptors);
        }
    }

    private void MinusRaptor(int number)
    {
        // 빼려는 숫자가 현재 나의 Raptor의 숫자보다 크다면
        if(number > raptors.childCount)
        {
            number = raptors.childCount;  // 자기 자신의 숫자로 세팅 ( 어차피 빼면 0이 될테니까)
        }

        int raptorNumber = raptors.childCount;  // 현재 나의 Raptor 숫자를 구하고

        for(int i = raptorNumber-1; i >= (raptorNumber - number); i--)
        {
            Destroy(raptors.GetChild(i).gameObject);  // 맨 마지막 오브젝트부터 삭제 시킵니다.
        }
    }
}
