using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletHolePrefs;

    AudioSource audio;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        audio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetButtonDown("Fire1"))
        {
            audio.Play();
            anim.SetTrigger("shoot");
            Ray ray = Camera.main.ViewportPointToRay(new Vector2(0.5f, 0.5f));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "Enemy")
                {
                    hit.collider.SendMessage("Damaged", 10);
                }

                else
                {
                    GameObject bulletHole = Instantiate(bulletHolePrefs, hit.point, Quaternion.LookRotation(hit.normal));
                    bulletHole.transform.position += bulletHole.transform.forward * 0.01f;
                    bulletHole.transform.parent = hit.collider.transform;
                    Destroy(bulletHole, 2);
                }
            }
        }

    }
}


