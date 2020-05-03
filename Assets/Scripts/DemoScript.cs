using com.ozave.numbergenerator.generator;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DemoScript : MonoBehaviour
{

    [SerializeField]
    private NumberGenerator numberGenerator;

    [SerializeField]
    private Button button;

    [SerializeField]
    private TextMeshProUGUI numText;

    // Start is called before the first frame update
    void Start()
    {
        if(button != null)
            button.onClick.AddListener(HandleOnClick);
    }

    private void HandleOnClick()
    {
        UpdateText(numberGenerator?.Number ?? 0);
    }

    private void UpdateText(float value)
    {
        if(numText != null)
        {
            numText.text = "Number : " + Mathf.Floor(value).ToString();
        }
    }
}
