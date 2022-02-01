using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rb;
    public float Speed;
    private SpriteRenderer playerSprite;
    private bool isGrounded = true;
    void Start(){
        playerSprite = player.GetComponent<SpriteRenderer>();
        rb = player.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw ("Horizontal");
        
        if (moveHorizontal < 0)
        {
            playerSprite.flipX = true;
        }else{
            playerSprite.flipX = false;
        }

        Vector2 pos = new Vector2(player.transform.position.x, player.transform.position.y);
        player.transform.position = new Vector2(pos.x + moveHorizontal * Time.deltaTime * Speed, pos.y);
        
        if(Input.GetAxisRaw("Vertical") > 0 && isGrounded){
            rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D col) 
    {
        isGrounded = true;
    }
}
