using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SliderInfo))]
public class FreqSelector : MonoBehaviour {

    [Serializable]
    public class FequencySelectedEvent : UnityEvent<float> {}

    public FequencySelectedEvent FrequencySelected;

    private float _currentFrequency;

    public float currentFrequency
    {
        get
        {
            return _currentFrequency;
        }
        set
        {
            if (_currentFrequency != value)
            {
                Debug.Log($"{_currentFrequency}");
                _currentFrequency = value;
                FrequencySelected?.Invoke(_currentFrequency);
            }
        } 
    }


    private void Update()
    {
        currentFrequency = GetComponent<SliderInfo>().value;
    }



}
