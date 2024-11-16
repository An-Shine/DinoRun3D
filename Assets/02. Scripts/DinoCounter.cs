using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DinoCounter : MonoBehaviour
{
    public TextMeshPro dinoCounter;
    public Transform dinoParent;
 

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        dinoCounter.text = dinoParent.childCount.ToString();
        
    }

    
}
