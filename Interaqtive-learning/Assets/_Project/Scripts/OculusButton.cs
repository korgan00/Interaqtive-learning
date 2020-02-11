using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OculusButton : MonoBehaviour
{

    public UnityEvent OnAction;

    [ContextMenu("asd")]
    public void Action() {
        OnAction?.Invoke();
    }


#if UNITY_EDITOR
    public IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.3f);
            Action();
        }
    }
#endif

}
