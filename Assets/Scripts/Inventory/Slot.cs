using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    static public Slot instance;
    public ��Ʒ slotItem;
    public Image slotImage;
    public Text slotNumber;

    public void ItemOnClick()
    {
        InventoryManager.UpdateItemInfo(slotItem.��Ʒ����,slotImage);
    }

    public static ��Ʒ Confirm()
    {
        return instance.slotItem;
    }
}
