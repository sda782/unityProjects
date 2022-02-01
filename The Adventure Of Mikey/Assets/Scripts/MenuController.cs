using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    public GameObject Intro_obj;
    public GameObject btn_1;
    public GameObject btn_2;
    public GameObject title;

    public void StartGame(){
        Intro_obj.SetActive(true);
        btn_1.SetActive(false);
        btn_2.SetActive(false);
        title.SetActive(false);
    }

    public void LoadNextScene(){
        Application.LoadLevel(1);
    }

    public void QuitGame(){
        Application.Quit();
    }
}
