using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public enum DoorType
{
    Plus,
    Minus,
    Times,
    Division
}
public class SelectDoors : MonoBehaviour
{
   

    public SpriteRenderer rightDoorSpriteRD; // �����ʹ��� ���� �����ϴ� ����
    public SpriteRenderer leftDoorSpriteRD; // ���ʹ��� ���� �����ϴ� ����
    public TextMeshPro rightDoorText; // �����ʹ��� Text �� ������ ����
    public TextMeshPro leftDoorText; // ���ʹ��� Text�� ������ ����

    [SerializeField]

    private DoorType rightDoorType; //�����ʹ��� ���¸� �����ϴ� ����
    public int rightDoorNumber; // �����ʹ����� ���� ���ں���

    [SerializeField]   // ����Ƽ���� ��ũ��Ʈ���� private �ʵ带 �ν����� â�� ������Ѽ� �����Ҽ��ְԸ���� �Ӽ�

    private DoorType leftDoorType; //���ʹ��� ���¸� �����ϴ� ����
    public int leftDoorNumber; // ���ʹ����� ���� ���ں���

    public Color goodColor; // �����ʹ��� ��
    public Color badColor; // ������ ���� ��
    void Start()
    {
        SettingDoors();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SettingDoors()
    {

        //�����ʹ� ����
        if(rightDoorType.Equals(DoorType.Plus)) // plus�� ����������
        {
            rightDoorSpriteRD.color = goodColor;
            rightDoorText.text = "+" + rightDoorNumber;
        }

        else if (rightDoorType.Equals(DoorType.Minus)) // minus �� ����������
        {
            rightDoorSpriteRD.color = badColor;
            rightDoorText.text = "-" + rightDoorNumber;
        }
        else if (rightDoorType.Equals(DoorType.Times)) // minus �� ����������
        {
            rightDoorSpriteRD.color = goodColor;
            rightDoorText.text = "x" + rightDoorNumber;
        }
        else if (rightDoorType.Equals(DoorType.Division)) // minus �� ����������
        {
            rightDoorSpriteRD.color = badColor;
            rightDoorText.text = "/" + rightDoorNumber;
        }

        //���ʹ� ����
        if (leftDoorType.Equals(DoorType.Plus)) // plus�� ����������
        {
            leftDoorSpriteRD.color = goodColor;
            leftDoorText.text = "+" + leftDoorNumber;
        }

        else if (leftDoorType.Equals(DoorType.Minus)) // minus �� ����������
        {
            leftDoorSpriteRD.color = badColor;
            leftDoorText.text = "-" + leftDoorNumber;
        }
        else if (leftDoorType.Equals(DoorType.Times)) // minus �� ����������
        {
            leftDoorSpriteRD.color = goodColor;
            leftDoorText.text = "x" + leftDoorNumber;
        }
        else if (leftDoorType.Equals(DoorType.Division)) // minus �� ����������
        {
            leftDoorSpriteRD.color = badColor;
            leftDoorText.text = "/" + leftDoorNumber;
        }
    }

    public DoorType GetDoorType(float xPos)
    {
        if (xPos > 0)
        {
            return rightDoorType;
        }
        else
        {
            return leftDoorType;
        }

    }
    public int GetDoorNumber(float xPos)
    {
        if(xPos>0)
        {
            return rightDoorNumber;
        }
        else
        {
            return leftDoorNumber;

        }
    }
}
