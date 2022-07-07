using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItemCollector : MonoBehaviour
{
    public float detectDistance;

    GameObject popup;
    GameDirector gd;
    BackpackManager bm;
    private void Awake()
    {
        popup = GameObject.Find("PopupCollect");
        gd = GameObject.Find("GameDirector").GetComponent<GameDirector>();
        bm = GameObject.Find("GameDirector").GetComponent<BackpackManager>();
    }

    private void Update()
    {
        GameObject nearestObject = null;

        float minDist = Mathf.Infinity;
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("GameItem")) {
            float dist = Vector3.Distance(transform.position, obj.transform.position);
            if (dist < minDist)
            {
                nearestObject = obj;
                minDist = dist;
            }
        }

        if (minDist < detectDistance && nearestObject.GetComponent<Renderer>().isVisible)
        {
            popup.SetActive(true);

            if (Input.GetMouseButtonUp(1)) // rightclick
            {
                bm.Collect(nearestObject);
                popup.SetActive(false);
                if (nearestObject.GetComponent<GameItem>() is RecyclableItem)
                {
                    gd.AddCollectCount();
                }
            }
        }
        else
        {
            popup.SetActive(false);
        }
    }
}
