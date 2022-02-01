
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public float thrust = 1.0f;
    public GameObject Camera;
    public GameObject[] DicePreFab;
    public GameObject Platform;

    private int _selectedDie = 5;
    private bool _dieInPlay;

    void Start()
    {
        _dieInPlay = false;

    }
    private GameObject die;
    private Rigidbody dieRb;
    void Update()
    {
        if (_dieInPlay)
        {
            
            if (dieRb.velocity == Vector3.zero)
            {
                Camera.transform.position = new Vector3(die.transform.position.x, die.transform.position.y + 4, die.transform.position.z);
            }
            else { 
                Camera.transform.position = new Vector3(die.transform.position.x, die.transform.position.y + 10, die.transform.position.z);
            }
            //Camera.transform.LookAt(die.transform.position);

        }

    }

    public void RollDie(int dieNumber)
    {
        if (!_dieInPlay)
        {
            SpawnPlatform();
            _dieInPlay = true;
            die = Instantiate(DicePreFab[dieNumber], transform.position, Quaternion.Euler(Random.Range(0, 4) * 90, Random.Range(0, 4) * 90, Random.Range(0, 4) * 90));
            dieRb = die.GetComponent<Rigidbody>();
            Vector3 dir = new Vector3();
            dir.x = Random.Range(-10, 10);
            dir.y = Random.Range(-10, 10);
            dir.z = Random.Range(-10, 10);
            dir.Normalize();
            dieRb.AddForce(Vector3.down * thrust, ForceMode.Impulse);

        }
        else
        {
            Destroy(_platform);
            Destroy(die);
            _dieInPlay = false;
            RollDie(dieNumber);
        }
    }

    private GameObject _platform;
    public void SpawnPlatform()
    {
        _platform = Instantiate(Platform, new Vector3(0,3,0), Quaternion.Euler(Random.Range(0, 4) * 10, 0, Random.Range(0, 4) * 10));
    }
}
