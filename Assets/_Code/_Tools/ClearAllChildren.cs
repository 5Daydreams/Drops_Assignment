using UnityEngine;

#if UNITY_EDITOR

public class ClearAllChildren : MonoBehaviour
{
    public void ClearAllChildrenObjects()
    {
        if (transform.childCount == 0)
        {
            Debug.Log("No children found");
            return;
        }
        
        for (int i = this.transform.childCount - 1; i >= 0; i--)
        {
            GameObject child = this.transform.GetChild(i).gameObject;
            DestroyImmediate(child);
        }
    }
}

#endif
