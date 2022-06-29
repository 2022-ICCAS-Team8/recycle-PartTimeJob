using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackpackManager : MonoBehaviour
{
    public List<RecyclableItem> Items { get; set; }

    // number of backpack slots per row
    const int BACKPACK_SLOT = 8;

    // width of border of backpack UI (in pixels)
    const int BACKPACK_GAP = 20;

    GameObject bpWindow;
    GameObject bpInnerWindow;
    GameObject bpSampleSlot;

    private void Awake()
    {
        Items = new List<RecyclableItem>();

        bpWindow = GameObject.Find("BackpackWindow");
        bpInnerWindow = GameObject.Find("bp_InnerWindow");
        bpSampleSlot = GameObject.Find("bp_SampleSlot");

        //test
        for (int i = 0; i < 12; i++)
            Items.Add(new RecyclableItem());

    }

    void Start()
    {
        bpWindow.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab))
            SetBackpackOpen(!bpWindow.activeInHierarchy);
    }


    public void OnClickBackpackButton()
    {
        SetBackpackOpen(!bpWindow.activeInHierarchy);
    }

    public void OpenBackpack()
    {
        float innerWidth = bpInnerWindow.GetComponent<RectTransform>().rect.width;
        // create contents
        for (int i=0; i < Items.Count; i++)
        {
            float w = (innerWidth - (BACKPACK_SLOT + 1) * BACKPACK_GAP) / BACKPACK_SLOT;
            float x =  (i % BACKPACK_SLOT) * (BACKPACK_GAP + w) + BACKPACK_GAP;
            float y = -(i / BACKPACK_SLOT) * (BACKPACK_GAP + w) - BACKPACK_GAP;

            GameObject slot = Instantiate(bpSampleSlot, bpInnerWindow.transform, false);
            // set name
            slot.name = "bp_Slot" + i;
            // set local position
            slot.transform.localPosition = new Vector3(x, y);
            // set width and height
            slot.GetComponent<RectTransform>().sizeDelta = new Vector2(w, w);
        }

        bpWindow.SetActive(true);
    }


    public void CloseBackpack()
    {
        bpWindow.SetActive(false);

        // destroy all children.
        // 'i' must be started from 1, since index 0 means itself, not a child.
        for (int i=1; i < bpInnerWindow.transform.childCount; i++)
        {
            Destroy(bpInnerWindow.transform.GetChild(i).gameObject);
        }
    }

    public void SetBackpackOpen(bool isOpen)
    {
        if (isOpen)
            OpenBackpack();
        else
            CloseBackpack();
    }

    public void Collect(GameObject gameObject)
    {

    }
}