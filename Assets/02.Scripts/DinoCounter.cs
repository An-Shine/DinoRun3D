using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DinoCounter : MonoBehaviour
{
    public TextMeshPro dinoCounterText;

    public Transform dinoParent;

    void Update()
    {
        dinoCounterText.text  = dinoParent.childCount.ToString();
    }
}
