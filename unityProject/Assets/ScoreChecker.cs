using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreChecker : MonoBehaviour
{
    TMP_Text scoreText;

    private void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "Your BEST BREADS: " + PlayerPrefs.GetInt("Breads").ToString();
    }
}
