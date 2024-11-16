using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject[] mapPrefabs;



    void Start()
    {
        //�ʱ�ȭ
        Vector3 mapPosition = Vector3.zero; // ���� 000���� �ʱ�ȭ
        for(int i = 0; i < 5; i++)
        {
            GameObject selectedMap = mapPrefabs[Random.Range(0, mapPrefabs.Length)]; //������3���� ��������
            if(i>0) // �ι�° �ʺ��� ���õ� �� ũ���� ���� �����ش�.
            {
                mapPosition.z += selectedMap.GetComponent<Map>().GetMapSize() / 2; 
            }
            GameObject nowMap = Instantiate(selectedMap, mapPosition, Quaternion.identity);
            mapPosition.z += nowMap.GetComponent<Map>().GetMapSize() / 2; // ���� ���õ� ���� ������ ���� ���ϱ�
        }
    }

    
    void Update()
    {
        
    }
}
