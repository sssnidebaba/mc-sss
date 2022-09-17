using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Startgame : MonoBehaviour
{
    public Button StartButton;
    public GameObject MenuUI;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void Start1()
    {





        //Ω¯»Î”Œœ∑
        MenuUI.SetActive(false);
        SceneManager.LoadScene(1);



    }


}
