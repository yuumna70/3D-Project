using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float Speed;
    public float jumpPower;
    public float gravityScale;
    float _y;
    public float rotateSpeed;

    CharacterController cc;
    Animator anim;

    public int hp = 100;
    public Slider hpBar;

    public GameObject[] camera;

    void Damaged(int damage)
    {
        hp -= damage;
        hpBar.value = hp / 100f;
    }

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!cc.isGrounded)
        {
            _y -= gravityScale * Time.deltaTime;
        }
        
        else if(Input.GetKeyDown(KeyCode.Space))
        {
            _y = jumpPower;
        }

        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        Vector3 dir = new Vector3(h, 0, v);

        anim.SetFloat("speed", dir.magnitude);

        dir = dir.normalized;
        dir = transform.TransformDirection(dir);
        dir.y = _y;
        cc.Move(dir * Speed * Time.deltaTime);

        float rotY = Input.GetAxis("Mouse X") * rotateSpeed * 10 * Time.deltaTime;
        transform.Rotate(0, rotY, 0);

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            camera[0].gameObject.SetActive(true);
            camera[1].gameObject.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            camera[1].gameObject.SetActive(true);
            camera[0].gameObject.SetActive(false);
        }

    }
}
