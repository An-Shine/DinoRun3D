using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoController : MonoBehaviour
{
    public float speedZ;
    public float speedX;
    // 구체의 중심이 될 위치
    public Vector3 sphereCenter;
    // 구체의 반지름
    public float sphereRadius = 0.5f;
    public DinoPostiionController dinoPositionController;

    void Start()
    {
        
    }

    
    void Update()
    {
        DinoMove();
        DoorCheck();
    }

    void DinoMove()
    {
        transform.position += new Vector3(0, 0, speedZ * Time.deltaTime);
        //transform.Translate = new Vector3(0, 0, speed * Time.deltaTime);
        // transform.position += new Vector3(0, 0, speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speedX * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speedX * Time.deltaTime, 0, 0);
        }
        float x = Mathf.Clamp(transform.position.x, -3.9f, 3.9f);

        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }

    void DoorCheck()
    {
        //구체 영역 내의 Collider들을 감지
        Collider[] hitColliders = Physics.OverlapSphere(transform.position + sphereCenter, sphereRadius);

        //감지된 collider들을 처리
        foreach (Collider doors in hitColliders)
        {
            // Debug.Log("감지된 오브젝트 이름 : " + doors.gameObject.name);
            //여기에서 충돌한 door 타입의 문과 써진 숫자를 받아와서
            int doorNumber = doors.gameObject.GetComponent<SelectDoors>().GetDoorNumber(transform.position.x);
            DoorType doorType = doors.gameObject.GetComponent<SelectDoors>().GetDoorType(transform.position.x);
            dinoPositionController.SetDoorCalc(doorType, doorNumber); //DinoPositionsController 스크립트에서 적절하게 사칙연산에 맞춰 계산해줌.
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + sphereCenter, sphereRadius);
    }
}
