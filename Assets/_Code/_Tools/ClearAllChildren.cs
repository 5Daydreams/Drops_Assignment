using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearAllChildren : MonoBehaviour
{
    public void ClearAllChildrenObjects()
    {
        for (int i = this.transform.childCount - 1; i >= 0; i--)
        {
            GameObject child = this.transform.GetChild(i).gameObject;
            DestroyImmediate(child);
        }
    }
}