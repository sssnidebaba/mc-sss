using LibNoise;
using LibNoise.Generator;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Terrain : MonoBehaviour
{

   
    


    //通过方块的世界坐标获取它的方块类型
    public static int GetTerrainBlock(Vector3Int worldPosition)
    {
        //LibNoise噪音对象
        Perlin noise = new LibNoise.Generator.Perlin(1f, 1f, 1f, 8, GameManager.randomSeed, QualityMode.High);

        //为随机数指定种子
        Random.InitState(GameManager.randomSeed);

        //因为柏林噪音在(0,0)点是上下左右对称的，所以设置一个很远很远的地方作为新的(0,0)点
        Vector3 offset = new Vector3(Random.value * 100000, Random.value * 100000, Random.value * 100000);

        float noiseX = Mathf.Abs((worldPosition.x + offset.x) / 20);
        float noiseY = Mathf.Abs((worldPosition.y + offset.y) / 20);
        float noiseZ = Mathf.Abs((worldPosition.z + offset.z) / 20);
        double noiseValue = noise.GetValue(noiseX, noiseY, noiseZ);

        noiseValue += (40 - worldPosition.y) / 15f;
        noiseValue /= worldPosition.y / 5f;


        if (noiseValue > 0.5f && noiseValue < 0.7f )
        {

            return 1;

        }


        if ( noiseValue >= 0.7f && noiseValue < 0.9f)
        {


            return 3;

        }


        if (noiseValue >= 0.9f)
        {

            return 5;
        }




        return 0;
    }
}
