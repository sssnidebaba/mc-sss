using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotbarController : MonoBehaviour
{
    //定义一个HotbarController类型来存放数据
    public static HotbarController instanc;

    //定义一个工具槽的父对象
    public Transform slotParent;

    //定义物体对象数组
    private SlotItem[] items;


    private int _selectedItemIndex;
    
    //定义工具槽数组
    private Slot[] _slots;

   
    private void Awake()
    {
        if (instanc == null)
        {
            instanc = this;
        }
    }

    //选中工具槽时调用，先取消所有选中，再选中指定工具槽
    public void SelectItem(int index)
    {
        DeselectAll();
        _selectedItemIndex = index;
        _slots[_selectedItemIndex].Select();
    }

    //取消所有选中
    public void DeselectAll()
    {
        foreach (var slot in _slots)
        {
            slot.Deselect();
        }
    }

    private void Start()
    {
        Initialize();
    }

    //初始化
    public void Initialize()
    {
        //通过所有工具槽的父对象获取工具槽数组
        _slots = slotParent.GetComponentsInChildren<Slot>();

        var slotItems = new List<SlotItem>();

        for (int i = 0; i < _slots.Length; i++)
        {
            
            var slot = _slots[i];

            //对每个工具槽初始化
            slot.Initialize();

            //存入一个物体对象数组
            slotItems.Add(slot.item);

        }

        //初始选中第一个工具槽
        SelectItem(_selectedItemIndex);

        //返回物体对象数组
        this.items = slotItems.ToArray();

    }

}