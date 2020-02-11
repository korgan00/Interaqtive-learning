using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Measurer : MonoBehaviour {


    public float frequency = 4.2f;
    public float threshold = 0.5f;

    public float GetPowerAt(float freq)
    {
        // https://qiskit.org/textbook/ch-quantum-hardware/calibrating-qubits-openpulse.html#1.-Finding-the-qubit-frequency-using-a-frequency-sweep-
        // To get the value of the peak frequency, we will fit the values to a resonance response curve, which is typically a Lorentzian shape.
        // https://lmfit.github.io/lmfit-py/builtin_models.html#lmfit.models.LorentzianModel
        // TODO: We use an aproximation. This should be reviewed by a researcher

        return 1/(Mathf.PI * 0.32) * 1/((freq*20)^2 + 1);
    }


}
