using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMeasurementPoint : MonoBehaviour
{

    public GameObject prefab;
    public TMPro.TextMeshProUGUI winText;
    public GameObject winTextBack;

    public void AddPoint(float position, float power) {
        GameObject instance = Instantiate(prefab);
        instance.transform.SetParent(gameObject.transform);

        RectTransform rectTransform = instance.transform as RectTransform;

        rectTransform.pivot = Vector2.zero;
        rectTransform.localPosition = Vector2.zero;
        rectTransform.anchorMin = new Vector2(1 - position, power);
        rectTransform.anchorMax = new Vector2(1 - position, power);

        if (power > 0.9f)
        {
            winText.gameObject.SetActive(true);
            winTextBack.SetActive(true);
            winText.text = $"Qubit frecuency is {4.960 + 0.040 * position:G6} GHz";
        }
    }

    [ContextMenu("asd")]
    public void Test()
    {
        AddPoint(0.1f, 0.1f);
        AddPoint(0.2f, 0.1f);
        AddPoint(0.3f, 0.5f);
        AddPoint(0.4f, 1.0f);
        AddPoint(0.5f, 0.5f);
        AddPoint(0.6f, 0.1f);
        AddPoint(0.7f, 0.1f);
    }
}
