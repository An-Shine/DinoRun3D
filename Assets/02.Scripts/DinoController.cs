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

    // ��ü�� �߽��� �� ��ġ
    public Vector3 sphereCenter;
    // ��ü�� ������
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
        transform.position += Vector3.forward * Time.deltaTime * moveSpeedZ; // �����θ� ��

        if (Input.GetKey(KeyCode.LeftArrow)) // ���� ȭ��ǥ
        {
            transform.Translate(-moveSpeedX * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow)) // ������ ȭ��ǥ
        {
            transform.Translate(moveSpeedX * Time.deltaTime, 0, 0);
        }

        // x�� ������ ����.
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3.9f, 3.9f),
                                                                 transform.position.y,
                                                                 transform.position.z);
    }

    void DoorCheck()
    {
        // ��ü ���� ���� Collider���� ����
        Collider[] hitColliders = Physics.OverlapSphere(transform.position + sphereCenter, sphereRadius);

        // ������ Collider���� ó��
        foreach (Collider doors in hitColliders)
        {
            if(doors.CompareTag("Goal"))
            {
                Debug.Log("����!! Ŭ����!!");
                PlayerPrefs.SetInt("Stage", PlayerPrefs.GetInt("Stage") + 1);  // Goal�� ������ ���� Stage���� 1�� �� �߰� ���ش�.
                doors.gameObject.GetComponent<BoxCollider>().enabled = false; // Door�� BoxCollider�� ��Ȱ��ȭ ����
                // �ٽ� ���ο� ���� �ε� �ϸ� ��
                SceneManager.LoadScene(0);
            }
            else
            {
                // ���⿡�� �浹�� DoorŸ���� ���� ���� ���ڸ� �޾ƿͼ�
                int doorNumber = doors.gameObject.GetComponent<SelectDoors>().GetDoorNumber(transform.position.x);
                DoorType doorType = doors.gameObject.GetComponent<SelectDoors>().GetDoorType(transform.position.x);

                doors.gameObject.GetComponent<BoxCollider>().enabled = false; // Door�� BoxCollider�� ��Ȱ��ȭ ����

                // DinoPositionsController ����ŵƮ���� �����ϰ� ��Ģ���꿡 �°� ������ָ� ��.
                dinoPositionController.SetDoorCalc(doorType, doorNumber);
            }
        }
    }

    // ��ü ������ Gizmo�� �ð�ȭ
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + sphereCenter, sphereRadius);
    }
}
