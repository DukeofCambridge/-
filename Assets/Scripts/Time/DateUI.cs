using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DateUI : MonoBehaviour
{
    private DateManager dm;
    public RectTransform dayNightImage;
    public RectTransform clockParent;
    public Image seasonImage;
    public TextMeshProUGUI dateText;
    public TextMeshProUGUI timeText;

    public Sprite[] seasonSprites;

    private List<GameObject> clockBlocks = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < clockParent.childCount; i++)
        {
            clockBlocks.Add(clockParent.GetChild(i).gameObject);
            clockParent.GetChild(i).gameObject.SetActive(false);
        }
        dm = GameObject.Find("DateManager").GetComponent<DateManager>();
    }
    
    private void OnEnable()
    {
        EventHandler.onIncrementHour += OnGameHourEvent;
        EventHandler.onIncrementDay += OnGameDateEvent;
    }

    private void OnDisable()
    {
        EventHandler.onIncrementHour -= OnGameHourEvent;
        EventHandler.onIncrementDay -= OnGameDateEvent;
    }
    /// <summary>
    /// ÿСʱˢ��UI
    /// </summary>
    /// <param name="hour"></param>
    private void OnGameHourEvent(int hour)
    {
        //Debug.Log("��ǰʱ��Ϊ"+ hour);
        timeText.text = dm.date.hours[hour];
        SwitchHourImage(hour);
        DayNightImageRotate(hour);
    }
    /// <summary>
    /// ÿ��ˢ��UI
    /// </summary>
    /// <param name="day"></param>
    /// <param name="month"></param>
    private void OnGameDateEvent(int day, int month)
    {
        string period = dm.date.months[month];
        int p = day / 10;
        switch (p)
        {
            case 0: period += "��Ѯ";break;
            case 1: period += "��Ѯ";break;
            case 2: period += "��Ѯ";break;
        }
        int season = month / 3;

        dateText.text = "����Ԫ��" + " " + period;
        //���ü���ͼ��
        seasonImage.sprite = seasonSprites[season];
    }

    /// <summary>
    /// ����Сʱ�л�ʱ�����ʾ
    /// </summary>
    /// <param name="hour"></param>
    private void SwitchHourImage(int hour)
    {
        int index = hour / 4;

        if (index == 0)
        {
            foreach (var item in clockBlocks)
            {
                item.SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < clockBlocks.Count; i++)
            {
                if (i < index + 1)
                    clockBlocks[i].SetActive(true);
                else
                    clockBlocks[i].SetActive(false);
            }
        }
    }
    /// <summary>
    /// ��ҹ������ת
    /// </summary>
    /// <param name="hour"></param>
    private void DayNightImageRotate(int hour)
    {
        var target = new Vector3(0, 0, hour * 15 - 90);
        dayNightImage.DORotate(target, 1f, RotateMode.Fast);
    }
}
