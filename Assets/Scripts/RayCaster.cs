using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCaster : MonoBehaviour
{
    public GameObject player;

    public float detectDistance;

    public GameObject popup;
    public Text popupLabel;

    void Start()
    {
        popup.SetActive(false);
    }

    Ray ray;
    RaycastHit hit;
    GameObject obj;
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));

        if (Physics.Raycast(ray, out hit, detectDistance))
        {
            obj = hit.transform.gameObject;

            if (obj.CompareTag("DoorClosed") || obj.CompareTag("ClosetDoorClosed"))
            {
                popupLabel.text = "Right click to open";
                popup.SetActive(true);
            }
            else if (obj.CompareTag("DoorOpened") || obj.CompareTag("ClosetDoorOpened"))
            {
                popupLabel.text = "Right click to close";
                popup.SetActive(true);
            }
            else
            {
                popup.SetActive(false);
            }

            if (Input.GetMouseButtonUp(1)) // right click
            {
                if (obj.CompareTag("DoorClosed"))
                    StartCoroutine(OpenDoor(obj));

                else if (obj.CompareTag("DoorOpened"))
                    StartCoroutine(CloseDoor(obj));

                else if (obj.CompareTag("ClosetDoorClosed"))
                    StartCoroutine(OpenClosetDoor(obj));

                else if (obj.CompareTag("ClosetDoorOpened"))
                    StartCoroutine(CloseClosetDoor(obj));
            }
        }
    }


    IEnumerator OpenDoor(GameObject obj)
    {
        obj.tag = "DoorOpened";
        obj.GetComponent<Animator>().Play("Opening");
        //player.GetComponent<Animator>().SetTrigger("doOpenDoor");
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
        //player.GetComponent<Animator>().SetTrigger("doOpenDoor");
        yield return new WaitForSeconds(.5f);
    }
    IEnumerator CloseClosetDoor(GameObject obj)
    {
        obj.tag = "ClosetDoorClosed";
        obj.GetComponent<Animator>().Play("ClosetClosing");
        yield return new WaitForSeconds(.5f);
    }


}
