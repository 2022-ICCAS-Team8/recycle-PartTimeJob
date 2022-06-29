using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public Vector3 eyeOffset;

    public float detectDistance;

    Ray ray;
    RaycastHit hit;
    GameObject obj;
    void Update()
    {
        if (Input.GetMouseButton(1)) // right click
        {
            Debug.Log(Screen.width + " " + Screen.height);
            ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2));

            if (Physics.Raycast(ray, out hit, detectDistance))
            {
                Debug.Log("ray hit: " + hit.transform.name);

                obj = hit.transform.gameObject;

                if (obj.tag == "DoorClosed")
                    StartCoroutine(OpenDoor(obj));
                else if (obj.tag == "DoorOpened")
                    StartCoroutine(CloseDoor(obj));
                else if (obj.tag == "ClosetDoorClosed")
                    StartCoroutine(OpenClosetDoor(obj));
                else if (obj.tag == "ClosetDoorOpened")
                    StartCoroutine(CloseClosetDoor(obj));
            }
        }
    }


    IEnumerator OpenDoor(GameObject obj)
    {
        obj.tag = "DoorOpened";
        obj.GetComponent<Animator>().Play("Opening");
        yield return new WaitForSeconds(.5f);
    }

    IEnumerator CloseDoor(GameObject obj)
    {
        obj.tag = "DoorClosed";
        obj.GetComponent<Animator>().Play("Closing");
        yield return new WaitForSeconds(.5f);
    }
    IEnumerator OpenClosetDoor(GameObject obj)
    {
        obj.tag = "ClosetDoorOpened";
        obj.GetComponent<Animator>().Play("ClosetOpening");
        yield return new WaitForSeconds(.5f);
    }
    IEnumerator CloseClosetDoor(GameObject obj)
    {
        obj.tag = "ClosetDoorClosed";
        obj.GetComponent<Animator>().Play("ClosetClosing");
        yield return new WaitForSeconds(.5f);
    }


}
