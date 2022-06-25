using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeparateWasteCollection : MonoBehaviour
{
    public RectTransform uiGroup;
    public Animator anim;

    //public Player enterPlayer;

    public void Enter()
    {
        //enterPlayer = player; 
        anim.SetTrigger("openLid");
        uiGroup.anchoredPosition = Vector3.zero;
    }

    void Exit()
    {
        anim.SetTrigger("closeLid");
        uiGroup.anchoredPosition = Vector3.down*1000;
    }
}
