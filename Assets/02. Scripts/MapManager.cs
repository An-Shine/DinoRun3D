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
        goalObject = GameObject.FindWithTag("Goal");  //Goal 오브젝트를 찾아서 대입
    }
    private void CreateMap()
    {
        //초기화
        Vector3 mapPosition = Vector3.zero; // 기준 000으로 초기화
        for(int i = 0; i< 5; i++)
        {
            GameObject selectedMap = mapPrefabs[Random.Range(0, mapPrefabs.Length)]; //프리팹3개중 랜덤선택
            if(i>0) // 두번째 맵부터 선택된 맵 크기의 반을 더해준다.
            {
                mapPosition.z += selectedMap.GetComponent<Map>().GetMapSize() / 2; 
            }
            else
            {
             selectedMap = mapPrefabs[0];   // 첫번째는 무조건 0번째배열의 인덱스의 map 이 생성된다.
            }
                GameObject nowMap = Instantiate(selectedMap, mapPosition, Quaternion.identity);
                mapPosition.z += nowMap.GetComponent<Map>().GetMapSize() / 2; // 현재 선택된 맵의 길이의 절반 더하기
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
