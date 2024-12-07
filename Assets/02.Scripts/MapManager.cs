using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager instance;
    public StageScriptableObject[] stages; // 스크립터블 오브젝트로 만든 Data를 담기 위한 변수
    public GameObject goalObject;

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
        //CreatMap();
        CreateStage();

        goalObject = GameObject.FindWithTag("Goal");  // Goal 오브젝트를 찾아서 대입합니다.
    }

    /*
    private void CreatMap()
    {
        // 초기화
        Vector3 mapPosition = Vector3.zero;

        for (int i = 0; i < 6; i++)
        {
            GameObject selectedMap;

            if (i > 0)  // 2번째 Map부터 이전의 Map크기의 반을 더해준다.
            {
                selectedMap = mapPrefabs[Random.Range(1, mapPrefabs.Length)];
                mapPosition.z += selectedMap.GetComponent<Map>().GetMapSize() / 2;
            }
            else
            {
                selectedMap = mapPrefabs[0];  // 첫 번째는 무조건 0번째 배열의 인덱스의 Map이 생성된다. 여기는 Door가 없는 Map 배치
            }

            GameObject nowMap = Instantiate(selectedMap, mapPosition, Quaternion.identity);

            mapPosition.z += nowMap.GetComponent<Map>().GetMapSize() / 2;  // 현재 선택된 Map의 길이의 반을 더한다.
        }
    }
    */

    private void CreateStage()
    {
        int currentStageIndex = GetStage();
        currentStageIndex = currentStageIndex % stages.Length;  // 이렇게 하면 Stages 배열의 범위를 벗어나지 않음
        StageScriptableObject stage = stages[currentStageIndex];

        CreateMap(stage.maps);
    }

    private void CreateMap(Map[] stageMaps)
    {
        // 초기화
        Vector3 mapPosition = Vector3.zero;
        for (int i = 0; i < stageMaps.Length; i++)
        {
            Map selectedMap = stageMaps[i];  // 만들 Map을 순서대로 선택한다

            if (i > 0)  // 2번째 Map부터 이전의 Map크기의 반을 더해준다.
            {
                mapPosition.z += selectedMap.GetComponent<Map>().GetMapSize() / 2;
            }
            Map nowMap = Instantiate(selectedMap, mapPosition, Quaternion.identity);
            mapPosition.z += nowMap.GetComponent<Map>().GetMapSize() / 2;  // 현재 선택된 Map의 길이의 반을 더한다.
        }
    }

    public float GetGoalDistance()
    {
        return goalObject.transform.position.z;
    }

    public int GetStage()
    {
        return PlayerPrefs.GetInt("Stage", 1); // 저장된 스테이지 값을 불러온다. 처음 시작시 값은 1 
    }
}
