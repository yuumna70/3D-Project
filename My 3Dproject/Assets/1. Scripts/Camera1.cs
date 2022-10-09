using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera1 : MonoBehaviour
{
    public float rotateSpeed;

    float _x;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotX = Input.GetAxis("Mouse Y") * rotateSpeed * 10 * Time.deltaTime;

        _x += -rotX;
        _x = Mathf.Clamp(_x, -25, 25);
        transform.eulerAngles = new Vector3(_x, transform.eulerAngles.y, 0);

    }
}
