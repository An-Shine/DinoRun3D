using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoPostiionController : MonoBehaviour
{
    public float radius = 1f; // ��ġ�� ���� ������
    public float ratio = 0.1f; // ��ġ���ݺ���( �������� ����)
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
        /* for(int i = 0; i<transform.childCount; i++) //child ���� ��
        {
            float zGap = i * 4;
            //transform.GetChild(i).position = Vector3.back * zGap;
            transform.GetChild(i).position = Vector3.back * -zGap;
        }          1���� ��~ �����
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
                
                float angle = i * angleStep;  //�� �����ڽ� ������Ʈ�� ��ġ�������
                float angleRad = Mathf.Deg2Rad * angle;  // x,z �� ��ǥ�� ���ؾ���
                float x = Mathf.Cos(angleRad) * radius;
                float z = Mathf.Sin(angleRad) * radius;

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

        }
        else if (doorType.Equals(DoorType.Times))
        {

        }
        else if (doorType.Equals(DoorType.Division))
        {

        }
    }
    private void PlusRaptor(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Instantiate(raptorPrefabs, raptors);
        }
        
        

    }

}
