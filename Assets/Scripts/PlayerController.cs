using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    public float speed;
    public Vector2 rotationSensitivity;

    float xInput, zInput;
    float xMouse;

    float rotationOffset;

    Animator anim;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        xMouse = Input.GetAxis("Mouse X");
        float rotateY = xMouse * rotationSensitivity.x;

        xInput = -Input.GetAxisRaw("Horizontal");
        zInput = Input.GetAxisRaw("Vertical");


        Vector3 direction = new Vector3(xInput, 0, zInput).normalized;
        transform.Rotate(Vector3.up, rotateY);

        rotationOffset = Vector3.Angle(Vector3.forward, direction);
        if (direction.x > 0)
            rotationOffset *= -1.0f;

        Debug.Log(rotationOffset);

        float totRotationInRadian = Mathf.Deg2Rad * (transform.eulerAngles.y + rotationOffset);
        transform.localPosition +=
            new Vector3(Mathf.Sin(totRotationInRadian), 0, Mathf.Cos(totRotationInRadian))
            * direction.magnitude * Time.deltaTime * speed;

        anim.SetBool("isWalking", direction != Vector3.zero);


    }
}
