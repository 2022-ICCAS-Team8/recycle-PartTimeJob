using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    public List<TrashType> backpack;

    GameObject backpackWindow;

    private void Awake()
    {
        backpackWindow = GameObject.Find("BackpackWindow");
    }

    // Start is called before the first frame update
    void Start()
    {
        backpackWindow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab))
            SetBackpackOpen(!backpackWindow.activeInHierarchy);
    }


    public void OnClickBackpackButton()
    {
        SetBackpackOpen(!backpackWindow.activeInHierarchy);
    }

    public void OpenBackpack()
    {
        // create contents

        backpackWindow.SetActive(true);
    }

    public void CloseBackpack()
    {
        backpackWindow.SetActive(false);

        // remove contents
    }

    public void SetBackpackOpen(bool isOpen)
    {
        if (isOpen)
            OpenBackpack();
        else
            CloseBackpack();
    }
}
