using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class calendar : MonoBehaviour
{
    [SerializeField] Button today;

    private Button[] days;
    private int numOfdays = 31; // Number of building tier buttons;

    // ==============================================================
    void Awake()
    {
        days = new Button[numOfdays];
        int index = 1;

        for (int i = 0; i < numOfdays; i++)
        {
            Button _days = GameObject.Find("button_" + index).GetComponent<Button>();
            days[i] = _days;
            days[i].GetComponentInChildren<Text>().text = index.ToString();
            index++;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        today.GetComponentInChildren<Text>().text = System.DateTime.Today.ToLongDateString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
