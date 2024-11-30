using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject[] mapPrefabs;
    public GameObject goalObject;
    public static MapManager instance;
    public void Awake()
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
        CreateMap();
        goalObject = GameObject.FindWithTag("Goal");  //Goal ������Ʈ�� ã�Ƽ� ����
    }
    private void CreateMap()
    {
        //�ʱ�ȭ
        Vector3 mapPosition = Vector3.zero; // ���� 000���� �ʱ�ȭ
        for(int i = 0; i< 5; i++)
        {
            GameObject selectedMap = mapPrefabs[Random.Range(0, mapPrefabs.Length)]; //������3���� ��������
            if(i>0) // �ι�° �ʺ��� ���õ� �� ũ���� ���� �����ش�.
            {
                mapPosition.z += selectedMap.GetComponent<Map>().GetMapSize() / 2; 
            }
            else
            {
             selectedMap = mapPrefabs[0];   // ù��°�� ������ 0��°�迭�� �ε����� map �� �����ȴ�.
            }
                GameObject nowMap = Instantiate(selectedMap, mapPosition, Quaternion.identity);
                mapPosition.z += nowMap.GetComponent<Map>().GetMapSize() / 2; // ���� ���õ� ���� ������ ���� ���ϱ�
        }
    }

    
    void Update()
    {
        
    }
    public float GetGoalDistance()
    {
        return goalObject.transform.position.z;
    }
   
}
