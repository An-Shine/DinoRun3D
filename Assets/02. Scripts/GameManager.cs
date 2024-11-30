using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isGameStart;
    
    public GameObject TitlePanel;
    public Slider progressBar;

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
        
    }

    public void GameStart()
    {
        Time.timeScale = 1f;
        isGameStart = true;
        if (isGameStart.Equals(true))
        {
            TitlePanel.SetActive(false);
        }
    }
    public void SetDistanceProgressBar() //프로그래스 바 세팅함수
    {

    }
}
