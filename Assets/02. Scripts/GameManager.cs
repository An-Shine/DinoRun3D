using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isGameStart;

    public GameObject TitlePanel;
    public GameObject gamePanel;
    public Slider progressBar;
    public GameObject goalObject;
    public GameObject Dino;
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
        Time.timeScale = 0f;
        

    }


    void Update()
    {
        SetDistanceProgressBar();
    }

    public void GameStart()
    {
        Time.timeScale = 1f;
        isGameStart = true;
        TitlePanel.SetActive(false);
        gamePanel.SetActive(true);
    }
    public void SetDistanceProgressBar() //���α׷��� �� �����Լ�
    {
        if(isGameStart.Equals(true))
        {
            //��ü�Ÿ��� Dino �� ��ġ �Ÿ� ����
            float goalDistance = DinoController.instance.transform.position.z/MapManager.instance.GetGoalDistance();
            progressBar.value = goalDistance;
        }
    }
}
