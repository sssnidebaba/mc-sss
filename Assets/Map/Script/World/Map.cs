using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public static Map instance;

    public static GameObject chunkPrefab;

    public Dictionary<Vector3Int, GameObject> chunks = new Dictionary<Vector3Int, GameObject>();

    //public Dictionary<Vector3Int, int[,,]> blockmemory = new Dictionary<Vector3Int, int[,,]>();

    //当前是否正在生成Chunk
    private bool spawningChunk = false;

    void Awake()
    {
        instance = this;
        chunkPrefab = Resources.Load("Prefab/Chunk") as GameObject;
    }

    //生成Chunk
    public void CreateChunk(Vector3Int pos)
    {
        if (spawningChunk) return;
         
        StartCoroutine(SpawnChunk(pos));
    }

    private IEnumerator SpawnChunk(Vector3Int pos)
    {
        spawningChunk = true;
      
        Instantiate(chunkPrefab, pos, Quaternion.identity);
        yield return null;
        spawningChunk = false;
    }

    //通过Chunk的坐标来判断它是否存在
    public bool ChunkExists(Vector3Int worldPosition)
    {
        return this.ChunkExists(worldPosition.x, worldPosition.y, worldPosition.z);
    }
    //通过Chunk的坐标来判断它是否存在
    public bool ChunkExists(int x, int y, int z)
    {
        return chunks.ContainsKey(new Vector3Int(x, y, z));
    }

    //通过世界坐标获取Chunk对象
    public Chunk GetChunk(Vector3Int worldPosition)
    {
        int xx = Chunk.width * Mathf.FloorToInt(1.0f * worldPosition.x / Chunk.width);
        int yy = Chunk.height * Mathf.FloorToInt(1.0f * worldPosition.y / Chunk.height);
        int zz = Chunk.width * Mathf.FloorToInt(1.0f * worldPosition.z / Chunk.width);
        if (Map.instance.chunks.ContainsKey(new Vector3Int(xx, yy, zz)))
        {
            return Map.instance.chunks[new Vector3Int(xx, yy, zz)].GetComponent<Chunk>();
        }
        return null;
        
    }
}

