using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoplogic : MonoBehaviour
{
    public static void Operate_Buy()//�Ҳ�ȷ�ϼ��������߼�
    {
        int k = Exist(Resources.Load<Shop>("shopbag"), Slot.Confirm().��Ʒ����);
        Resources.Load<Shop>("shopbag").shoplist[k].��ǰ���� -= 1;
        if(Resources.Load<Shop>("shopbag").shoplist[k].��ǰ����==0)
        {
            Resources.Load<Shop>("shopbag").shoplist[k].��ǰ���� = 1;
            Resources.Load<Shop>("shopbag").shoplist.RemoveAt(k);
        }
        //����.Operate_add(Slot.Confirm().��Ʒ����);
    }


    public static int Exist(Shop a, string b)//a ����  b ��Ʒ��
    {
        for (int i = 0; i < a.shoplist.Count; i++)
        {
            if (a.shoplist[i].��Ʒ���� == b)
            {
                return i;
            }
            else continue;
        }
        return -1;
    }
}

