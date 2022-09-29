using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackList : MonoBehaviour
{
    public static StackList instance;
    public List<GameObject> stack = new List<GameObject>();
 

    private void Awake()
    {
        instance = this;
    }
}
