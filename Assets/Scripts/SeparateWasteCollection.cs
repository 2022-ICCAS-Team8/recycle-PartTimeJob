using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SeparateWasteCollection : MonoBehaviour
{
    public RectTransform uiGroup;
    GameObject nearObject;

    public Text txtType;
    public GameObject throwObject;


    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Trashbin"))
        {
            uiGroup.anchoredPosition = Vector3.zero;
            //화면 회전 고정
            nearObject = collision.gameObject;
            Interaction();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        uiGroup.anchoredPosition = Vector3.down * 1000;
        nearObject = null;
    }

    void Interaction()
    {
        TrashType trashtype = nearObject.GetComponent<TrashType>();
        txtType.text = trashtype.type.ToString();
    }
}
