using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    public float speed;
    public Vector2 mouseSensitivity;
    public float rotationVelocity;

    float xInput, zInput;
    float xMouse, yMouse;

    public float mouseRotationX { get; private set; }
    public float mouseRotationY { get; private set; }
    float wasdRotation;
    float internalRotation;
    float displayRotation;
    Vector3 direction;

    Animator anim;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        mouseRotationX = transform.eulerAngles.y;
        mouseRotationY = 0.0f;
        wasdRotation = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Calculate();
        Rotate();
        Walk();
        Animate();
    }

    private void GetInput()
    {
        xMouse = Input.GetAxis("Mouse X");
        yMouse = Input.GetAxis("Mouse Y");
        xInput = -Input.GetAxisRaw("Horizontal");
        zInput = +Input.GetAxisRaw("Vertical");
    }

    private void Calculate()
    {
        direction = new Vector3(xInput, 0, zInput).normalized;

        if (direction != Vector3.zero)
        {
            wasdRotation = Vector3.Angle(Vector3.forward, direction);
            if (direction.x > 0)
                wasdRotation *= -1.0f;
        }
        mouseRotationX += xMouse * mouseSensitivity.x;
        internalRotation = mouseRotationX + wasdRotation;
        internalRotation -= 360.0f * Mathf.Floor((internalRotation + 180.0f) / 360.0f);

        float displayDiff = internalRotation - transform.eulerAngles.y;
        if (displayDiff > 180.0f)
            displayDiff -= 360.0f;
        else if (displayDiff < -180.0f)
            displayDiff += 360.0f;

        displayRotation = transform.eulerAngles.y;

        float dth = rotationVelocity * Time.deltaTime;
        if (displayDiff > dth)
            displayRotation += dth;
        else if (displayDiff < -dth)
            displayRotation -= dth;
        else
            displayRotation = internalRotation;
    }

    private void Rotate()
    {
        transform.eulerAngles = new Vector3(0, displayRotation, 0);
    }

    private void Walk()
    {
        float internalRotationInRad = Mathf.Deg2Rad * internalRotation;
        transform.localPosition +=
            new Vector3(Mathf.Sin(internalRotationInRad), 0, Mathf.Cos(internalRotationInRad))
            * direction.magnitude * Time.deltaTime * speed;
    }

    private void Animate()
    {
        anim.SetBool("isWalking", direction != Vector3.zero);
    }
    
}
