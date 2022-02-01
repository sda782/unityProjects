using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscControl : MonoBehaviour
{
    [SerializeField]
    private float force;
    private Rigidbody2D rb;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 pos2D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 dir = pos2D - (Vector2)transform.position;
            dir = dir.normalized;
            rb.AddForce(dir * Time.deltaTime * force, ForceMode2D.Impulse);
        }
    }
    void FixedUpdate()
    {
        if (rb.velocity.magnitude < 0.1f)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            rb.velocity = rb.velocity * 0.95F;
        }
    }
}