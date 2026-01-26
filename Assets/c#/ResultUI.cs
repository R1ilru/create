using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultUI : MonoBehaviour
{
    public Text heightText;

    void Start()
    {
        heightText.text = $"HEIGHT : {(int)GameData.maxHeight}";
    }
}
