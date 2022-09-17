using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{

    //工具槽的id
    public int id;

    public HotbarController hotbarController;

    //工具槽
    public Image slotFrameImage;

    //放在工具槽的物品
    public Image itemImage;

    //工具槽未被选中时的图片
    public Sprite slotFrameSprite;

    //工具槽被选中时的图片
    public Sprite selectedSlotFrameSprite;

    
    public SlotItem item;

    //当该工具槽被选中时调用，让工具槽使用被选中时的图片
    public void Select()
    {
        this.slotFrameImage.sprite = selectedSlotFrameSprite;
    }

    //当该工具槽未被选中时调用，让工具槽使用未被选中时的图片
    public void Deselect()
    {
        this.slotFrameImage.sprite = slotFrameSprite;
    }

    //初始化物品图片
    public void Initialize()
    {
        this.itemImage.sprite = this.item.Image;
    }

    //当工具槽被点击时调用，将当前工具槽设置为选中
    public void SelectItem()
    {
        HotbarController.instanc.SelectItem(id);
    }
}
