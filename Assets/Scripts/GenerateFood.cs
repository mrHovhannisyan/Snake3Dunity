using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFood : MonoBehaviour
{
    // Food Prefab
    public GameObject foodPrefab;

    // Game border coordinates
    float xSize = 8.8f;
    float zSize = 8.8f;

    public void Generate()
    {
        // x position between left & right border
        int x = (int)Random.Range(-xSize, xSize);

        // z position between top & bottom border
        int z = (int)Random.Range(-zSize, zSize);

        // Instantiate the food at (x, y= 0.5f, z)
        Instantiate(foodPrefab, new Vector3(x, 0.5f, z), Quaternion.identity);
    }
}