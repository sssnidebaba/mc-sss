using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detection : MonoBehaviour
{

    int x, y, z;

    int blocknumber;

    bool leftclick;

    bool rightclick;

  

    //设置摧毁和创建物体的最大范围
    public int Operatingradius = 10;

    // Start is called before the first frame update
    void Start()
    {
        x = y = z = 0;
        blocknumber = 0;
        leftclick = false;
        rightclick = false;
      
    }

    // Update is called once per frame
    void Update()
    {
        leftclick = Input.GetMouseButtonDown(0);
        rightclick = Input.GetMouseButtonDown(1);



        if (leftclick || rightclick)
        {
            //从摄像机发出到点击坐标的射线
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {

           

               
                x = Mathf.FloorToInt(hitInfo.point.x);
                y = Mathf.FloorToInt(hitInfo.point.y);
                z = Mathf.FloorToInt(hitInfo.point.z);

                //根据法线修正坐标
                if (hitInfo.normal.x == 1) x--;
                if (hitInfo.normal.y == 1) y--;
                if (hitInfo.normal.z == 1) z--;
                x++;
                Vector3Int d = new Vector3Int(x, y, z);

                
                //摧毁物体通过将物体改成空气
                if (leftclick)
                {
                    blocknumber = 0;
                }

                //创建物体通过将空气改成对应方块
                else if (rightclick)
                {



                    //从物品栏获取当前方块id
                    blocknumber = Select.itemnumber;


                    if (blocknumber == 8 || blocknumber == 9)
                    {
                        blocknumber = 1;
                    }


                    //使用法线对坐标进行修正
                    x = x + Mathf.FloorToInt(hitInfo.normal.x);
                    y = y + Mathf.FloorToInt(hitInfo.normal.y);
                    z = z + Mathf.FloorToInt(hitInfo.normal.z);
                    d = new Vector3Int(x, y, z);
                }

                //角色出生时在天空中的平台等待地形生成
                //防止角色点击出生点的物体导致报错，同时限制角色破坏方块的有效半径

                if (y <= 52 && hitInfo.distance <= Operatingradius )
                {
                    Map.instance.GetChunk(d).Des(x, y, z, Map.instance.GetChunk(d).position.x, Map.instance.GetChunk(d).position.y, Map.instance.GetChunk(d).position.z, blocknumber);
                    
                }



             
            }
        }
    }









}
