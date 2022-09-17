﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 方块的方向
/// </summary>
public enum BlockDirection : int
{
    Front = 0,
    Back = 1,
    Left = 2,
    Right = 3,
    Top = 4,
    Bottom = 5
}

/// <summary>
/// 方块对象，存储方块的所有信息
/// </summary>
public class Block
{
    //方块的ID
    public int id;

    //方块的名字
    public string name;

    //方块的图标，并不会采用在游戏中动态生成的做法
    public Texture icon;

    //方向（指的是前面所面朝的方向）
    public BlockDirection direction = BlockDirection.Front;

    //前面贴图的坐标
    public int textureFrontX;
    public int textureFrontY;

    //后面贴图的坐标
    public int textureBackX;
    public int textureBackY;

    //右面贴图的坐标
    public int textureRightX;
    public int textureRightY;

    //左面贴图的坐标
    public int textureLeftX;
    public int textureLeftY;

    //上面贴图的坐标
    public int textureTopX;
    public int textureTopY;

    //下面贴图的坐标
    public int textureBottomX;
    public int textureBottomY;

    //都是A面的方块
    public Block(int id, string name, int textureX, int textureY)
        : this(id, name, textureX, textureY, textureX, textureY, textureX, textureY, textureX, textureY)
    {
    }

    //上面是A，其他面是B的方块
    public Block(int id, string name, int textureX, int textureY, int textureTopX, int textureTopY)
        : this(id, name, textureX, textureY, textureX, textureY, textureX, textureY, textureX, textureY, textureTopX, textureTopY, textureX, textureY)
    {
    }

    //上面是A，下面是B，其他面是C的方块
    public Block(int id, string name, int textureX, int textureY, int textureTopX, int textureTopY, int textureBottomX, int textureBottomY)
        : this(id, name, textureX, textureY, textureX, textureY, textureX, textureY, textureX, textureY, textureTopX, textureTopY, textureBottomX, textureBottomY)
    {
    }

    //上面是A，下面是B，前面是C，其他面是D的方块
    public Block(int id, string name, int textureFrontX, int textureFrontY, int textureX, int textureY, int textureTopX, int textureTopY, int textureBottomX, int textureBottomY)
        : this(id, name, textureFrontX, textureFrontY, textureX, textureY, textureX, textureY, textureX, textureY, textureTopX, textureTopY, textureBottomX, textureBottomY)
    {
    }

    //上下左右前后面都不一样的方块
    public Block(int id, string name, int textureFrontX, int textureFrontY, int textureBackX, int textureBackY, int textureRightX, int textureRightY,
        int textureLeftX, int textureLeftY, int textureTopX, int textureTopY, int textureBottomX, int textureBottomY)
    {
        this.id = id;
        this.name = name;

        this.textureFrontX = textureFrontX;
        this.textureFrontY = textureFrontY;

        this.textureBackX = textureBackX;
        this.textureBackY = textureBackY;

        this.textureRightX = textureRightX;
        this.textureRightY = textureRightY;

        this.textureLeftX = textureLeftX;
        this.textureLeftY = textureLeftY;

        this.textureTopX = textureTopX;
        this.textureTopY = textureTopY;

        this.textureBottomX = textureBottomX;
        this.textureBottomY = textureBottomY;
    }
}
