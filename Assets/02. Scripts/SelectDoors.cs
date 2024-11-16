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
   

    public SpriteRenderer rightDoorSpriteRD; // 오른쪽문의 색을 관리하는 변수
    public SpriteRenderer leftDoorSpriteRD; // 왼쪽문의 색을 관리하는 변수
    public TextMeshPro rightDoorText; // 오른쪽문의 Text 를 관리할 변수
    public TextMeshPro leftDoorText; // 왼쪽문의 Text를 관리할 변수

    [SerializeField]

    private DoorType rightDoorType; //오른쪽문의 상태를 관리하는 변수
    public int rightDoorNumber; // 오른쪽문에서 계산될 숫자변수

    [SerializeField]   // 유니티에서 스크립트상의 private 필드를 인스펙터 창에 노출시켜서 편집할수있게만드는 속성

    private DoorType leftDoorType; //왼쪽문의 상태를 관리하는 변수
    public int leftDoorNumber; // 왼쪽문에서 계산될 숫자변수

    public Color goodColor; // 좋은쪽문의 색
    public Color badColor; // 나쁜쪽 문의 색
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

        //오른쪽문 세팅
        if(rightDoorType.Equals(DoorType.Plus)) // plus로 설정했을때
        {
            rightDoorSpriteRD.color = goodColor;
            rightDoorText.text = "+" + rightDoorNumber;
        }

        else if (rightDoorType.Equals(DoorType.Minus)) // minus 로 설정했을때
        {
            rightDoorSpriteRD.color = badColor;
            rightDoorText.text = "-" + rightDoorNumber;
        }
        else if (rightDoorType.Equals(DoorType.Times)) // minus 로 설정했을때
        {
            rightDoorSpriteRD.color = goodColor;
            rightDoorText.text = "x" + rightDoorNumber;
        }
        else if (rightDoorType.Equals(DoorType.Division)) // minus 로 설정했을때
        {
            rightDoorSpriteRD.color = badColor;
            rightDoorText.text = "/" + rightDoorNumber;
        }

        //왼쪽문 세팅
        if (leftDoorType.Equals(DoorType.Plus)) // plus로 설정했을때
        {
            leftDoorSpriteRD.color = goodColor;
            leftDoorText.text = "+" + leftDoorNumber;
        }

        else if (leftDoorType.Equals(DoorType.Minus)) // minus 로 설정했을때
        {
            leftDoorSpriteRD.color = badColor;
            leftDoorText.text = "-" + leftDoorNumber;
        }
        else if (leftDoorType.Equals(DoorType.Times)) // minus 로 설정했을때
        {
            leftDoorSpriteRD.color = goodColor;
            leftDoorText.text = "x" + leftDoorNumber;
        }
        else if (leftDoorType.Equals(DoorType.Division)) // minus 로 설정했을때
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
