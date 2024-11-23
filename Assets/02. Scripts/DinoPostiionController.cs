using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoPostiionController : MonoBehaviour
{
    
    public float initialRadius = 1f;
    public float radiusGrowth = 0.5f;
    public float angleIncrement = 137.508f;
    public Transform raptors;  // raptor �� ������ �θ� ������Ʈ
    public GameObject raptorPrefabs; //�߰��� raptor ������
    public int visibleCount; // �����ְ���� ������ �Է��ϸ� �� ������ŭ�� dino ǥ��
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
                float currentRadius = initialRadius + (radiusGrowth * i); // �������� ���� Ŀ��
                float angle = i * angleIncrement; // ��� ������ ������ ���� ����

                //������ ���� ������ ��ȯ �� ��ǥ���
                float x = Mathf.Cos(angle * Mathf.Deg2Rad) * currentRadius;
                float z = Mathf.Sin(angle * Mathf.Deg2Rad) * currentRadius;

                //��ġ����
                raptors.GetChild(i).localPosition = new Vector3(x, 0, z);

            }
        }
    }

    
    public void SetDoorCalc(DoorType doorType, int doorNumber)
        //���� �޾Ƽ� ����Ҽ��ִ� �Լ�
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
        if(number > raptors.childCount) //������ ���ڰ� ���� raptor ���ں��� Ŭ��
        {
            number = raptors.childCount; //�ڱ��ڽ��� ���ڷ� ����(���� 0�̵ǵ���)
        }
        int raptorNumber = raptors.childCount; // ���� ���� raptor���ڸ� ���ϰ�
        for(int i = raptorNumber-1; i>=(raptorNumber-number); i--) // Getchild���� �������°� 0�����ͱ⶧���� 1���ֱ�
        {
            Destroy(raptors.GetChild(i).gameObject);  //�Ǹ����� ������Ʈ���� ����
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

                float angle = i * angleStep;  //�� �����ڽ� ������Ʈ�� ��ġ�������
                float angleRad = Mathf.Deg2Rad * angle;  // x,z �� ��ǥ�� ���ؾ���
                float x = Mathf.Cos(angleRad) * radius;
                float z = Mathf.Sin(angleRad) * radius;

                raptors.GetChild(i).localPosition = new Vector3(x, 0, z);

            }

        }




    }*/



}
