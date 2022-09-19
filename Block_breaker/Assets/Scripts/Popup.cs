using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    [SerializeField] Button button_1;
    [SerializeField] Button button_2;
    [SerializeField] Text text_button_1;
    [SerializeField] Text text_button_2; 
    [SerializeField] Text text_popup;

    public void Init(Transform canvas, string popup,string btn1_text,string btn2_text, Action action  )
    {
        text_popup.text = popup;
        text_button_1.text = btn1_text;
        text_button_2.text = btn2_text;
        transform.SetParent(canvas);
        transform.localScale = Vector3.one;
        GetComponent<RectTransform>().offsetMin = Vector2.zero; 
        GetComponent<RectTransform>().offsetMax = Vector2.zero;
        button_1.onClick.AddListener(() =>
        {
            GameObject.Destroy(this.gameObject);
        });
        button_2.onClick.AddListener(() =>
        {
            action();
            GameObject.Destroy(this.gameObject);
        });
    }
 
}
