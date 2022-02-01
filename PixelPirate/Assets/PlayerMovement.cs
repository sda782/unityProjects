using System.Collections;
using System.Collections.Generic;
using PixelPirate.Assets.Ground;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 20.0f;
    [SerializeField]
    private float boost = 2f;
    private float normalSpeed;
    [SerializeField]
    private World world;
    [SerializeField]
    private Player playerChunk;
    void Start()
    {
        normalSpeed = speed;
        playerChunk = GetComponent<Player>();
        gameObject.transform.position = new Vector2(world.Grid.CenterCell.X * 20 + 10, world.Grid.CenterCell.Y * 20 + 10);
        world.UpdateWorld();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            speed = speed * boost;
        }
        else if (Input.GetButtonUp("Fire3"))
        {
            speed = normalSpeed;
        }
        float trans_vertical = Input.GetAxis("Vertical") * speed;
        float trans_horizontal = Input.GetAxis("Horizontal") * speed;
        if (Mathf.Round(Mathf.Abs(transform.position.x - 10)) % 20 <= 0)
        {
            //playerChunk.Position.UpdateXY(playerChunk.Position.X + (int)Mathf.RoundToInt(trans_horizontal), playerChunk.Position.Y);
            playerChunk.Position.UpdateXY(Mathf.RoundToInt(transform.position.x / 20), playerChunk.Position.Y);
            world.UpdateWorld();
        }
        if (Mathf.Round(Mathf.Abs(transform.position.y - 10)) % 20 <= 0)
        {
            //playerChunk.Position.UpdateXY(playerChunk.Position.X + (int)Mathf.RoundToInt(trans_horizontal), playerChunk.Position.Y);
            playerChunk.Position.UpdateXY(playerChunk.Position.X, Mathf.RoundToInt(transform.position.y / 20));
            world.UpdateWorld();
        }

        trans_vertical *= Time.deltaTime;
        trans_horizontal *= Time.deltaTime;

        transform.Translate(trans_horizontal, trans_vertical, 0);
    }
}
