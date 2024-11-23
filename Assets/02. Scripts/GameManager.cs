using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

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
        
    }


    void Update()
    {
        
    }

    public void GameStart()
    {
        Debug.Log("게임 시작!!");
    }
}
