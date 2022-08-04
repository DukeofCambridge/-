using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingUI : MonoBehaviour
{
    private GameObject bag;                                     //opened bag UI
    private GameObject bagBar;                                  //closed bag UI
    public ������Ʒ mybag;
    public Slot slotPrefab;                                     //item template
    private List<��Ʒ> itemList = new List<��Ʒ>();             //food in bag
    private List<��Ʒ> selectedItemList = new List<��Ʒ>();     //selected food for cooking

    void Start()
    {
        bag = GameObject.Find("bag");
        bagBar = GameObject.Find("bagBar");
        itemList = mybag.�����Ʒ;
        //inventoryManager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
        CloseBag();
    }

    public void RefreshBagUI()
    {

    }

    public void RefreshSelectedUI()
    {

    }

    public void RemoveItemToBag(��Ʒ item)
    {
        if (selectedItemList.Contains(item))
        {
            selectedItemList.Remove(item);
            InventoryManager.Operate_add(item.��Ʒ����);
        }
        else
        {
            Debug.Log("error:selected item list does not contains" + item);
        }

    }

    public void RemoveItemToSelected(��Ʒ item)
    {
        if (itemList.Contains(item))
        {
            selectedItemList.Add(item);
            InventoryManager.Operate_remove(item.��Ʒ����);
        }
        else
        {
            Debug.Log("error:item list does not contains" + item);
        }
    }

    public void OnGridButtinClicked(int id)
    {
        ��Ʒ item = itemList[id - 1];
        if(!selectedItemList.Contains(item))
        {
            RemoveItemToSelected(item);
        }
    }
    
    public void OnPlusButtonClicked(int id)
    {
        if (id > selectedItemList.Count)
        {
            OpenBag();
        }// grid without item
        else
        {
            ��Ʒ item = itemList[id - 1];
            RemoveItemToBag(item);
        }// grid with item
    }
    public void OpenBag()
    {
        bag.SetActive(true);
        bagBar.SetActive(false);
    }

    public void CloseBag()
    {
        bag.SetActive(false);
        bagBar.SetActive(true);
    }
}
