using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item",menuName ="Inventory/New Item")]
public class Item : ScriptableObject
{
    public string ItemName;//��Ʒ��
    public Sprite ItemImg;//ͼƬ
    [TextArea]
    public string ItemDescription;//����
    public Category ItemCategory;//����
    public string ItemMeasure;//������λ
    public int ItemPrice;//����
    public int Hold;//��ǰ����
    public enum Category
    {
        food,menu,normalitem,forsale, others
    }
}
