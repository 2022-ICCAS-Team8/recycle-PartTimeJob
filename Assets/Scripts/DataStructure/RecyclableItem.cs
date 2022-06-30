using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecyclableItem : MonoBehaviour
{
    public GameObject player;
    public GameObject popup;

    public TrashType.Type Type;
    public Sprite Sprite;
    
    public float detectDistance;

    BackpackManager bm;
    Renderer r;
    private void Awake()
    {
        bm = GameObject.Find("GameDirector").GetComponent<BackpackManager>();
        r = GetComponent<Renderer>();
    }

    private void Update()
    {
        float dist = Vector3.Distance(transform.position, player.transform.position);
        if (dist < detectDistance && r.isVisible)
        {
            popup.SetActive(true);

            if (Input.GetMouseButtonUp(1)) // rightclick
            {
                bm.Collect(this.gameObject);
                popup.SetActive(false);
            }
        }
        else
        {
            popup.SetActive(false);
        }
    }

}
