using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager instance;
    public StageScriptableObject[] stages; // ��ũ���ͺ� ������Ʈ�� ���� Data�� ��� ���� ����
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

        goalObject = GameObject.FindWithTag("Goal");  // Goal ������Ʈ�� ã�Ƽ� �����մϴ�.
    }

    /*
    private void CreatMap()
    {
        // �ʱ�ȭ
        Vector3 mapPosition = Vector3.zero;

        for (int i = 0; i < 6; i++)
        {
            GameObject selectedMap;

            if (i > 0)  // 2��° Map���� ������ Mapũ���� ���� �����ش�.
            {
                selectedMap = mapPrefabs[Random.Range(1, mapPrefabs.Length)];
                mapPosition.z += selectedMap.GetComponent<Map>().GetMapSize() / 2;
            }
            else
            {
                selectedMap = mapPrefabs[0];  // ù ��°�� ������ 0��° �迭�� �ε����� Map�� �����ȴ�. ����� Door�� ���� Map ��ġ
            }

            GameObject nowMap = Instantiate(selectedMap, mapPosition, Quaternion.identity);

            mapPosition.z += nowMap.GetComponent<Map>().GetMapSize() / 2;  // ���� ���õ� Map�� ������ ���� ���Ѵ�.
        }
    }
    */

    private void CreateStage()
    {
        int currentStageIndex = GetStage();
        currentStageIndex = currentStageIndex % stages.Length;  // �̷��� �ϸ� Stages �迭�� ������ ����� ����
        StageScriptableObject stage = stages[currentStageIndex];

        CreateMap(stage.maps);
    }

    private void CreateMap(Map[] stageMaps)
    {
        // �ʱ�ȭ
        Vector3 mapPosition = Vector3.zero;
        for (int i = 0; i < stageMaps.Length; i++)
        {
            Map selectedMap = stageMaps[i];  // ���� Map�� ������� �����Ѵ�

            if (i > 0)  // 2��° Map���� ������ Mapũ���� ���� �����ش�.
            {
                mapPosition.z += selectedMap.GetComponent<Map>().GetMapSize() / 2;
            }
            Map nowMap = Instantiate(selectedMap, mapPosition, Quaternion.identity);
            mapPosition.z += nowMap.GetComponent<Map>().GetMapSize() / 2;  // ���� ���õ� Map�� ������ ���� ���Ѵ�.
        }
    }

    public float GetGoalDistance()
    {
        return goalObject.transform.position.z;
    }

    public int GetStage()
    {
        return PlayerPrefs.GetInt("Stage", 1); // ����� �������� ���� �ҷ��´�. ó�� ���۽� ���� 1 
    }
}
