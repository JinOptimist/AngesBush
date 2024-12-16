using UnityEngine;

public class ScaleTheLink : MonoBehaviour
{
    public const string CHILD_LINK = "ChildLink";
    public const string CHILD = "Child";
    private Transform childLinkTransform;
    private Transform childTransform;

    public void SetScale(float newLinkScale)
    {
        if (childLinkTransform == null)
        {
            childLinkTransform = transform.Find(CHILD_LINK);
        }
        
        childLinkTransform.localScale = new Vector3(
            childLinkTransform.localScale.x, 
            newLinkScale / 2, // By default size of the link is 2. So 
            childLinkTransform.localScale.z);
        childLinkTransform.localPosition = new Vector3(
            newLinkScale / 2,
            0,
            0);

        if (childTransform == null)
        {
            childTransform = transform.Find(CHILD);
        }

        childTransform.localPosition = new Vector3(
            1 * newLinkScale,
            childTransform.localPosition.y,
            childTransform.localPosition.z);
    }
}
