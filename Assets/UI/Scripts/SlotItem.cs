using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SlotItem", order = 1)]
public class SlotItem : ScriptableObject
{
    //定义枚举类型存放物体的种类
    public enum SlotItemType
    {
        Leaves,
        Stump,
        Stone,
        Dirt,
        Sand,
        Grass,
        Coal,
    }

    //该数据类型用来存放物体的图片以及物体的种类

    public Sprite Image;
    public SlotItemType Type;

}