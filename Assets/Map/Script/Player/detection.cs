using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detection : MonoBehaviour
{

    int x, y, z;

    int blocknumber;

    bool leftclick;

    bool rightclick;

  

    //���ôݻٺʹ�����������Χ
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
            //�������������������������
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {

           

               
                x = Mathf.FloorToInt(hitInfo.point.x);
                y = Mathf.FloorToInt(hitInfo.point.y);
                z = Mathf.FloorToInt(hitInfo.point.z);

                //���ݷ�����������
                if (hitInfo.normal.x == 1) x--;
                if (hitInfo.normal.y == 1) y--;
                if (hitInfo.normal.z == 1) z--;
                x++;
                Vector3Int d = new Vector3Int(x, y, z);

                
                //�ݻ�����ͨ��������ĳɿ���
                if (leftclick)
                {
                    blocknumber = 0;
                }

                //��������ͨ���������ĳɶ�Ӧ����
                else if (rightclick)
                {



                    //����Ʒ����ȡ��ǰ����id
                    blocknumber = Select.itemnumber;


                    if (blocknumber == 8 || blocknumber == 9)
                    {
                        blocknumber = 1;
                    }


                    //ʹ�÷��߶������������
                    x = x + Mathf.FloorToInt(hitInfo.normal.x);
                    y = y + Mathf.FloorToInt(hitInfo.normal.y);
                    z = z + Mathf.FloorToInt(hitInfo.normal.z);
                    d = new Vector3Int(x, y, z);
                }

                //��ɫ����ʱ������е�ƽ̨�ȴ���������
                //��ֹ��ɫ�������������嵼�±���ͬʱ���ƽ�ɫ�ƻ��������Ч�뾶

                if (y <= 52 && hitInfo.distance <= Operatingradius )
                {
                    Map.instance.GetChunk(d).Des(x, y, z, Map.instance.GetChunk(d).position.x, Map.instance.GetChunk(d).position.y, Map.instance.GetChunk(d).position.z, blocknumber);
                    
                }



             
            }
        }
    }









}
