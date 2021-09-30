using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour
{

    public static Brain self;

    [SerializeField]
    private GameObject platform;

    // ---

    private float yPos = 2;
    private List<List<GameObject>> allLines = new List<List<GameObject>>();
    
    private void Awake()
    {
        self = this;

        StartCoroutine(SpawnPlatformsOnStart());
    }

    private IEnumerator SpawnPlatformsOnStart()
    {
        yield return new WaitForSeconds(0.1f);
        SpawnThreePlatforms();
        yield return new WaitForSeconds(0.1f);
        SpawnTwoPlatforms();
        yield return new WaitForSeconds(0.1f);
        SpawnThreePlatforms();
        yield return new WaitForSeconds(0.1f);
        SpawnTwoPlatforms();
        yield return new WaitForSeconds(0.1f);
        SpawnThreePlatforms();
        yield return new WaitForSeconds(0.1f);
        SpawnTwoPlatforms();
    }

    private void SpawnThreePlatforms()
    {
        allLines.Add(new List<GameObject> {
            Instantiate(platform, new Vector3(0, yPos, 0), Quaternion.identity),
            Instantiate(platform, new Vector3(-2, yPos, 0), Quaternion.identity),
            Instantiate(platform, new Vector3(2, yPos, 0), Quaternion.identity)
        });

        yPos -= 1.5f;
    }

    private void SpawnTwoPlatforms()
    {
        allLines.Add(new List<GameObject> {
            Instantiate(platform, new Vector3(1, yPos, 0), Quaternion.identity),
            Instantiate(platform, new Vector3(-1, yPos, 0), Quaternion.identity)
        });

        yPos -= 1.5f;
    }

    public void DestroyUpperLine()
    {
        foreach (var platform in allLines[0])
        {
            Destroy(platform);
        }
        
        allLines.RemoveAt(0);
    }

}
