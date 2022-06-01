using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Calendar : MonoBehaviour
{
    private Button today;          //返回今天　「今日」へ
    private Button previous;       //上一个月　「前の月」へ
    private Button next;           //下一个月　「次の月」へ
 
    private const int numOfbuttons = 37;    //表示日期所用37个按钮　ボタン37個

    private Button[] buttons;
    private int month;                      
    private int year;
    private int numOfdays;                  //每月天数　当月の日数
    private DateTime dateValue;             //DateTime型临时变量　DataTimeを取得する変数
    private int dayOfweek;                  //星期几　曜日
    private Image bgImg;
    public Sprite[] BgSprites;
    void Awake()
    {
        today = transform.Find("today").GetComponentInChildren<Button>();
        previous = transform.Find("pre").GetComponentInChildren<Button>();
        next = transform.Find("next").GetComponentInChildren<Button>();
        bgImg = transform.Find("Panel").GetComponent<Image>();

        buttons = new Button[numOfbuttons];
        for (int i = 0; i < numOfbuttons; i++)
        {
            Button _buttons = GameObject.Find("Button_" + i).GetComponent<Button>();
            buttons[i] = _buttons;
        }

        ButtonClear();
        year = System.DateTime.Today.Year;  //取得今天的年份　「今日」の西暦年
        month = System.DateTime.Today.Month;//取得今天的月份　「今日」の月
        SetDate();
        
        //显示今天的日期　「今日」を表示
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
        
        // set background image
        bgImg.sprite = BgSprites[month-1];
    }

    //清空日历文字　ボタンのテキストを削除
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
        //按钮事件　ボタンイベント
        today.onClick.AddListener(TodayOnClick);
        previous.onClick.AddListener(PreOnClick);
        next.onClick.AddListener(NextOnClick);
    }

    //下一个月　「次の月へ」イベント
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

    //上一个月　「前の月へ」イベント
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

    //返回今天　「今日」へ戻るイベント
    private void TodayOnClick()
    {
        ButtonClear();
        year = System.DateTime.Today.Year;
        month = System.DateTime.Today.Month;
        SetDate();
        today.GetComponentInChildren<Text>().text = System.DateTime.Today.ToString("yyyy-MM-dd");
    }
}
