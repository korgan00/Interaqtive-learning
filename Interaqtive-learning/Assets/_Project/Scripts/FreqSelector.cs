using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FreqSelector : MonoBehaviour {

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
                _currentFrequency = value;
                FrequencySelected?.Invoke(_currentFrequency);
            }
        } 
    }


}
