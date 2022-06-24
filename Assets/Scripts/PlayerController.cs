using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    public float speed;
    public Vector2 rotationSensitivity;
    public float rotationVelocity;

    float xInput, zInput;
    float xMouse;

    public float mouseRotation;
    float wasdRotation;
    float internalRotation;

    Animator anim;


    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        mouseRotation = transform.eulerAngles.y;
        wasdRotation = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        xMouse = Input.GetAxis("Mouse X");
        xInput = -Input.GetAxisRaw("Horizontal");
        zInput = +Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(xInput, 0, zInput).normalized;

        if (direction != Vector3.zero)
        {
            wasdRotation = Vector3.Angle(Vector3.forward, direction);
            if (direction.x > 0)
                wasdRotation *= -1.0f;
        }
        mouseRotation += xMouse * rotationSensitivity.x;
        internalRotation = mouseRotation + wasdRotation;
        internalRotation -= 360.0f * Mathf.Floor((internalRotation + 180.0f) / 360.0f);

        float displayDiff = internalRotation - transform.eulerAngles.y;
        if (displayDiff > 180.0f)
            displayDiff -= 360.0f;
        else if (displayDiff < -180.0f)
            displayDiff += 360.0f;

        float displayRotation = transform.eulerAngles.y;

        float dth = rotationVelocity * Time.deltaTime;
        if (displayDiff > dth)
            displayRotation += dth;
        else if (displayDiff < -dth)
            displayRotation -= dth;
        else
            displayRotation = internalRotation;

        transform.eulerAngles = new Vector3(0, displayRotation, 0);

        // Debug.Log("DR: " + displayRotation + " / IR: " + internalRotation);

        float internalRotationInRad = Mathf.Deg2Rad * internalRotation;
        transform.localPosition +=
            new Vector3(Mathf.Sin(internalRotationInRad), 0, Mathf.Cos(internalRotationInRad))
            * direction.magnitude * Time.deltaTime * speed;

        anim.SetBool("isWalking", direction != Vector3.zero);
    }
}