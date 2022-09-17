using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SlotItem", order = 1)]
public class SlotItem : ScriptableObject
{
    //����ö�����ʹ�����������
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

    //����������������������ͼƬ�Լ����������

    public Sprite Image;
    public SlotItemType Type;

}