using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerNameText;
    public GameObject inputField_Name;
    public GameObject rankObject;
    public GameObject helpUI;
    private bool isPushRank = false;
    private bool isPushHelp = false;
    private void Start()
    {
        playerNameText.text = $"player: player";
        Ranking.Instance.playerName = "player";
    }

    public void StartButton()
    {
        SceneManager.LoadScene("InGame");
    }

    public void ExitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

    public void EnterName()
    {
        playerNameText.text = $"player: {inputField_Name.GetComponent<TMP_InputField>().text}";
        Ranking.Instance.playerName = inputField_Name.GetComponent<TMP_InputField>().text;
    }

    public void RankButton()
    {
        if(!isPushRank)
        {
            rankObject.SetActive(true);
            isPushRank = true;
        }
        else
        {
            rankObject.SetActive(false);
            isPushRank = false;
        } 
    }

    public void HelpButton()
    {
        helpUI.SetActive(true);
    }

}
