using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset;

    float trueRotation;

    private void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float trueRotation = target.GetComponent<PlayerController>().mouseRotation;

        float angle = Mathf.Deg2Rad * trueRotation;
        Vector3 relZUnit = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));

        transform.position = target.transform.position + offset.y * Vector3.up + relZUnit * offset.z;
        transform.eulerAngles = new Vector3(0, trueRotation, 0);
    }
}
