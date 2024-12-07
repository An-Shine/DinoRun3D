using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isGameStart;

    public GameObject titlePanel;
    public GameObject gamePanel;
    public Slider progressBar;

    public TextMeshProUGUI nowStageText;
    public TextMeshProUGUI nextStageText;

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
        Time.timeScale = 0f;
    }

    void Update()
    {
        SetDistanceProgressBar();
    }

    public void SetDistanceProgressBar()  // 프로그래스 바를 세팅하기 위한 함수
    {
        if(isGameStart.Equals(true))
        {
            // 전체 거리 중 Dino의 위치 거리 비율
            float goalDistance = DinoController.instance.transform.position.z / MapManager.instance.GetGoalDistance();
            progressBar.value = goalDistance;
        }
    }

    public void GameStart()
    {
        Debug.Log("게임 시작");
        isGameStart = true;
        Time.timeScale = 1f;
        titlePanel.SetActive(false);  // 타이틀 패널 꺼주고
        gamePanel.SetActive(true);  // 게임 패널 켜주고
        nowStageText.text = MapManager.instance.GetStage().ToString();
        nextStageText.text = (MapManager.instance.GetStage() + 1).ToString();
    }
}
