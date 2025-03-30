using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PositiveNumberInputField : MonoBehaviour
{
    public InputField InputLength; 
    public InputField InputHeight;  
    public InputField InputWidth;   

    void Start()
    {
        if (InputLength != null)
            InputLength.onValueChange.AddListener(OnLengthChanged);
        
        if (InputHeight != null)
            InputHeight.onValueChange.AddListener(OnHeightChanged);
        
        if (InputWidth != null)
            InputWidth.onValueChange.AddListener(OnWidthChanged);
    }

    private void OnLengthChanged(string newValue)
    {
        ValidateInput(InputLength, newValue);
    }

    private void OnHeightChanged(string newValue)
    {
        ValidateInput(InputHeight, newValue);
    }

    private void OnWidthChanged(string newValue)
    {
        ValidateInput(InputWidth, newValue);
    }

    private void ValidateInput(InputField field, string newValue)
    {
        if (string.IsNullOrEmpty(newValue))
            return;

        if (newValue.Length == 1 && (newValue == "." || newValue == ","))
            return;

        string formattedValue = newValue.Replace(',', '.');

        float number;
        if (float.TryParse(formattedValue, out number))
        {
            if (number < 0)
                field.text = Mathf.Abs(number).ToString("F2"); 
        }
        else
        {
            field.text = newValue.Remove(newValue.Length - 1);
        }
    }

    void OnDestroy()
    {
        if (InputLength != null)
            InputLength.onValueChange.RemoveListener(OnLengthChanged);
        
        if (InputHeight != null)
            InputHeight.onValueChange.RemoveListener(OnHeightChanged);
        
        if (InputWidth != null)
            InputWidth.onValueChange.RemoveListener(OnWidthChanged);
    }
}