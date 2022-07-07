using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashType : MonoBehaviour
{
    public enum Type { Metal, Plastic, Glass, Paper, Garbage, None };
    public Type type;
    public int value;
}
