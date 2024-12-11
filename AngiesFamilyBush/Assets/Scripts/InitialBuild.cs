using UnityEngine;

public class InitialBuild : MonoBehaviour
{
    public GameObject pair;

    public GameObject girl;
    public GameObject boy;

    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            BuildPairsForTheLevel(i);
        }
    }

    private void BuildPairsForTheLevel(int level)
    {
        for (int i = 0; i < level * 2; i++)
        {
            var newPair = Instantiate(pair);
            var x = (i - level) * 3;
            
            newPair.transform.position = new Vector3(x, level * 2, 0);
        }

    }
}
