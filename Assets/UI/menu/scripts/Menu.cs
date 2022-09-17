using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Button menuButton;
    public GameObject gameUI;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Menu0()
    {
        //·µ»ØÖ÷²Ëµ¥
        gameUI.SetActive(false);
        SceneManager.LoadScene(0);

    }

}