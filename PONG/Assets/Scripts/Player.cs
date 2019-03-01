using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public KeyCode up;
    public KeyCode down;
    public float speed;
    float FinalSpeed;
    public float LimitsPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(up)) {
            transform.Translate(0, FinalSpeed, 0);
            
            if (transform.localPosition.y > LimitsPlayer)
            {
                FinalSpeed = 0;
            }
            else {
                FinalSpeed = speed;
            }
        }
        if (Input.GetKey(down))
        {
            if (transform.localPosition.y < -LimitsPlayer)
            {
                FinalSpeed = 0;
            }
            else
            {
                FinalSpeed = speed;
            }
            transform.Translate(0, -FinalSpeed, 0);
        }

    }
}
