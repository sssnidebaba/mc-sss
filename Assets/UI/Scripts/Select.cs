using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{

    public static int itemnumber = 1;

    public float scrollSpeed = 5;//滑轮滚动速度

    float offset;

    bool selectflag;



   
    void Start()
    {
        offset = 0;
        selectflag = false;
    }

    

    void Update()
    {

        //通过鼠标滑轮选中工具槽

        offset -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;


        if (offset >= 1)
        {
            offset = 0;
            itemnumber++;
            if (itemnumber == 10)
            {
                itemnumber = 1;       
            }
            selectflag = true;
        }
        else if(offset <= -1)
        {
            offset = 0;
            itemnumber--;
            if (itemnumber == 0)
            {
                itemnumber = 9;
            }
            selectflag = true;

        }


        // 通过输入数字调用函数来选中工具槽

        if (Input.GetKeyDown("1"))
        {

            itemnumber = 1;
            selectflag = true;

        }

        if (Input.GetKeyDown("2"))
        {

            itemnumber = 2;
            selectflag = true;

        }

        if (Input.GetKeyDown("3"))
        {

            itemnumber = 3;
            selectflag = true;

        }

        if (Input.GetKeyDown("4"))
        {

            itemnumber = 4;
            selectflag = true;

        }

        if (Input.GetKeyDown("5"))
        {

            itemnumber = 5;
            selectflag = true;

        }

        if (Input.GetKeyDown("6"))
        {

            itemnumber = 6;
            selectflag = true;

        }

        if (Input.GetKeyDown("7"))
        {

            itemnumber = 7;
            selectflag = true;

        }

        if (Input.GetKeyDown("8"))
        {

            itemnumber = 8;
            selectflag = true;

        }

        if (Input.GetKeyDown("9"))
        {

            itemnumber = 9;
            selectflag = true;

        }



        if (selectflag)
        {

            HotbarController.instanc.SelectItem(itemnumber-1);
            selectflag = false;


        }



    }
}
