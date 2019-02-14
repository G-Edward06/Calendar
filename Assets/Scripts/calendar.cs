using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class calendar : MonoBehaviour
{
    [SerializeField] Button today;
    [SerializeField] Button previous;
    [SerializeField] Button next;
 
    private const int numOfbuttons = 37;

    private Button[] buttons;
    private int month;
    private int year;
    private int numOfdays;
    private DateTime dateValue;
    private int dayOfweek;

    // ==============================================================
    void Awake()
    {
        buttons = new Button[numOfbuttons];

        buttonClear();
        year = System.DateTime.Today.Year;
        month = System.DateTime.Today.Month;
        SetDate();

        today.GetComponentInChildren<Text>().text = System.DateTime.Today.ToString("yyyy-MM-dd");
    }

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

    private void buttonClear()
    {
        for (int i = 0; i < numOfbuttons; i++)
        {
            Button _buttons = GameObject.Find("Button_" + i).GetComponent<Button>();
            buttons[i] = _buttons;
            buttons[i].GetComponentInChildren<Text>().text = "";
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        today.onClick.AddListener(todayOnClick);
        previous.onClick.AddListener(preOnClick);
        next.onClick.AddListener(nextOnClick);
    }

    private void nextOnClick()
    {
        buttonClear();
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

    private void preOnClick()
    {
        buttonClear();
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

    private void todayOnClick()
    {
        buttonClear();
        year = System.DateTime.Today.Year;
        month = System.DateTime.Today.Month;
        SetDate();
        today.GetComponentInChildren<Text>().text = System.DateTime.Today.ToString("yyyy-MM-dd");
    }
}
