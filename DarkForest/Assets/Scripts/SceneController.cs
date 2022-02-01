using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{

    public GameObject[] sceneElements;

    void Start()
    {
        for (int i = 0; i < sceneElements.Length; i++)
        {
            sceneElements[i].SetActive(true);
        }
    }

}
