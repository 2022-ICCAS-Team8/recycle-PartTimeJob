using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    public float speed;
    public Vector2 mouseSensitivity;
    public float rotationVelocity;
    public float mouseRotationX { get; private set; }
    public float mouseRotationY { get; private set; }
    public float rotationYMin;
    public float rotationYMax;
    public bool isKeyboardFrozen;
    public bool isMouseFrozen;

    float xKeyInput, zKeyInput;
    float xMouseInput, yMouseInput;

    float wasdRotation;
    float internalRotation;
    float displayRotation;
    Vector3 keyDirection;

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
        xMouseInput = Input.GetAxis("Mouse X");
        yMouseInput = Input.GetAxis("Mouse Y");
        xKeyInput = -Input.GetAxisRaw("Horizontal");
        zKeyInput = +Input.GetAxisRaw("Vertical");
    }

    private void Calculate()
    {
        if (!isKeyboardFrozen)
            keyDirection = new Vector3(xKeyInput, 0, zKeyInput).normalized;
        else
            keyDirection = Vector3.zero;

        if (!isMouseFrozen)
        {
            mouseRotationX += xMouseInput * mouseSensitivity.x;
            mouseRotationY += yMouseInput * mouseSensitivity.y;
            mouseRotationY = Mathf.Clamp(mouseRotationY, -rotationYMax, -rotationYMin);
        }

        if (keyDirection != Vector3.zero)
        {
            wasdRotation = Vector3.Angle(Vector3.forward, keyDirection);
            if (keyDirection.x > 0)
                wasdRotation *= -1.0f;
        }
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
            * keyDirection.magnitude * Time.deltaTime * speed;
    }

    private void Animate()
    {
        anim.SetBool("isWalking", keyDirection != Vector3.zero);
    }
}
