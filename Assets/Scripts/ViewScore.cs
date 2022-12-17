using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ViewScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject table;
    [SerializeField] private PlayerMove player;


    private void Update()
    {
        scoreText.text = $"점수: {player.score}";
    }

    public void XButton()
    {
        table.SetActive(false);
    }
}
