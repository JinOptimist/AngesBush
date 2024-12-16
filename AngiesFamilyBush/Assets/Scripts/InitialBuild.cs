using System;
using Unity.VisualScripting;
using UnityEngine;

public class InitialBuild : MonoBehaviour
{
    #region OLD
    public GameObject pairTemplate;

    public GameObject girlTemplate;
    public GameObject boyTemplate;

    public GameObject marriedTemplate;
    public GameObject childLinkTemplate;

    public float initialWidthForPair; // 3

    public int margin;
    #endregion

    public GameObject childrenLevelTemplate;
    public GameObject childrenLinkWithPivotTemplate;

    public float scaleFirstPair; // 5f
    public int maxChildrenCount; // 5;

    void Start()
    {
        // var scaleFirstPair = 6f;
        var pair = BuildPairWithChildren(maxChildrenCount, 3, scaleFirstPair);

        var childrens = pair.GetComponentsInChildren<ScaleTheLink>();

        for (int i = 0; i < childrens.Length; i++)
        {
            var child = childrens[i].transform;
            
            var childPair = BuildPairWithChildren(maxChildrenCount - i, 1);

            childPair.transform.SetParent(child);
            childPair.transform.localPosition = new Vector3(scaleFirstPair + 1, 0, 0);
            childPair.transform.localEulerAngles = new Vector3(0, 0, 0);
        }

        //BuildGrandParents(0);
        //BuildParents(0);
        //BuildCouple(0);
    }

    private GameObject BuildPairWithChildren(int childrenCount = 5, int y = 3, float scale = 3)
    {
        var pair = BuildPair(initialWidthForPair, y, 0);

        var childrenLevel = Instantiate(childrenLevelTemplate);
        childrenLevel.transform.SetParent(pair.transform);
        childrenLevel.transform.localPosition = new Vector3(0, -2, 0);

        // childrenLevelTemplate.GetComponent<ScaleChildrenLevel>().SetScale(scale);
        var stepDegrees = 360 / childrenCount;
        for (int i = 0; i < childrenCount; i++)
        {
            var child = Instantiate(childrenLinkWithPivotTemplate);
            child.transform.SetParent(childrenLevel.transform);
            child.transform.localPosition = new Vector3(0, 0, 0);
            // TODO Vector3.Lerp(transform.rotation.eulerAngles, to, Time.deltaTime);
            child.transform.localEulerAngles = new Vector3(0, i * stepDegrees, 0);
        }

        childrenLevel.GetComponent<ScaleChildrenLevel>().SetScale(scale);

        return pair;
    }

    //private void BuildGrandParents(int xOfTheMiddle)
    //{
    //    var countOfPairs = 4;
    //    var fullWidth = countOfPairs * initialWidthForPair + margin * (countOfPairs - 1);


    //    var halfWidthOfThePair = initialWidthForPair / 2;
    //    for (int i = 0; i < countOfPairs; i++)
    //    {
    //        var xForMiddle =
    //            halfWidthOfThePair
    //            + (initialWidthForPair + margin) * i
    //            - fullWidth / 2
    //            + xOfTheMiddle;
    //        var pair = BuildPair(initialWidthForPair, 5, xForMiddle);

    //        BuildChildLink(pair);
    //    }
    //}

    //private void BuildParents(int xOfTheMiddle)
    //{
    //    var countOfPairs = 2;

    //    // 7
    //    var witdthForPair = initialWidthForPair * 2 + margin - initialWidthForPair * 2 / 3;

    //    var fullWidth = countOfPairs * witdthForPair + margin * 3;

    //    var halfWidthOfThePair = witdthForPair / 2;

    //    for (int i = 0; i < countOfPairs; i++)
    //    {
    //        var xForMiddle =
    //            halfWidthOfThePair
    //             + (witdthForPair + margin * 3) * i
    //            - fullWidth / 2
    //            + xOfTheMiddle;
    //        var pair = BuildPair(witdthForPair, 3, xForMiddle);
    //        BuildChildLink(pair);
    //    }
    //}

    //private void BuildCouple(int xOfTheMiddle)
    //{
    //    var countOfPairs = 1;

    //    // 9
    //    var witdthForPair = 9;//initialWidthForPair * 2 + margin - initialWidthForPair * 2 / 3;

    //    var fullWidth = countOfPairs * witdthForPair;

    //    var halfWidthOfThePair = witdthForPair / 2;

    //    for (int i = 0; i < countOfPairs; i++)
    //    {
    //        var xForMiddle =
    //            halfWidthOfThePair
    //             + (witdthForPair + margin * 7) * i
    //            - fullWidth / 2
    //            + xOfTheMiddle;
    //        BuildPair(witdthForPair, 1, xForMiddle);
    //    }
    //}

    private GameObject BuildPair(float fullWidth, int y, float xForMiddle)
    {
        var pair = new GameObject($"Pair [{xForMiddle},{y}]");
        pair.transform.position = new Vector3(xForMiddle, y, 0);

        var halfOfWidth = fullWidth / 2;
        var widthOfTheItem = 1f;

        var girl = Instantiate(girlTemplate);
        girl.transform.SetParent(pair.transform);
        girl.transform.localPosition = new Vector3(
            0 - halfOfWidth + widthOfTheItem / 2,
            0,
            0);

        var boy = Instantiate(boyTemplate);
        boy.transform.SetParent(pair.transform);
        boy.transform.localPosition = new Vector3(
            halfOfWidth - widthOfTheItem / 2,
            0,
            0);

        var married = Instantiate(marriedTemplate);
        married.transform.SetParent(pair.transform);

        married.transform.localPosition = new Vector3(
            0,
            0,
            0);
        married.transform.localScale = new Vector3(
            0.1f,
            (fullWidth - widthOfTheItem) / 2,
            0.1f);

        return pair;
    }

    //private void BuildChildLink(GameObject pair)
    //{
    //    var childLink = Instantiate(childLinkTemplate);
    //    childLink.transform.SetParent(pair.transform);

    //    childLink.transform.localPosition = new Vector3(0, -1, 0);
    //}
}
