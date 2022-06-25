using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject object1;

    Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        anim = object1.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            anim.SetTrigger("doOpenDoor");
        }
    }
}
