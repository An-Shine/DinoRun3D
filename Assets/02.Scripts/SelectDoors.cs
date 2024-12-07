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

    public SpriteRenderer rightDoorSpriteRD;  // 오른쪽 문의 색을 관리할 변수
    public SpriteRenderer leftDoorSpriteRD;   // 왼쪽 문의 색을 관리할 변수
    public TextMeshPro rightDoorText;   //오른쪽 문의 Text를 관리할 변수
    public TextMeshPro leftDoorText;    //왼쪽 문의 Text를 관리할 변수

    [SerializeField]
    private DoorType rightDoorType;     // 오른쪽 문의 상태를 관리할 변수
    public int rightDoorNumber;        // 오른쪽 문에서 계산될 숫자 변수
    [SerializeField]
    private DoorType leftDoorType;      // 왼쪽 문의 상태를 관리할 변수
    public int leftDoorNumber;         // 왼쪽 문에서 계산될 숫자 변수

    public Color goodColor;             // 좋은쪽 문의 색
    public Color badColor;              // 나쁜쪽 문의 색


    void Start()
    {
        SettingDoors();
    }

    void Update()
    {

    }

    public void SettingDoors()
    {
        // 오른쪽 문 세팅
        if (rightDoorType.Equals(DoorType.Plus)) // Plus로 설정 했을 때 실행
        { 
            rightDoorSpriteRD.color = goodColor;
            rightDoorText.text = "+" + rightDoorNumber;
        }
        else if (rightDoorType.Equals(DoorType.Minus)) // Minus로 설정 했을 때 실행
        {
            rightDoorSpriteRD.color = badColor;
            rightDoorText.text = "-" + rightDoorNumber;
        }
        else if (rightDoorType.Equals(DoorType.Times)) // 곱하기
        {
            rightDoorSpriteRD.color = goodColor;
            rightDoorText.text = "x" +rightDoorNumber;
        }
        else if (rightDoorType.Equals(DoorType.Division)) // 나누기
        {
            rightDoorSpriteRD.color = badColor;
            rightDoorText.text = "/" + rightDoorNumber;
        }


        // 왼쪽 문 세팅
        if (leftDoorType.Equals(DoorType.Plus)) // Plus로 설정 했을 때 실행
        {
            leftDoorSpriteRD.color = goodColor;
            leftDoorText.text = "+" + leftDoorNumber;
        }
        else if (leftDoorType.Equals(DoorType.Minus)) // Minus로 설정 했을 때 실행
        {
            leftDoorSpriteRD.color = badColor;
            leftDoorText.text = "-" + leftDoorNumber;
        }
        else if (leftDoorType.Equals(DoorType.Times)) // 곱하기
        {
            leftDoorSpriteRD.color = goodColor;
            leftDoorText.text = "x" + leftDoorNumber;
        }
        else if (leftDoorType.Equals(DoorType.Division)) // 나누기
        {
            leftDoorSpriteRD.color = badColor;
            leftDoorText.text = "/ " + leftDoorNumber;
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
        if (xPos > 0) // Dino의 위치값이 0보다 크면,
        {
            return rightDoorNumber;
        }
        else
        {
            return leftDoorNumber;
        }
    }

}
