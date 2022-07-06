using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraSystem : MonoBehaviour
{
    public GameObject target;
    public Vector3 centerOffset;
    public float distance;

    float trueRotation;

    Camera cam;

    private void Awake()
    {
        cam = GetComponentInChildren<Camera>();

        transform.position = target.transform.position + centerOffset;
        cam.transform.position = transform.position + new Vector3(0, 0, -distance);
    }

    // Update is called once per frame
    void Update()
    {
        float rotationX = target.GetComponent<PlayerController>().mouseRotationX;
        float rotationY = target.GetComponent<PlayerController>().mouseRotationY;

        transform.position = target.transform.position + centerOffset;
        transform.eulerAngles = new Vector3(-rotationY, rotationX, 0);
    }
}