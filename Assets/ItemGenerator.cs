

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    // Prefabs for each item
    public GameObject HurdlePrefab;
    public GameObject StrawberryPrefab; // Numbers 1 to 3
    public GameObject ApplePrefab; // Numbers 4 to 6
    public GameObject BananaPrefab; // Numbers 7 to 9
    public GameObject GrapesPrefab; // Numbers 10 to 12
    public GameObject LemonPrefab; // Numbers 13 to 15
    public GameObject CherryPrefab; // Numbers 16 to 18
    public GameObject PearPrefab; // Numbers 19 to 21
    public GameObject PineapplePrefab; // Numbers 22 to 24
    public GameObject OrangePrefab; // Numbers 25 to 27
    public GameObject KiwiPrefab; // Numbers 28 to 30
    public GameObject WatermelonPrefab; // Numbers 31 to 33
    public GameObject FishPrefab; // Numbers 34 to 38

    // Start position
    private int startPosition = 15;
    // Goal position
    private int goalPosition = 235;

    // Range of x-axis position to generate items
    private float positionRange = 1.5f;

    void Start()
    {
        // Generate items at regular intervals
        for (int i = startPosition; i < goalPosition; i += 15)
        {
            // Randomly generate items from numbers 1 to 10 (Items 70%, Hurdles 30%)
            int num = Random.Range(1, 11);
            if (num <= 3)
            {
                // Generate hurdles in a straight line along the x-axis
                for (float j = -1; j <= 1; j += 1f)
                {
                    GameObject Hurdle = Instantiate(HurdlePrefab);
                    Hurdle.transform.position = new Vector3(j, Hurdle.transform.position.y, i);
                }
            }
            else if (4 <= num && num <= 10)
            {
                // Generate items lane by lane
                for (int j = -1; j <= 1; j++)
                {
                    // Determine the type of item to generate (12 types * 1 to 3 = up to number 38)
                    int item = Random.Range(1, 38);
                    // Randomly set offsets for placing items on the y and z axes
                    float offsetY = Random.Range(-0.5f, 1f);
                    int offsetZ = Random.Range(-5, 5);
                    if (item <= 3)
                    {
                        // Generate strawberry
                        GameObject strawberry = Instantiate(StrawberryPrefab);
                        strawberry.transform.position = new Vector3(positionRange * j, strawberry.transform.position.y + offsetY, i + offsetZ);
                    }
                    else if (4 <= item && item <= 6)
                    {
                        // Generate apple
                        GameObject apple = Instantiate(ApplePrefab);
                        apple.transform.position = new Vector3(positionRange * j, apple.transform.position.y + offsetY, i + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        // Generate banana
                        GameObject banana = Instantiate(BananaPrefab);
                        banana.transform.position = new Vector3(positionRange * j, banana.transform.position.y + offsetY, i + offsetZ);
                    }
                    else if (10 <= item && item <= 12)
                    {
                        // Generate grapes
                        GameObject grapes = Instantiate(GrapesPrefab);
                        grapes.transform.position = new Vector3(positionRange * j, grapes.transform.position.y + offsetY, i + offsetZ);
                    }
                    else if (13 <= item && item <= 15)
                    {
                        // Generate lemon
                        GameObject lemon = Instantiate(LemonPrefab);
                        lemon.transform.position = new Vector3(positionRange * j, lemon.transform.position.y + offsetY, i + offsetZ);
                    }
                    else if (16 <= item && item <= 18)
                    {
                        // Generate cherry
                        GameObject cherry = Instantiate(CherryPrefab);
                        cherry.transform.position = new Vector3(positionRange * j, cherry.transform.position.y + offsetY, i + offsetZ);
                    }
                    else if (19 <= item && item <= 21)
                    {
                        // Generate pear
                        GameObject pear = Instantiate(PearPrefab);
                        pear.transform.position = new Vector3(positionRange * j, pear.transform.position.y + offsetY, i + offsetZ);
                    }
                    else if (22 <= item && item <= 24)
                    {
                        // Generate pineapple
                        GameObject pineapple = Instantiate(PineapplePrefab);
                        pineapple.transform.position = new Vector3(positionRange * j, pineapple.transform.position.y + offsetY, i + offsetZ);
                    }
                    else if (25 <= item && item <= 27)
                    {
                        // Generate orange
                        GameObject orange = Instantiate(OrangePrefab);
                        orange.transform.position = new Vector3(positionRange * j, orange.transform.position.y + offsetY, i + offsetZ);
                    }
                    else if (28 <= item && item <= 30)
                    {
                        // Generate kiwi
                        GameObject kiwi = Instantiate(KiwiPrefab);
                        kiwi.transform.position = new Vector3(positionRange * j, kiwi.transform.position.y + offsetY, i + offsetZ);
                    }
                    else if (31 <= item && item <= 33)
                    {
                        // Generate watermelon
                        GameObject watermelon = Instantiate(WatermelonPrefab);
                        watermelon.transform.position = new Vector3(positionRange * j, watermelon.transform.position.y + offsetY, i + offsetZ);
                    }
                    else
                    {
                        // Generate fish
                        GameObject fish = Instantiate(FishPrefab);
                        fish.transform.position = new Vector3(positionRange * j, fish.transform.position.y + offsetY, i + offsetZ);
                    }
                }
            }
        }
    }

    void Update()
    {
        // No actions in Update for now
    }
}

