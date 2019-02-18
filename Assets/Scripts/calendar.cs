using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Calendar : MonoBehaviour
{
    [SerializeField] Button today;          //返回今天
    [SerializeField] Button previous;       //上一个月
    [SerializeField] Button next;           //下一个月
 
    private const int numOfbuttons = 37;    //表示日期所用37个按钮

    private Button[] buttons;
    private int month;                      
    private int year;
    private int numOfdays;                  //每月天数
    private DateTime dateValue;             //DateTime型临时变量
    private int dayOfweek;                  //星期几

    void Awake()
    {
        buttons = new Button[numOfbuttons];
        for (int i = 0; i < numOfbuttons; i++)
        {
            Button _buttons = GameObject.Find("Button_" + i).GetComponent<Button>();
            buttons[i] = _buttons;
        }

        ButtonClear();
        year = System.DateTime.Today.Year;  //取得今天的年份
        month = System.DateTime.Today.Month;//取得今天的月份
        SetDate();
        
        //显示今天的日期
        today.GetComponentInChildren<Text>().text = System.DateTime.Today.ToString("yyyy-MM-dd");
    }

    //设定日历显示
    private void SetDate()
    {
        numOfdays = System.DateTime.DaysInMonth(year, month);
        dateValue = new DateTime(year, month, 1);
        dayOfweek = (int)dateValue.DayOfWeek;

        int index = 1;
        for (int i = 0; i < numOfdays; i++)
        {
            buttons[dayOfweek + i].GetComponentInChildren<Text>().text = index.ToString();
            index++;
        }
    }

    //清空日历文字
    private void ButtonClear()
    {
        for (int i = 0; i < numOfbuttons; i++)
        {
            buttons[i].GetComponentInChildren<Text>().text = "";
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //按钮事件
        today.onClick.AddListener(TodayOnClick);
        previous.onClick.AddListener(PreOnClick);
        next.onClick.AddListener(NextOnClick);
    }

    //下一个月
    private void NextOnClick()
    {
        ButtonClear();
        if (month == 12)
        {
            year += 1;
            month = 1;
        }
        else
        {
            month += 1;
        }
        SetDate();
        today.GetComponentInChildren<Text>().text = dateValue.ToString("yyyy-MM");
    }

    //上一个月
    private void PreOnClick()
    {
        ButtonClear();
        if(month == 1)
        {
            year -= 1;
            month = 12;
        }
        else
        {
            month -= 1;
        }      
        SetDate();
        today.GetComponentInChildren<Text>().text = dateValue.ToString("yyyy-MM");
    }

    //返回今天
    private void TodayOnClick()
    {
        ButtonClear();
        year = System.DateTime.Today.Year;
        month = System.DateTime.Today.Month;
        SetDate();
        today.GetComponentInChildren<Text>().text = System.DateTime.Today.ToString("yyyy-MM-dd");
    }
}
