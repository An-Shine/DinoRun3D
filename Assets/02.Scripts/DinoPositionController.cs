using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoPositionController : MonoBehaviour
{
    public Transform raptors;  // Raptor���� ������ �θ� ������Ʈ
    public GameObject raptorPrefab;  // �߰��� Raptor ������

    public float initialRadius = 1f; // ù ������Ʈ�� ������
    public float radiusGrowth = 0.5f;  // ������Ʈ �� ������ ������
    public float angleIncrement = 137.508f;  // ���� ���� ���� (���� ��� �ޱ� ���)

    public int visibleCount;  // �����ְ� ���� ������ �Է��ϸ� �� ������ŭ�� dino ǥ��

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
                // ������ �ʴ´�.
                raptors.GetChild(i).gameObject.SetActive(false);
                continue;
            }
            else
            {
                float currentRadius = initialRadius + (radiusGrowth * i);   // �������� ���� Ŀ��

                float angle = i * angleIncrement; // ��� ������ ������ ���� ����

                // ������ ���� ������ ��ȯ �� ��ǥ ���
                float x = Mathf.Cos(angle * Mathf.Deg2Rad)*currentRadius;
                float z = Mathf.Sin(angle * Mathf.Deg2Rad) * currentRadius;

                // ��ġ ����
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
                // ������ �ʴ´�.
                raptors.GetChild(i).gameObject.SetActive(false);
                continue;
            }
            else
            {
                if (raptors.childCount >= visibleCount)
                {
                    // 360�� ������ Dino�� ������ ���� ����, ������ �������̴�.
                    angleStep = 360f / (visibleCount * ratio);
                }
                else
                {
                    // 360�� ������ Dino�� ������ ���� ����, ������ �������̴�.
                    angleStep = 360f / (raptors.childCount * ratio);
                }

                float angle = i * angleStep;  //  �ڽ� ������Ʈ �� ���� ��ġ ���� ���

                // ������ �������� ���
                float angleRad = Mathf.Deg2Rad * angle;

                //x�� z�� ��ǥ�� ���ؾ� �Ѵ�.

                float x = Mathf.Cos(angleRad) * radius;   // 1
                float z = Mathf.Sin(angleRad) * radius;   // 0

                // ���ο� ��ǥ�� �ڽ� ������Ʈ�� ��ġ�Ŵ�.
                raptors.GetChild(i).localPosition = new Vector3(x, 0, z);
            }
        }
    }
    */

    // ���� �޾Ƽ� ����� �� �ִ� �Լ� 
    public void SetDoorCalc(DoorType doorType, int doorNumber)
    {
        if (doorType.Equals(DoorType.Plus))  // ���ϱ�
        {
            PlusRaptor(doorNumber);
        }
        else if (doorType.Equals(DoorType.Minus)) // ����
        {
            MinusRaptor(doorNumber);
        }
        else if (doorType.Equals(DoorType.Times))  // ���ϱ�
        {
            int raptorNum = (raptors.childCount * doorNumber) - raptors.childCount;
            PlusRaptor(raptorNum);
        }
        else if (doorType.Equals(DoorType.Division))  // ������
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
        // ������ ���ڰ� ���� ���� Raptor�� ���ں��� ũ�ٸ�
        if(number > raptors.childCount)
        {
            number = raptors.childCount;  // �ڱ� �ڽ��� ���ڷ� ���� ( ������ ���� 0�� ���״ϱ�)
        }

        int raptorNumber = raptors.childCount;  // ���� ���� Raptor ���ڸ� ���ϰ�

        for(int i = raptorNumber-1; i >= (raptorNumber - number); i--)
        {
            Destroy(raptors.GetChild(i).gameObject);  // �� ������ ������Ʈ���� ���� ��ŵ�ϴ�.
        }
    }
}
