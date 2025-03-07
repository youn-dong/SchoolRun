using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conditions : MonoBehaviour
{
    public float curValue;
    public float maxValue;
    public float startValue;
    public float passiveValue;
    public Image uiBar;

    private void Start()
    {
        curValue = startValue;
    }
    private void Update()
    {
        uiBar.fillAmount = GetPercentage();
    }

    public void Add(float  value)
    {
        curValue = Mathf.Min(curValue + value, maxValue);
    }
    public void SubStract(float value)
    {
        curValue = Mathf.Max(curValue - value, 0);
    }
    public float GetPercentage()
    {
      return  curValue / maxValue;
    }
}
