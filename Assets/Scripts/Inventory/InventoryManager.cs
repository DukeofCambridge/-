using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;

public class InventoryManager : MonoBehaviour
{
    static InventoryManager instance;

    public ������Ʒ mybag;
    public GameObject slotGrid;
    public Slot slotPrefab;
    public Text iteminfo;
    public Image Img;

    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
    }

    private void OnEnable()
    {
        RefreshItem(1);
        instance.iteminfo.text = "";
    }

    public static void UpdateItemInfo(string itemdesciption,Image itemImage)
    {
        instance.iteminfo.text = itemdesciption;
        instance.Img = itemImage;
        
    }
    public static void CreateNewItem(��Ʒ item)
    {
        Slot newItem=Instantiate(instance.slotPrefab,instance.slotGrid.transform.position,Quaternion.identity);
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
        newItem.slotItem = item;
        newItem.slotImage.sprite = item.��ƷͼƬ;
        newItem.slotImage.transform.localScale=new Vector3(1,1,1);
        newItem.slotNumber.text = item.��ǰ����.ToString();
    }

    public static void RefreshItem(int index)
    {
        for (int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
        }

        //for (int i = 0; i < instance.mybag.�����Ʒ.Count; i++)
        //{
        //    CreateNewItem(instance.mybag.�����Ʒ[i]);
        //}

       
        int count = instance.mybag.pagenow.Count;
        int fullcount = count / 15;
        List<��Ʒ> list = instance.mybag.pagenow;

        if (index <= fullcount)
        {
            for (int i = 15 * (index - 1); i < 15 * index; i++)
            {
                CreateNewItem(instance.mybag.pagenow[i]);
            }
        }
        else
        {
            for (int i = 15 * (index - 1); i < count; i++)
            {
                CreateNewItem(instance.mybag.pagenow[i]);
            }
        }
    }
    public static void Operate_add(string ��Ʒ����)//������Ʒ
    {
        ��Ʒ item = Resources.Load<��Ʒ>("item/" + ��Ʒ����);
        int index = Exist(Resources.Load<������Ʒ>("mybag"), item.��Ʒ����);
        if (index == -1)
        {
            Resources.Load<������Ʒ>("mybag").�����Ʒ.Add(item);
            CreateNewItem(item);
        }
        else
        {
            Resources.Load<������Ʒ>("mybag").�����Ʒ[index].��ǰ���� += 1;
        }
        RefreshItem(1);
    }

    public static void Operate_remove(string ��Ʒ����)
    {
        ��Ʒ item = Resources.Load<��Ʒ>("item/" + ��Ʒ����);
        int index = Exist(Resources.Load<������Ʒ>("mybag"), item.��Ʒ����);
        if (index == -1)
        {
            Debug.Log("������");
            //��ʾ������
        }
        else
        {
            Resources.Load<������Ʒ>("mybag").�����Ʒ[index].��ǰ���� -= 1;
            if (Resources.Load<������Ʒ>("mybag").�����Ʒ[index].��ǰ���� == 0)
            {
                Resources.Load<������Ʒ>("mybag").�����Ʒ[index].��ǰ���� = 1;
                Resources.Load<������Ʒ>("mybag").�����Ʒ.RemoveAt(index);
            }
        }
        RefreshItem(1);
    }



    static int Exist(������Ʒ itemLoad, string ��Ʒ����)
    {
        for (int i = 0; i < itemLoad.�����Ʒ.Count; i++)
        {
            if (itemLoad.�����Ʒ[i].��Ʒ���� == ��Ʒ����)
            {
                return i;
            }
            else continue;
        }
        return -1;
    }
}
