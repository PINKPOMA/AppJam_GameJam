using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject tuto2;
    [SerializeField] private GameObject nextBtton;
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject tutorial;
    [SerializeField] private AudioSource pageturn;
    
    public void OnNextButton()
    {
        pageturn.Play();
        nextBtton.SetActive(false);
        tuto2.SetActive(true);
        backButton.SetActive(true);
    }
    public void OnBackButton()
    {
        pageturn.Play();
        nextBtton.SetActive(true);
        tuto2.SetActive(false);
        backButton.SetActive(false);
    }

    public void ExitButton()
    {
        tutorial.SetActive(false);
    }
}
