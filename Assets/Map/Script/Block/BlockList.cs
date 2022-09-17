using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 存储所有的Block对象的信息
/// </summary>
public class BlockList : MonoBehaviour
{
    public static Dictionary<int, Block> blocks = new Dictionary<int, Block>();

    public static bool startflag = true;

    void Awake()
    {


        if (startflag)
        {

            Block dirt = new Block(1, "Dirt", 2, 31);
            blocks.Add(dirt.id, dirt);

            Block grass = new Block(2, "Grass", 3, 31, 0, 31, 2, 31);
            blocks.Add(grass.id, grass);

            Block stone = new Block(3, "Stone", 6, 31);
            blocks.Add(stone.id, stone);

            Block coal = new Block(4, "Coal", 2, 29);
            blocks.Add(coal.id, coal);

            Block sand = new Block(5, "Sand", 2, 28);
            blocks.Add(sand.id, sand);

            Block stump = new Block(6, "Stump", 4, 30, 5, 30);
            blocks.Add(stump.id, stump);

            Block leaves = new Block(7, "Leaves", 4, 29);
            blocks.Add(leaves.id, leaves);
            startflag = false;

        }
    }

    public static Block GetBlock(int id)
    {
        return blocks.ContainsKey(id) ? blocks[id] : null;
    }
}
