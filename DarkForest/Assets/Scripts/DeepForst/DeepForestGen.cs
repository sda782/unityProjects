using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeepForestGen : MonoBehaviour
{

    public List<GameObject> assets;
    public int TreeNumber_big;
    public int TreeNumber_small;
    [Range(0, 20)]
    public int TreeDensity;
    [Range(0, 20)]
    public int TreeDensity_small;

    public int RockAmount;
    [Range(0f, 10f)]
    public float RockDensity;

    public int GrassAmount;
    [Range(0f, 10f)]
    public float GrassDensity;

    void Start()
    {
        //Gen Trees
        for (int i = 0; i < TreeNumber_big; i++)
        {
            float y = Random.Range(0.6f, 1f);
            GameObject tree = Instantiate(assets[0]);
            tree.transform.position = new Vector3(transform.position.x + (TreeDensity * i), y, 0);
        }
        transform.position = new Vector3(Random.Range(-5, 0), transform.position.y, transform.position.z);
        //Gen Trees
        for (int i = 0; i < TreeNumber_small; i++)
        {
            float y = Random.Range(-0.5f, 0f);
            float x_offset = Random.Range(2f, 4f);
            GameObject tree = Instantiate(assets[1]);
            tree.transform.position = new Vector3(transform.position.x + (TreeDensity_small * i) + x_offset, y, 0);
        }
        transform.position = new Vector3(Random.Range(-5, 0), transform.position.y, transform.position.z);
        //Gen Rocks
        for (int i = 0; i < RockAmount; i++)
        {
            float y = Random.Range(-0.5f, 0f);
            float x_offset = Random.Range(2f, 4f);
            GameObject tree = Instantiate(assets[2]);
            tree.transform.position = new Vector3(transform.position.x + (RockDensity * i) + x_offset, y - 1f, 0);
        }
        transform.position = new Vector3(Random.Range(-5, 0), transform.position.y, transform.position.z);
        //Gen Grass
        for (int i = 0; i < TreeNumber_small; i++)
        {
            float y = Random.Range(-0.5f, 0f);
            float x_offset = Random.Range(2f, 4f);
            GameObject tree = Instantiate(assets[3]);
            tree.transform.position = new Vector3(transform.position.x + (TreeDensity_small * i) + x_offset, y - 1f, 0);
        }
    }

}
