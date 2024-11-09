using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoPostiionController : MonoBehaviour
{
    public float radius = 1f; // ��ġ�� ���� ������
    public float ratio = 0.1f; // ��ġ���ݺ���( �������� ����)
    public Transform raptors;  // raptor �� ������ �θ� ������Ʈ
    public int visibleCount; // �����ְ���� ������ �Է��ϸ� �� ������ŭ�� dino ǥ��



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
        float angleStep = 360f / (raptors.childCount*ratio); // 360���� Dino ������ ������, ������ ������
        for (int i = 0; i<raptors.childCount; i++)
        {
            float angle = i * angleStep;  //�� �����ڽ� ������Ʈ�� ��ġ�������
            float angleRad = Mathf.Deg2Rad * angle;  // x,z �� ��ǥ�� ���ؾ���
            float x = Mathf.Cos(angleRad) * radius;
            float z = Mathf.Sin(angleRad) * radius;

            raptors.GetChild(i).localPosition = new Vector3(x, 0, z);
        }
    }

}
