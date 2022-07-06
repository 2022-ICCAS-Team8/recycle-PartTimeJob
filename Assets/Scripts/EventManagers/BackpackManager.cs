using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BackpackManager : MonoBehaviour
{
    public List<GameItem> Items { get; set; }

    // number of backpack slots per row
    const int BACKPACK_SLOT = 8;

    // width of border of backpack UI (in pixels)
    const int BACKPACK_GAP = 10;

    // ratio of icon's width compared to slot's
    const float ICON_WIDTH_RATIO = 0.75f;

    // color selected, unselected
    public static readonly Color COLOR_SELECTED = new Color32(96, 96, 96, 255);
    public static readonly Color COLOR_UNSELECTED = new Color32(32, 32, 32, 255);

    public GameObject player;
    PlayerController pc;

    public GameObject bpWindow;
    public GameObject bpInnerWindow;
    public GameObject bpSampleSlot;

    public GameObject handIcon;

    public GameObject throwObject;

    // index of lastSelected slot
    public int lastSelectedIndex { get; set; }

    private void Awake()
    {
        Items = new List<GameItem>();
        lastSelectedIndex = -1;
    }

    void Start()
    {
        pc = player.GetComponent<PlayerController>();

        bpSampleSlot.GetComponent<Image>().color = COLOR_UNSELECTED;

        bpWindow.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            ToggleBackpack();
        }

        if (lastSelectedIndex == -1)
        {
            handIcon.GetComponent<Image>().sprite = null;
            handIcon.GetComponent<Image>().color = Color.clear; // transparent
        }
        else
        {
            handIcon.GetComponent<Image>().sprite = Items[lastSelectedIndex].Sprite;
            handIcon.GetComponent<Image>().color = Color.white;
        }
    }

    public void OpenBackpack()
    {
        float innerWidth = bpInnerWindow.GetComponent<RectTransform>().rect.width;

        // create contents
        for (int i=0; i < Items.Count; i++)
        {
            int idx = i;

            float w = (innerWidth - (BACKPACK_SLOT + 1) * BACKPACK_GAP) / BACKPACK_SLOT;
            float x =  (i % BACKPACK_SLOT) * (BACKPACK_GAP + w) + BACKPACK_GAP;
            float y = -(i / BACKPACK_SLOT) * (BACKPACK_GAP + w) - BACKPACK_GAP;

            GameObject slot = Instantiate(bpSampleSlot, bpInnerWindow.transform, false);
            slot.name = "bp_Slot" + i;
            slot.transform.localPosition = new Vector3(x, y);
            if (i == lastSelectedIndex)
                slot.GetComponent<Image>().color = COLOR_SELECTED;
            slot.GetComponent<Button>().onClick.AddListener(() => OnClickItem(idx)); // not 'i' but 'idx' to prevent closure problem

            GameObject icon = new GameObject();

            RectTransform trans = icon.AddComponent<RectTransform>();
            trans.SetParent(slot.transform);
            trans.localScale = Vector3.one;
            trans.anchoredPosition = new Vector3(0, 0);
            trans.sizeDelta = new Vector2(w, w) * ICON_WIDTH_RATIO;

            Image img = icon.AddComponent<Image>();
            img.sprite = Items[i].Sprite;
        }

        bpWindow.SetActive(true);

        // freeze player rotation
        pc.isMouseFrozen = true;
    }


    public void CloseBackpack()
    {
        bpWindow.SetActive(false);

        // destroy all children.
        if (bpInnerWindow.transform.childCount > 0)
        {
            // start from 1 because of SampleSlot
            for (int i = 1; i < bpInnerWindow.transform.childCount; i++)
            {
                Destroy(bpInnerWindow.transform.GetChild(i).gameObject);
            }
        }

        // melt player rotation
        pc.isMouseFrozen = false;
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
        Items.Add(obj.GetComponent<GameItem>());
        Destroy(obj);
    }

    public void OnClickItem(int idx)
    {
        // re-highlight selected slot
        if (lastSelectedIndex != -1)
            GameObject.Find("bp_Slot" + lastSelectedIndex).GetComponent<Image>().color = COLOR_UNSELECTED;
        lastSelectedIndex = idx;
        GameObject.Find("bp_Slot" + lastSelectedIndex).GetComponent<Image>().color = COLOR_SELECTED;


        // clear all throwObject made before
        if (throwObject.transform.childCount > 0)
        {
            for (int i = 0; i < throwObject.transform.childCount; i++)
            {
                Destroy(throwObject.transform.GetChild(i).gameObject);
            }
        }

        // make icon to SWC
        GameObject icon = new GameObject();

        RectTransform trans = icon.AddComponent<RectTransform>();
        trans.SetParent(throwObject.transform);
        trans.localScale = Vector3.one;
        trans.localPosition = Vector2.zero;
        trans.sizeDelta = new Vector2(300, 300);

        Image img = icon.AddComponent<Image>();
        img.sprite = Items[idx].Sprite;

        if (Items[idx] is RecyclableItem)
        {
            icon.name = ((RecyclableItem)Items[idx]).Type.ToString();
        }
        else
        {
            icon.name = "Other";
        }
    }

    public GameItem GetHoldingItem()
    {
        if (lastSelectedIndex == -1)
            return null;
        return Items[lastSelectedIndex];
    }

    public void ConsumeHoldingItem()
    {
        if (lastSelectedIndex != -1)
            Items.RemoveAt(lastSelectedIndex);
    }
}
