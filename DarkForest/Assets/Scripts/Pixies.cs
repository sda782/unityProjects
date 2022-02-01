using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pixies : MonoBehaviour
{

    public Vector3 target = new Vector3(0,0,0);
    public Rigidbody2D rb;
    public int speed;
    public GameObject MouseCursor;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
        Vector2 newPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);    
        target.x = newPoint.x;
        target.y = newPoint.y;
        MouseCursor.transform. position = target;
        }

    }

    void FixedUpdate(){
        if(transform.position != target){
            Vector3 dir = target - transform.position;
            dir.Normalize();
            rb.MovePosition(transform.position + dir * Time.fixedDeltaTime * speed);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.name == "MousePosition")
        {
            transform.position = target;
        }

    }
}
