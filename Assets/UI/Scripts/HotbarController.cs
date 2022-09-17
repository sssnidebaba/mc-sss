using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotbarController : MonoBehaviour
{
    //����һ��HotbarController�������������
    public static HotbarController instanc;

    //����һ�����߲۵ĸ�����
    public Transform slotParent;

    //���������������
    private SlotItem[] items;


    private int _selectedItemIndex;
    
    //���幤�߲�����
    private Slot[] _slots;

   
    private void Awake()
    {
        if (instanc == null)
        {
            instanc = this;
        }
    }

    //ѡ�й��߲�ʱ���ã���ȡ������ѡ�У���ѡ��ָ�����߲�
    public void SelectItem(int index)
    {
        DeselectAll();
        _selectedItemIndex = index;
        _slots[_selectedItemIndex].Select();
    }

    //ȡ������ѡ��
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

    //��ʼ��
    public void Initialize()
    {
        //ͨ�����й��߲۵ĸ������ȡ���߲�����
        _slots = slotParent.GetComponentsInChildren<Slot>();

        var slotItems = new List<SlotItem>();

        for (int i = 0; i < _slots.Length; i++)
        {
            
            var slot = _slots[i];

            //��ÿ�����߲۳�ʼ��
            slot.Initialize();

            //����һ�������������
            slotItems.Add(slot.item);

        }

        //��ʼѡ�е�һ�����߲�
        SelectItem(_selectedItemIndex);

        //���������������
        this.items = slotItems.ToArray();

    }

}