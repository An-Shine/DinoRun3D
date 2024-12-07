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

    public void SetDistanceProgressBar()  // ���α׷��� �ٸ� �����ϱ� ���� �Լ�
    {
        if(isGameStart.Equals(true))
        {
            // ��ü �Ÿ� �� Dino�� ��ġ �Ÿ� ����
            float goalDistance = DinoController.instance.transform.position.z / MapManager.instance.GetGoalDistance();
            progressBar.value = goalDistance;
        }
    }

    public void GameStart()
    {
        Debug.Log("���� ����");
        isGameStart = true;
        Time.timeScale = 1f;
        titlePanel.SetActive(false);  // Ÿ��Ʋ �г� ���ְ�
        gamePanel.SetActive(true);  // ���� �г� ���ְ�
        nowStageText.text = MapManager.instance.GetStage().ToString();
        nextStageText.text = (MapManager.instance.GetStage() + 1).ToString();
    }
}
