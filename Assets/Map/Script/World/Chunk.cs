using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Chunk : MonoBehaviour
{
    public static int width = 16;
    public static int height = 52;

    public int[,,] blocks;



    public Vector3Int position;

    private Mesh mesh;

    //面需要的点
    private List<Vector3> vertices = new List<Vector3>();

    //生成三边面时用到的vertices的index
    private List<int> triangles = new List<int>();

    //所有的uv信息
    private List<Vector2> uv = new List<Vector2>();

    //uv贴图每行每列的宽度(0~1)，这里我的贴图是32×32的，所以是1/32
    public static float textureOffset = 1 / 32f;

    //让UV稍微缩小一点，避免出现它旁边的贴图
    public static float shrinkSize = 0.005f;


    //当前Chunk是否正在生成中
    public static bool isWorking = false;
    private bool isFinished = false;


    private int a, b, c;

    int nub1, nub2, nub3;

    int stumpnum;

    int coalnum;

    bool stumpflag;
    bool leavesflag;
    bool coalflag;
    bool underwaterflag;
    bool groundflag;

    void Start()
    {
        blocks = new int[width, height, width];
        Ran();
        stumpflag = true;
        leavesflag = true;
        coalflag = true;
        underwaterflag = true;
        groundflag = true;
        stumpnum = 0;
        coalnum = 0;




        a = Mathf.FloorToInt(this.transform.position.x);
        b = Mathf.FloorToInt(this.transform.position.y);
        c = Mathf.FloorToInt(this.transform.position.z);
        position = new Vector3Int(a, b, c);
        if (Map.instance.ChunkExists(position))
        {
            Debug.Log("此方块已存在" + position);
            Destroy(this);
        }
        else
        {
            Map.instance.chunks.Add(position, this.gameObject);
            this.name = "(" + position.x + "," + position.y + "," + position.z + ")";
            //StartFunction();
        }

    }

    void Update()
    {
        if (isWorking == false && isFinished == false)
        {
            isFinished = true;
            StartFunction();
        }
    }
    void Awake()
    {
        isWorking = false;
    }

    void StartFunction()
    {
        isWorking = true;
        mesh = new Mesh();
        mesh.name = "Chunk";

        StartCoroutine(CreateMap());
    }

    //制造随机数用于地形物体的随机生成
    void Ran()
    {
        nub1 = Random.Range(3, 14);
        nub2 = Random.Range(3, 14);
        nub3 = Random.Range(4, 8);
    }



    public void Des(int x1, int y1, int z1, int x2, int y2, int z2, int blocknumber)
    {
        isWorking = true;

        Vector3Int d = new Vector3Int(x2, y2, z2);

        //通过chunk坐标与方块的世界坐标求出方块的相对坐标

        int x3 = x1 - x2;
        int y3 = y1 - y2;
        int z3 = z1 - z2;


        Map.instance.GetChunk(d).blocks[x3, y3, z3] = blocknumber;



        vertices.Clear();
        triangles.Clear();
        uv.Clear();



        //把所有面的点和面的索引添加进去
        for (int x = 0; x < Chunk.width; x++)
        {


            for (int z = 0; z < Chunk.width; z++)
            {
                for (int y = 0; y < Chunk.height; y++)
                {
                    //获取当前坐标的Block对象






                    Block block = BlockList.GetBlock(Map.instance.GetChunk(d).blocks[x, y, z]);
                    if (block == null) continue;

                    if (IsBlockTransparent(x + 1, y, z))
                    {
                        AddFrontFace(x, y, z, block);
                    }
                    if (IsBlockTransparent(x - 1, y, z))
                    {
                        AddBackFace(x, y, z, block);
                    }
                    if (IsBlockTransparent(x, y, z + 1))
                    {
                        AddRightFace(x, y, z, block);
                    }
                    if (IsBlockTransparent(x, y, z - 1))
                    {
                        AddLeftFace(x, y, z, block);
                    }
                    if (IsBlockTransparent(x, y + 1, z))
                    {
                        AddTopFace(x, y, z, block);
                    }
                    if (IsBlockTransparent(x, y - 1, z))
                    {
                        AddBottomFace(x, y, z, block);
                    }
                }
            }



        }



        //为点和index赋值
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.uv = uv.ToArray();

        //重新计算顶点和法线
        // mesh.RecalculateBounds();
        mesh.RecalculateNormals();

        //将生成好的面赋值给组件
        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshCollider>().sharedMesh = mesh;


        vertices.Clear();
        triangles.Clear();
        uv.Clear();



        //把所有面的点和面的索引添加进去
        for (int x = 0; x < Chunk.width; x++)
        {


            for (int z = 0; z < Chunk.width; z++)
            {
                for (int y = 0; y < Chunk.height; y++)
                {
                    //获取当前坐标的Block对象






                    Block block = BlockList.GetBlock(Map.instance.GetChunk(d).blocks[x, y, z]);
                    if (block == null) continue;

                    if (IsBlockTransparent(x + 1, y, z))
                    {
                        AddFrontFace(x, y, z, block);
                    }
                    if (IsBlockTransparent(x - 1, y, z))
                    {
                        AddBackFace(x, y, z, block);
                    }
                    if (IsBlockTransparent(x, y, z + 1))
                    {
                        AddRightFace(x, y, z, block);
                    }
                    if (IsBlockTransparent(x, y, z - 1))
                    {
                        AddLeftFace(x, y, z, block);
                    }
                    if (IsBlockTransparent(x, y + 1, z))
                    {
                        AddTopFace(x, y, z, block);
                    }
                    if (IsBlockTransparent(x, y - 1, z))
                    {
                        AddBottomFace(x, y, z, block);
                    }
                }
            }



        }



        //为点和index赋值
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.uv = uv.ToArray();

        //重新计算顶点和法线
        // mesh.RecalculateBounds();
        mesh.RecalculateNormals();

        //将生成好的面赋值给组件
        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshCollider>().sharedMesh = mesh;




        isWorking = false;

    
    }




    IEnumerator CreateMap()
    {


        for (int x = 0; x < Chunk.width; x++)
        {

            for (int z = 0; z < Chunk.width; z++)
            {

                underwaterflag = true;
                groundflag = true;

                for (int y = 0; y < Chunk.height; y++)
                {

                    int blockid = Terrain.GetTerrainBlock(new Vector3Int(x, y, z) + position);

                    if (y > 15) underwaterflag = false;

                    if (blockid == 1 && Terrain.GetTerrainBlock(new Vector3Int(x, y + 1, z) + position) == 0
                        && Terrain.GetTerrainBlock(new Vector3Int(x + 1, y, z) + position) != 3 && Terrain.GetTerrainBlock(new Vector3Int(x - 1, y, z) + position) != 3
                        && Terrain.GetTerrainBlock(new Vector3Int(x, y, z + 1) + position) != 3 && Terrain.GetTerrainBlock(new Vector3Int(x, y, z - 1) + position) != 3)
                    {
                        //生成草地或沙子

                        if (underwaterflag)
                        {
                            blocks[x, y, z] = 5;
                        }
                        else
                        {
                            blocks[x, y, z] = 2;
                        }


                        groundflag = true;



                    }
                    else if (blockid == 1 && Terrain.GetTerrainBlock(new Vector3Int(x, y + 1, z) + position) == 1 && Terrain.GetTerrainBlock(new Vector3Int(x + 1, y, z) + position) == 1
                        && Terrain.GetTerrainBlock(new Vector3Int(x - 1, y, z) + position) != 2 && Terrain.GetTerrainBlock(new Vector3Int(x, y, z + 1) + position) == 1
                        && Terrain.GetTerrainBlock(new Vector3Int(x, y, z - 1) + position) != 2)
                    {
                        //生成石头或煤炭
                        if ((nub2 + x + z + y) % 6 == 1 && coalflag)
                        {
                            blocks[x, y, z] = 4;

                            coalnum++;

                            groundflag = true;

                        }
                        else
                        {

                            blocks[x, y, z] = 3;

                            groundflag = true;

                        }

                    }
                    else if (blockid == 3 && (nub2 + x + z + y) % 6 == 1)
                    {
                        //生成煤炭
                        blocks[x, y, z] = 4;

                        coalnum++;
                        groundflag = true;



                    }
                    else if (blockid == 0 && Terrain.GetTerrainBlock(new Vector3Int(x, y + 1, z) + position) == 0 && stumpflag && x == nub1 && z == nub2 && !underwaterflag && groundflag)
                    {
                        //生成树桩，通过tick控制树桩高度
                        blocks[x, y, z] = 6;

                        stumpnum++;
                        groundflag = true;
                    }
                    else if (blockid == 0 && stumpflag == false && leavesflag)
                    {

                        //生成树叶
                        blocks[x, y, z] = 7;
                        blocks[x + 1, y, z] = 7;
                        blocks[x - 1, y, z] = 7;
                        blocks[x, y, z + 1] = 7;
                        blocks[x, y, z - 1] = 7;
                        blocks[x + 1, y, z + 1] = 7;
                        blocks[x + 1, y, z - 1] = 7;
                        blocks[x - 1, y, z + 1] = 7;
                        blocks[x - 1, y, z - 1] = 7;

                        blocks[x, y + 1, z] = 7;
                        blocks[x + 1, y + 1, z] = 7;
                        blocks[x - 1, y + 1, z] = 7;
                        blocks[x, y + 1, z + 1] = 7;
                        blocks[x, y + 1, z - 1] = 7;
                        blocks[x + 1, y + 1, z + 1] = 7;
                        blocks[x + 1, y + 1, z - 1] = 7;
                        blocks[x - 1, y + 1, z + 1] = 7;
                        blocks[x - 1, y + 1, z - 1] = 7;

                        blocks[x, y + 2, z] = 7;

                        blocks[x + 1, y - 1, z] = 7;
                        blocks[x - 1, y - 1, z] = 7;
                        blocks[x, y - 1, z + 1] = 7;
                        blocks[x, y - 1, z - 1] = 7;
                        blocks[x + 1, y - 1, z + 1] = 7;
                        blocks[x + 1, y - 1, z - 1] = 7;
                        blocks[x - 1, y - 1, z + 1] = 7;
                        blocks[x - 1, y - 1, z - 1] = 7;

                        groundflag = true;

                        leavesflag = false;
                    }
                    else if (blocks[x, y, z] == 0)
                    {
                        blocks[x, y, z] = Terrain.GetTerrainBlock(new Vector3Int(x, y, z) + position);
                        if (blocks[x, y, z] != 0)
                        {
                            groundflag = true;
                        }
                        else
                        {
                            groundflag = false;
                        }
                    }

                    if (stumpnum == nub3)
                    {
                        stumpflag = false;
                    }

                    if (coalnum == nub3)
                    {
                        coalflag = false;
                    }

                }
            }
        }


  
        yield return null;
        StartCoroutine(CreateMesh());
    }



    IEnumerator CreateMesh()
    {
        vertices.Clear();
        triangles.Clear();
        Ran();


        //把所有面的点和面的索引添加进去
        for (int x = 0; x < Chunk.width; x++)
        {
            for (int z = 0; z < Chunk.width; z++)
            {
                for (int y = 0; y < Chunk.height; y++)
                {
                    //获取当前坐标的Block对象
                    Block block = BlockList.GetBlock(this.blocks[x, y, z]);
                    if (block == null) continue;

                    if (IsBlockTransparent(x + 1, y, z))
                    {
                        AddFrontFace(x, y, z, block);
                    }
                    if (IsBlockTransparent(x - 1, y, z))
                    {
                        AddBackFace(x, y, z, block);
                    }
                    if (IsBlockTransparent(x, y, z + 1))
                    {
                        AddRightFace(x, y, z, block);
                    }
                    if (IsBlockTransparent(x, y, z - 1))
                    {
                        AddLeftFace(x, y, z, block);
                    }
                    if (IsBlockTransparent(x, y + 1, z))
                    {
                        AddTopFace(x, y, z, block);
                    }
                    if (IsBlockTransparent(x, y - 1, z))
                    {
                        AddBottomFace(x, y, z, block);
                    }
                }
            }
        }


        //为点和index赋值
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.uv = uv.ToArray();

        //重新计算顶点和法线
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();

        //将生成好的面赋值给组件
        this.GetComponent<MeshFilter>().mesh = mesh;
        this.GetComponent<MeshCollider>().sharedMesh = mesh;









        yield return null;
        isWorking = false;
    }

    //此坐标方块是否透明，Chunk中的局部坐标
    public bool IsBlockTransparent(int x, int y, int z)
    {
        if (x < width && y == -1 && z < width)
        {
            return false;
        }



        if (x >= width || y >= height || z >= width || x < 0 || y < 0 || z < 0)
        {
            return true;
        }

        else
        {
            //如果当前方块的id是0，那的确是透明的
            return this.blocks[x, y, z] == 0;
        }
    }



    //前面
    void AddFrontFace(int x, int y, int z, Block block)
    {
        //第一个三角面
        triangles.Add(0 + vertices.Count);
        triangles.Add(3 + vertices.Count);
        triangles.Add(2 + vertices.Count);

        //第二个三角面
        triangles.Add(2 + vertices.Count);
        triangles.Add(1 + vertices.Count);
        triangles.Add(0 + vertices.Count);


        //添加4个点
        vertices.Add(new Vector3(0 + x, 0 + y, 0 + z));
        vertices.Add(new Vector3(0 + x, 0 + y, 1 + z));
        vertices.Add(new Vector3(0 + x, 1 + y, 1 + z));
        vertices.Add(new Vector3(0 + x, 1 + y, 0 + z));

        //添加UV坐标点，跟上面4个点循环的顺序一致
        uv.Add(new Vector2(block.textureFrontX * textureOffset, block.textureFrontY * textureOffset) + new Vector2(shrinkSize, shrinkSize));
        uv.Add(new Vector2(block.textureFrontX * textureOffset + textureOffset, block.textureFrontY * textureOffset) + new Vector2(-shrinkSize, shrinkSize));
        uv.Add(new Vector2(block.textureFrontX * textureOffset + textureOffset, block.textureFrontY * textureOffset + textureOffset) + new Vector2(-shrinkSize, -shrinkSize));
        uv.Add(new Vector2(block.textureFrontX * textureOffset, block.textureFrontY * textureOffset + textureOffset) + new Vector2(shrinkSize, -shrinkSize));
    }

    //背面
    void AddBackFace(int x, int y, int z, Block block)
    {
        //第一个三角面
        triangles.Add(0 + vertices.Count);
        triangles.Add(3 + vertices.Count);
        triangles.Add(2 + vertices.Count);

        //第二个三角面
        triangles.Add(2 + vertices.Count);
        triangles.Add(1 + vertices.Count);
        triangles.Add(0 + vertices.Count);


        //添加4个点
        vertices.Add(new Vector3(-1 + x, 0 + y, 1 + z));
        vertices.Add(new Vector3(-1 + x, 0 + y, 0 + z));
        vertices.Add(new Vector3(-1 + x, 1 + y, 0 + z));
        vertices.Add(new Vector3(-1 + x, 1 + y, 1 + z));

        //添加UV坐标点，跟上面4个点循环的顺序一致
        uv.Add(new Vector2(block.textureBackX * textureOffset, block.textureBackY * textureOffset) + new Vector2(shrinkSize, shrinkSize));
        uv.Add(new Vector2(block.textureBackX * textureOffset + textureOffset, block.textureBackY * textureOffset) + new Vector2(-shrinkSize, shrinkSize));
        uv.Add(new Vector2(block.textureBackX * textureOffset + textureOffset, block.textureBackY * textureOffset + textureOffset) + new Vector2(-shrinkSize, -shrinkSize));
        uv.Add(new Vector2(block.textureBackX * textureOffset, block.textureBackY * textureOffset + textureOffset) + new Vector2(shrinkSize, -shrinkSize));
    }

    //右面
    void AddRightFace(int x, int y, int z, Block block)
    {
        //第一个三角面
        triangles.Add(0 + vertices.Count);
        triangles.Add(3 + vertices.Count);
        triangles.Add(2 + vertices.Count);

        //第二个三角面
        triangles.Add(2 + vertices.Count);
        triangles.Add(1 + vertices.Count);
        triangles.Add(0 + vertices.Count);


        //添加4个点
        vertices.Add(new Vector3(0 + x, 0 + y, 1 + z));
        vertices.Add(new Vector3(-1 + x, 0 + y, 1 + z));
        vertices.Add(new Vector3(-1 + x, 1 + y, 1 + z));
        vertices.Add(new Vector3(0 + x, 1 + y, 1 + z));

        //添加UV坐标点，跟上面4个点循环的顺序一致
        uv.Add(new Vector2(block.textureRightX * textureOffset, block.textureRightY * textureOffset) + new Vector2(shrinkSize, shrinkSize));
        uv.Add(new Vector2(block.textureRightX * textureOffset + textureOffset, block.textureRightY * textureOffset) + new Vector2(-shrinkSize, shrinkSize));
        uv.Add(new Vector2(block.textureRightX * textureOffset + textureOffset, block.textureRightY * textureOffset + textureOffset) + new Vector2(-shrinkSize, -shrinkSize));
        uv.Add(new Vector2(block.textureRightX * textureOffset, block.textureRightY * textureOffset + textureOffset) + new Vector2(shrinkSize, -shrinkSize));
    }

    //左面
    void AddLeftFace(int x, int y, int z, Block block)
    {
        //第一个三角面
        triangles.Add(0 + vertices.Count);
        triangles.Add(3 + vertices.Count);
        triangles.Add(2 + vertices.Count);

        //第二个三角面
        triangles.Add(2 + vertices.Count);
        triangles.Add(1 + vertices.Count);
        triangles.Add(0 + vertices.Count);


        //添加4个点
        vertices.Add(new Vector3(-1 + x, 0 + y, 0 + z));
        vertices.Add(new Vector3(0 + x, 0 + y, 0 + z));
        vertices.Add(new Vector3(0 + x, 1 + y, 0 + z));
        vertices.Add(new Vector3(-1 + x, 1 + y, 0 + z));

        //添加UV坐标点，跟上面4个点循环的顺序一致
        uv.Add(new Vector2(block.textureLeftX * textureOffset, block.textureLeftY * textureOffset) + new Vector2(shrinkSize, shrinkSize));
        uv.Add(new Vector2(block.textureLeftX * textureOffset + textureOffset, block.textureLeftY * textureOffset) + new Vector2(-shrinkSize, shrinkSize));
        uv.Add(new Vector2(block.textureLeftX * textureOffset + textureOffset, block.textureLeftY * textureOffset + textureOffset) + new Vector2(-shrinkSize, -shrinkSize));
        uv.Add(new Vector2(block.textureLeftX * textureOffset, block.textureLeftY * textureOffset + textureOffset) + new Vector2(shrinkSize, -shrinkSize));
    }

    //上面
    void AddTopFace(int x, int y, int z, Block block)
    {


        //第一个三角面
        triangles.Add(1 + vertices.Count);
        triangles.Add(0 + vertices.Count);
        triangles.Add(3 + vertices.Count);

        //第二个三角面
        triangles.Add(3 + vertices.Count);
        triangles.Add(2 + vertices.Count);
        triangles.Add(1 + vertices.Count);


        //添加4个点
        vertices.Add(new Vector3(0 + x, 1 + y, 0 + z));
        vertices.Add(new Vector3(0 + x, 1 + y, 1 + z));
        vertices.Add(new Vector3(-1 + x, 1 + y, 1 + z));
        vertices.Add(new Vector3(-1 + x, 1 + y, 0 + z));

        //添加UV坐标点，跟上面4个点循环的顺序一致
        uv.Add(new Vector2(block.textureTopX * textureOffset, block.textureTopY * textureOffset) + new Vector2(shrinkSize, shrinkSize));
        uv.Add(new Vector2(block.textureTopX * textureOffset + textureOffset, block.textureTopY * textureOffset) + new Vector2(-shrinkSize, shrinkSize));
        uv.Add(new Vector2(block.textureTopX * textureOffset + textureOffset, block.textureTopY * textureOffset + textureOffset) + new Vector2(-shrinkSize, -shrinkSize));
        uv.Add(new Vector2(block.textureTopX * textureOffset, block.textureTopY * textureOffset + textureOffset) + new Vector2(shrinkSize, -shrinkSize));


    }

    //下面
    void AddBottomFace(int x, int y, int z, Block block)
    {
        //第一个三角面
        triangles.Add(1 + vertices.Count);
        triangles.Add(0 + vertices.Count);
        triangles.Add(3 + vertices.Count);

        //第二个三角面
        triangles.Add(3 + vertices.Count);
        triangles.Add(2 + vertices.Count);
        triangles.Add(1 + vertices.Count);


        //添加4个点
        vertices.Add(new Vector3(-1 + x, 0 + y, 0 + z));
        vertices.Add(new Vector3(-1 + x, 0 + y, 1 + z));
        vertices.Add(new Vector3(0 + x, 0 + y, 1 + z));
        vertices.Add(new Vector3(0 + x, 0 + y, 0 + z));

        //添加UV坐标点，跟上面4个点循环的顺序一致
        uv.Add(new Vector2(block.textureBottomX * textureOffset, block.textureBottomY * textureOffset) + new Vector2(shrinkSize, shrinkSize));
        uv.Add(new Vector2(block.textureBottomX * textureOffset + textureOffset, block.textureBottomY * textureOffset) + new Vector2(-shrinkSize, shrinkSize));
        uv.Add(new Vector2(block.textureBottomX * textureOffset + textureOffset, block.textureBottomY * textureOffset + textureOffset) + new Vector2(-shrinkSize, -shrinkSize));
        uv.Add(new Vector2(block.textureBottomX * textureOffset, block.textureBottomY * textureOffset + textureOffset) + new Vector2(shrinkSize, -shrinkSize));
    }
}