using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharaterMovement : MonoBehaviour
{
    public Vector3 target = new Vector3(0,0,0);
    public GameObject player;
    public Rigidbody2D rb;
    public int speed;
    public GameObject MouseCursor;
    public Text questProgress;
    private int friendsfound = 0;
    public GameObject Door;
    public GameObject GameoverPanel;

    void Update()
    {
        if(Input.GetKeyDown("escape")){
            Application.Quit();
        }
        if (Input.GetMouseButtonDown(0))
        {
        Vector2 newPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);    
        target.x = newPoint.x;
        target.y = newPoint.y;
        MouseCursor.transform. position = target;
        
        }
        if (friendsfound == 4)
        {
            friendsfound++;
            Destroy(Door.gameObject);

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
        if (other.tag == "Friend")
        {
            friendsfound++;
            questProgress.text = friendsfound.ToString() + "/4";
            Destroy(other.gameObject);
        }
        if (other.name == "portal")
        {
            Debug.Log("Game over, you won");
            GameoverPanel.SetActive(true);
            Time.timeScale = 0f;
            //Application.Quit();
        }
        if(other.tag == "Enemy"){
            Application.LoadLevel(1);
        }
    }
    
}
