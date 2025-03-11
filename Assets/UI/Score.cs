using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score Instance;

    public TextMeshProUGUI scoreText;

    private int scoreCounter = 0;
    private void Start()
    {
        Instance = this;
        scoreText.text = $"Зібрано: {scoreCounter}";
    }
    public void UpdateScore()
    {
        scoreCounter++;
        scoreText.text = $"Зібрано: {scoreCounter}";
    }
}
