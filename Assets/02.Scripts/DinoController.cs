using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DinoController : MonoBehaviour
{
    public static DinoController instance;

    public DinoPositionController dinoPositionController;

    public float moveSpeedZ;
    public float moveSpeedX;

    // 구체의 중심이 될 위치
    public Vector3 sphereCenter;
    // 구체의 반지름
    public float sphereRadius = 0.5f;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {

    }

    void Update()
    {
        if(GameManager.instance.isGameStart.Equals(true))
        {
            DinoMove();
            DoorCheck();
        }
    }

    private void DinoMove()
    {
        //transform.Translate(0, 0, moveSpeedZ);
        //transform.position += new Vector3(0,0, moveSpeedZ);
        transform.position += Vector3.forward * Time.deltaTime * moveSpeedZ; // 앞으로만 가

        if (Input.GetKey(KeyCode.LeftArrow)) // 왼쪽 화살표
        {
            transform.Translate(-moveSpeedX * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow)) // 오른쪽 화살표
        {
            transform.Translate(moveSpeedX * Time.deltaTime, 0, 0);
        }

        // x축 움직임 강제.
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3.9f, 3.9f),
                                                                 transform.position.y,
                                                                 transform.position.z);
    }

    void DoorCheck()
    {
        // 구체 영역 내의 Collider들을 감지
        Collider[] hitColliders = Physics.OverlapSphere(transform.position + sphereCenter, sphereRadius);

        // 감지된 Collider들을 처리
        foreach (Collider doors in hitColliders)
        {
            if(doors.CompareTag("Goal"))
            {
                Debug.Log("골인!! 클리어!!");
                PlayerPrefs.SetInt("Stage", PlayerPrefs.GetInt("Stage") + 1);  // Goal에 닿으면 현재 Stage에서 1을 더 추가 해준다.
                doors.gameObject.GetComponent<BoxCollider>().enabled = false; // Door의 BoxCollider를 비활성화 해줌
                // 다시 새로운 씬을 로드 하면 됨
                SceneManager.LoadScene(0);
            }
            else
            {
                // 여기에서 충돌한 Door타입의 문과 써진 숫자를 받아와서
                int doorNumber = doors.gameObject.GetComponent<SelectDoors>().GetDoorNumber(transform.position.x);
                DoorType doorType = doors.gameObject.GetComponent<SelectDoors>().GetDoorType(transform.position.x);

                doors.gameObject.GetComponent<BoxCollider>().enabled = false; // Door의 BoxCollider를 비활성화 해줌

                // DinoPositionsController 스르킵트에서 적절하게 사칙연산에 맞게 계산해주면 됨.
                dinoPositionController.SetDoorCalc(doorType, doorNumber);
            }
        }
    }

    // 구체 영역을 Gizmo로 시각화
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + sphereCenter, sphereRadius);
    }
}
