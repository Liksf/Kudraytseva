using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransitionWithBox : MonoBehaviour
{
    public InputField InputWidth;
    public InputField InputHeight;
    public InputField InputDepth;
    public GameObject planePrefab;

    public static class BoxParameters
    {
        public static float width;
        public static float height;
        public static float depth;
    }
    void OnDestroy()
    {
        BoxParameters.width = 0;
        BoxParameters.height = 0;
        BoxParameters.depth = 0;
    }
    public void ValidateAndSwitchScene()
    {
        float width, height, depth;
        bool isValid = true;

        if (!float.TryParse(InputWidth.text, out width) || width <= 0)
        {
            Debug.LogError("Invalid width!");
            isValid = false;
        }

        if (!float.TryParse(InputHeight.text, out height) || height <= 0)
        {
            Debug.LogError("Invalid height!");
            isValid = false;
        }

        if (!float.TryParse(InputDepth.text, out depth) || depth <= 0)
        {
            Debug.LogError("Invalid depth!");
            isValid = false;
        }

        if (isValid)
        {
            BoxParameters.width = width;
            BoxParameters.height = height;
            BoxParameters.depth = depth;
            SceneManager.LoadScene("App");
        }
    }
}