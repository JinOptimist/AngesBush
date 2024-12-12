using UnityEngine;

public class InitialBuild : MonoBehaviour
{
    public GameObject pairTemplate;

    public GameObject girlTemplate;
    public GameObject boyTemplate;
    public GameObject marriedTemplate;

    public float initialWidthForPair; // 3

    public int margin;

    void Start()
    {
        BuildGrandParents(0);
        BuildParents(0);
        BuildCouple(0);
    }

    private void BuildGrandParents(int xOfTheMiddle)
    {
        var countOfPairs = 4;
        var fullWidth = countOfPairs * initialWidthForPair + margin * (countOfPairs - 1);


        var halfWidthOfThePair = initialWidthForPair / 2;
        for (int i = 0; i < countOfPairs; i++)
        {
            var xForMiddle =
                halfWidthOfThePair
                + (initialWidthForPair + margin) * i
                - fullWidth / 2
                + xOfTheMiddle;
            BuildPair(initialWidthForPair, 5, xForMiddle);
        }
    }

    private void BuildParents(int xOfTheMiddle)
    {
        var countOfPairs = 2;

        // 7
        var witdthForPair = initialWidthForPair * 2 + margin - initialWidthForPair * 2 / 3;

        var fullWidth = countOfPairs * witdthForPair + margin * 3;

        var halfWidthOfThePair = witdthForPair / 2;

        for (int i = 0; i < countOfPairs; i++)
        {
            var xForMiddle =
                halfWidthOfThePair
                 + (witdthForPair + margin * 3) * i
                - fullWidth / 2
                + xOfTheMiddle;
            BuildPair(witdthForPair, 3, xForMiddle);
        }
    }

    private void BuildCouple(int xOfTheMiddle)
    {
        var countOfPairs = 1;

        // 9
        var witdthForPair = 9;//initialWidthForPair * 2 + margin - initialWidthForPair * 2 / 3;

        var fullWidth = countOfPairs * witdthForPair;

        var halfWidthOfThePair = witdthForPair / 2;

        for (int i = 0; i < countOfPairs; i++)
        {
            var xForMiddle =
                halfWidthOfThePair
                 + (witdthForPair + margin * 7) * i
                - fullWidth / 2
                + xOfTheMiddle;
            BuildPair(witdthForPair, 1, xForMiddle);
        }
    }

    private void BuildPair(float fullWidth, int y, float xForMiddle)
    {
        var pair = new GameObject($"Pair [{xForMiddle},{y}]");
        pair.transform.position = new Vector3(xForMiddle, y, 0);

        var halfOfWidth = fullWidth / 2;
        var widthOfTheItem = 1f;

        var girl = Instantiate(girlTemplate);
        girl.transform.SetParent(pair.transform);
        girl.transform.localPosition = new Vector3(
            0 - halfOfWidth,
            0,
            0);

        var boy = Instantiate(boyTemplate);
        boy.transform.SetParent(pair.transform);
        boy.transform.localPosition = new Vector3(
            halfOfWidth - widthOfTheItem,
            0,
            0);

        var married = Instantiate(marriedTemplate);
        married.transform.SetParent(pair.transform);

        married.transform.localPosition = new Vector3(
            -widthOfTheItem / 2,
            0,
            0);
        married.transform.localScale = new Vector3(
            0.1f,
            (fullWidth - widthOfTheItem) / 2,
            0.1f);
    }
}
