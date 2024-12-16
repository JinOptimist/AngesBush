using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScaleChildrenLevel : MonoBehaviour
{
    public float scale;
    public const string CHILD_DISK = "ChildDisk";
    private Transform childDiscTransform;

    private void Update()
    {
        SetScale(scale);
    }

    public void SetScale(float newScale)
    {
        if (scale == newScale)
        {
            return;
        }

        scale = newScale;

        if (childDiscTransform == null)
        {
            childDiscTransform = transform.Find(CHILD_DISK);
        }

        childDiscTransform.localScale = new Vector3(
            2 * newScale, // multiply by two cause this is diameter
            0.01f,
            2 * newScale);

        foreach (var childWithLink in transform.GetComponentsInChildren<ScaleTheLink>())
        {
            childWithLink.SetScale(newScale);
        }
    }
}
