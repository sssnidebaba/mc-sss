using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    //视线范围
    public int viewRange = 10;


    void Update()
    {
        //根据玩家位置判断是否要生成地图
        for (float x = transform.position.x - Chunk.width * viewRange; x < transform.position.x + Chunk.width * viewRange; x += Chunk.width)
        {
            for (float y = transform.position.y - Chunk.height * 3; y < transform.position.y + Chunk.height * 3; y += Chunk.height)
            {
                
                if (y <= Chunk.height * 1 && y > 0)
                {
                    for (float z = transform.position.z - Chunk.width * viewRange; z < transform.position.z + Chunk.width * viewRange; z += Chunk.width)
                    {
                        int xx = Chunk.width * Mathf.FloorToInt(x / Chunk.width);
                        int yy = Chunk.height * Mathf.FloorToInt(y / Chunk.height);
                        int zz = Chunk.width * Mathf.FloorToInt(z / Chunk.width);
                        if (!Map.instance.ChunkExists(xx, yy, zz))
                        {
                            Map.instance.CreateChunk(new Vector3Int(xx, yy, zz));
                        }
                    }
                }
            }
        }









    }
}
