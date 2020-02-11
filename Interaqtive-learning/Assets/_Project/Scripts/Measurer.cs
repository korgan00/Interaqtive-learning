using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(OculusButton))]
public class Measurer : MonoBehaviour {

    [Serializable]
    public class MeasurementDone : UnityEvent<float, float> { }

    public MeasurementDone OnMeasurementDone;


    [Range(0, 1)]
    public float shift = 0.1f;
    private float _frequency = 0f;
    public float threshold = 0.5f;

    public void SetSelectedFreq(float value)
    {
        _frequency = value;
    }

    private void Start()
    {
        shift = UnityEngine.Random.Range(0.1f, 0.9f);
        GetComponent<OculusButton>().OnAction.AddListener(() => {
            OnMeasurementDone.Invoke(_frequency, GetPowerAt(_frequency));
        });
    }

    public float GetPowerAt(float freq)
    {
        // https://qiskit.org/textbook/ch-quantum-hardware/calibrating-qubits-openpulse.html#1.-Finding-the-qubit-frequency-using-a-frequency-sweep-
        // To get the value of the peak frequency, we will fit the values to a resonance response curve, which is typically a Lorentzian shape.
        // https://lmfit.github.io/lmfit-py/builtin_models.html#lmfit.models.LorentzianModel
        // TODO: We use an aproximation. This should be reviewed by a researcher

        return 1/(Mathf.PI * 0.32f) * 1/(Mathf.Pow((freq - shift) * 20.0f, 2.0f) + 1);
    }

    public float GetRabiValueAt(float time)
    {
        // TODO: We use an aproximation of the sin curve. This should be reviewed by a researcher
        // https://qiskit.org/textbook/ch-quantum-hardware/calibrating-qubits-openpulse.html#A.-Calibrating-$\pi$-pulses-using-a-Rabi-experiment-
        return 3.5f * Mathf.Sin(time * 6.0f);
    }

}
