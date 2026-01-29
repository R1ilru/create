using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public Transform player;
    public Text scoreText;

    float maxHeight;

    void Start()
    {
        maxHeight = player.position.y;
    }

    void Update()
    {
        if (player.position.y > maxHeight)
        {
            maxHeight = player.position.y;
        }

        scoreText.text = $"SCORE : {(int)maxHeight}";
    }
}
