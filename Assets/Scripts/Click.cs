using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Click : MonoBehaviour
{
    public Action OnClick;
    public static Click instance;

    private void Awake()
    {
        instance = this;
    }

    public void Clicked()
    {
        OnClick?.Invoke();
    }
}
