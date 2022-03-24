using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject floor;

    Transform tr;

    public int floorCount;

    public float floorWidth;

    public float minY, maxY;

    private void Start()
    {
        tr = floor.GetComponent<Transform>();
        Vector3 spawnLocation = new Vector3();
        Vector2 newScale = new Vector2();

        for (int i = 0; i < floorCount; i++)
        {
            newScale.x = Random.Range(8f, 11f);
            newScale.y = Random.Range(0.9f, 1.1f);
            tr.localScale = newScale;


            spawnLocation.y += Random.Range(minY, maxY);
            spawnLocation.x += Random.Range(-floorWidth, floorWidth);

            Instantiate(floor, spawnLocation, Quaternion.identity);
        }
    }
}
