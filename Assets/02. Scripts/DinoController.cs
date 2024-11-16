using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoController : MonoBehaviour
{
    public float speedZ;
    public float speedX;
    // ��ü�� �߽��� �� ��ġ
    public Vector3 sphereCenter;
    // ��ü�� ������
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
        //��ü ���� ���� Collider���� ����
        Collider[] hitColliders = Physics.OverlapSphere(transform.position + sphereCenter, sphereRadius);

        //������ collider���� ó��
        foreach (Collider doors in hitColliders)
        {
            // Debug.Log("������ ������Ʈ �̸� : " + doors.gameObject.name);
            //���⿡�� �浹�� door Ÿ���� ���� ���� ���ڸ� �޾ƿͼ�
            int doorNumber = doors.gameObject.GetComponent<SelectDoors>().GetDoorNumber(transform.position.x);
            DoorType doorType = doors.gameObject.GetComponent<SelectDoors>().GetDoorType(transform.position.x);
            dinoPositionController.SetDoorCalc(doorType, doorNumber); //DinoPositionsController ��ũ��Ʈ���� �����ϰ� ��Ģ���꿡 ���� �������.
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + sphereCenter, sphereRadius);
    }
}
