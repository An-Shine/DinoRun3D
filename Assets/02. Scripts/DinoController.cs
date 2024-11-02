using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoController : MonoBehaviour
{
    public float speedZ;
    public float speedX;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position += new Vector3(0, 0, speedZ * Time.deltaTime);
        //transform.Translate = new Vector3(0, 0, speed * Time.deltaTime);
       // transform.position += new Vector3(0, 0, speed * Time.deltaTime);

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speedX * Time.deltaTime, 0, 0);
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speedX * Time.deltaTime, 0, 0);
        }
    }
}
