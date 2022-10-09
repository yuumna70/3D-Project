using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera3 : MonoBehaviour
{
    public float rotateSpeed;

    bool isDown, isUp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotX = Input.GetAxis("Mouse Y") * rotateSpeed * 10 * Time.deltaTime;

        if(transform.eulerAngles.x >=30 && transform.eulerAngles.x <= 180)
        {
            isDown = true;
        }else if(transform.eulerAngles.x <= 340 && transform.eulerAngles.x > 180)
        {
            isUp = true;
        }
        
        if(rotX >0)
        {
            isDown = false;
        }
        else if(rotX <0)
        {
            isUp = false;
        }

        if(!isDown && !isUp)
        {
            transform.RotateAround(transform.parent.position, transform.right, -rotX);
        }


    }
}
