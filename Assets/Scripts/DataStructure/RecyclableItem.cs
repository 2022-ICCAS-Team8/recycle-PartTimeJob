using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecyclableItem : MonoBehaviour
{
    protected static int COUNT = 0;

    int id;
    public TrashType.Type Type;
    public Sprite Sprite;

    public RecyclableItem(TrashType.Type type, Sprite sprite)
    {
        this.id = COUNT++;
        this.Type = type;
        this.Sprite = sprite;
    }
}
