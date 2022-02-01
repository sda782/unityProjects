using System.Collections;
using System.Collections.Generic;
using PixelPirate.Assets.Ground;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private World world;
    [SerializeField]
    private Player playerChunk;
    [SerializeField]
    private InventoryManager inventory;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            Debug.Log($"Get resource from chunk {world.GetResourceFromPlayerPos()}");

        }
    }
}
