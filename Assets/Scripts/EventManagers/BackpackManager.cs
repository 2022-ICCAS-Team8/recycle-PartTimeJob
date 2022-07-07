using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BackpackManager : MonoBehaviour
{
    public List<RecyclableItem> Items { get; set; }

    // number of backpack slots per row
    const int BACKPACK_SLOT = 8;

    // width of border of backpack UI (in pixels)
    const int BACKPACK_GAP = 20;

    public GameObject bpWindow;
    public GameObject bpInnerWindow;
    public GameObject bpSampleSlot;

    public GameObject bpSampleIconPlastic, bpSampleIconGlass, bpSampleIconMetal, bpSampleIconPaper, bpSampleIconGarbage;
    public GameObject throwObject;

    private void Awake()
    {
        Items = new List<RecyclableItem>();
    }

    void Start()
    {
      bpWindow.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            ToggleBackpack();
        }
    }

    public void OpenBackpack()
    {
        float innerWidth = bpInnerWindow.GetComponent<RectTransform>().rect.width;
        GameObject icon = null;

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
            // add click listener
            slot.GetComponent<Button>().onClick.AddListener(() => {
                var idx = i;
                itemClick(1); // to fix
            });

            if (Items[i].Type == TrashType.Type.Plastic)
                icon = Instantiate(bpSampleIconPlastic, slot.transform, false);
            else if (Items[i].Type == TrashType.Type.Glass)
                icon = Instantiate(bpSampleIconGlass, slot.transform, false);
            else if (Items[i].Type == TrashType.Type.Metal)
                icon = Instantiate(bpSampleIconMetal, slot.transform, false);
            else if (Items[i].Type == TrashType.Type.Paper)
                icon = Instantiate(bpSampleIconPaper, slot.transform, false);
            else if (Items[i].Type == TrashType.Type.Garbage)
                icon = Instantiate(bpSampleIconGarbage, slot.transform, false);

            icon.transform.localPosition = new Vector3(0, 0);
            icon.GetComponent<RectTransform>().sizeDelta = new Vector2(w, w);

        }

        bpWindow.SetActive(true);
    }


    public void CloseBackpack()
    {
        bpWindow.SetActive(false);
        for (int i=1+6; i < bpInnerWindow.transform.childCount; i++)
        {
            Destroy(bpInnerWindow.transform.GetChild(i).gameObject);
        }


        // destroy all children.
        // 'i' must be started from 5, since index 0 means itself and idx 1~5 means Samples.
        
    }

    public void ToggleBackpack()
    {
        if (bpWindow.activeInHierarchy)
            CloseBackpack();
        else
            OpenBackpack();
    }

    public void Collect(GameObject obj)
    {
        Items.Add(obj.GetComponent<RecyclableItem>());
        Destroy(obj);
    }

    public void itemClick(int idx)
    {
        Debug.Log(idx);

        GameObject icon = null;
        TrashType.Type itemType = Items[idx].Type;
        if (itemType == TrashType.Type.Plastic)
        {
            icon = Instantiate(bpSampleIconPlastic, throwObject.transform, false);
            icon.name = "Plastic";
        }
        else if (itemType == TrashType.Type.Glass)
        {
            icon = Instantiate(bpSampleIconGlass, throwObject.transform, false);
            icon.name = "Glass";

        }
        else if (itemType == TrashType.Type.Metal)
        {
            icon = Instantiate(bpSampleIconMetal, throwObject.transform, false);
            icon.name = "Metal";

        }
        else if (itemType == TrashType.Type.Paper)
        {
            icon = Instantiate(bpSampleIconPaper, throwObject.transform, false);
            icon.name = "Paper";

        }
        else if (itemType == TrashType.Type.Garbage)
        {
            icon = Instantiate(bpSampleIconGarbage, throwObject.transform, false);
            icon.name = "Garbage";
        }
        icon.transform.localPosition = new Vector3(-150, 150);
        icon.GetComponent<RectTransform>().sizeDelta = new Vector2(300, 300);
        CloseBackpack();
        
    }
}
