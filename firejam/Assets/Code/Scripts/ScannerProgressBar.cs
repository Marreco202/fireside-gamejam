using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class ScannerProgressBar : MonoBehaviour
{
    public static Slider slider;
    public static int progress = 0;
    public static int maxValue = 100;
    public static int minValue = 0;

    public static ScannerProgressBar instance;

    private ScannerProgressBar() { }

    private void Start()
    {
        SetMaxProgressStatus();
        SeMinProgressStatus();
        SetProgress();
    }

    public static ScannerProgressBar getInstance()
    {
        if (instance == null) 
        {
            instance = new ScannerProgressBar();
        }
        return instance;
    }

    public void SetMaxProgressStatus()
    {
        slider.maxValue = maxValue;
        slider.value = progress;
    }

    public void SeMinProgressStatus()
    {
        slider.minValue = minValue;
        slider.value = progress;
    }
    
    public void SetProgress()
    {
        slider.value = progress;
    }
}
