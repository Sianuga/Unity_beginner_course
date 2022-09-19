using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Close_game : MonoBehaviour
{

    void Start()
    {
        Action action = () =>
        {
            Application.Quit();
        };
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            Popup popup = UIController.Instance.CreatePopup();
            popup.Init(UIController.Instance.MainCanvas, "Do you really want to quit?", "Yes", "No ", action);
        });
    }

 
 
}
