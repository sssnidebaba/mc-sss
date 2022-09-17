using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{

    //���߲۵�id
    public int id;

    public HotbarController hotbarController;

    //���߲�
    public Image slotFrameImage;

    //���ڹ��߲۵���Ʒ
    public Image itemImage;

    //���߲�δ��ѡ��ʱ��ͼƬ
    public Sprite slotFrameSprite;

    //���߲۱�ѡ��ʱ��ͼƬ
    public Sprite selectedSlotFrameSprite;

    
    public SlotItem item;

    //���ù��߲۱�ѡ��ʱ���ã��ù��߲�ʹ�ñ�ѡ��ʱ��ͼƬ
    public void Select()
    {
        this.slotFrameImage.sprite = selectedSlotFrameSprite;
    }

    //���ù��߲�δ��ѡ��ʱ���ã��ù��߲�ʹ��δ��ѡ��ʱ��ͼƬ
    public void Deselect()
    {
        this.slotFrameImage.sprite = slotFrameSprite;
    }

    //��ʼ����ƷͼƬ
    public void Initialize()
    {
        this.itemImage.sprite = this.item.Image;
    }

    //�����߲۱����ʱ���ã�����ǰ���߲�����Ϊѡ��
    public void SelectItem()
    {
        HotbarController.instanc.SelectItem(id);
    }
}
