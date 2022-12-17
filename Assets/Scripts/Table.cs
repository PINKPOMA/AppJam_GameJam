using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Table : MonoBehaviour
{
    enum InventoryItem
    {
        Diamond,
        Gold,
        Silver,
        Iron,
        Branch
    }
    [SerializeField] private int nowLinkCount;
    [SerializeField] private Sprite[] itemSprite;
    [SerializeField] private Image[] itemLink;
    [SerializeField] private int[] itemLinkNote;
    [SerializeField] private TextMeshProUGUI sellText;
    [SerializeField] private TextMeshProUGUI[] inventoryCount;
    [SerializeField] private AudioSource hammer ;

    private void FixedUpdate()
    {
        RefreshText();
    }

    void RefreshText()
    {
        var plr = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
        inventoryCount[(int)InventoryItem.Diamond].text = plr.inventory[(int)InventoryItem.Diamond].ToString();
        inventoryCount[(int)InventoryItem.Gold].text = plr.inventory[(int)InventoryItem.Gold].ToString();
        inventoryCount[(int)InventoryItem.Silver].text = plr.inventory[(int)InventoryItem.Silver].ToString();
        inventoryCount[(int)InventoryItem.Iron].text = plr.inventory[(int)InventoryItem.Iron].ToString();
        inventoryCount[(int)InventoryItem.Branch].text = plr.inventory[(int)InventoryItem.Branch].ToString();
    }

    public void DiamondButton()
    {
        Debug.Log("버튼 클릭");
        var plr = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
        if (plr.inventory[(int)InventoryItem.Diamond] < 1) StartCoroutine(CantDeal());
        else
        {
            plr.inventory[(int)InventoryItem.Diamond]--;
            itemLinkNote[nowLinkCount] = (int)InventoryItem.Diamond;
            itemLink[nowLinkCount].sprite = itemSprite[(int)InventoryItem.Diamond];
            nowLinkCount++;
            if (nowLinkCount > 1)
                StartCoroutine(Clear(itemLinkNote[0] + itemLinkNote[1]));
            RefreshText();
        }
    }

    public void GoldButton()
    {
        Debug.Log("버튼 클릭");
        var plr = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
        if (plr.inventory[(int)InventoryItem.Gold] < 1) StartCoroutine(CantDeal());
        else
        {
            plr.inventory[(int)InventoryItem.Gold]--;
            itemLinkNote[nowLinkCount] = (int)InventoryItem.Gold;
            itemLink[nowLinkCount].sprite  = itemSprite[(int)InventoryItem.Gold];
            nowLinkCount++;
            if (nowLinkCount > 1)
                StartCoroutine(Clear(itemLinkNote[0] + itemLinkNote[1]));
            RefreshText();
        }
    }
    public void SilverButton()
    {
        Debug.Log("버튼 클릭");
        var plr = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
        if (plr.inventory[(int)InventoryItem.Silver] < 1) StartCoroutine(CantDeal());
        else
        {
            plr.inventory[(int)InventoryItem.Silver]--;
            itemLinkNote[nowLinkCount] = (int)InventoryItem.Silver;
            itemLink[nowLinkCount].sprite  = itemSprite[(int)InventoryItem.Silver];
            nowLinkCount++;
            if (nowLinkCount > 1)
                StartCoroutine(Clear(itemLinkNote[0] + itemLinkNote[1]));
            RefreshText();
        }
    }
    public  void IronButton()
    {
        Debug.Log("버튼 클릭");
        var plr = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
        if (plr.inventory[(int)InventoryItem.Iron] < 1) StartCoroutine(CantDeal());
        else
        {
            plr.inventory[(int)InventoryItem.Iron]--;
            itemLinkNote[nowLinkCount] = (int)InventoryItem.Iron;
            itemLink[nowLinkCount].sprite  = itemSprite[(int)InventoryItem.Iron];
            nowLinkCount++;
            if (nowLinkCount > 1)
                StartCoroutine(Clear(itemLinkNote[0] + itemLinkNote[1]));
            RefreshText();
        }
    }
    public  void BranchButton()
    {
        Debug.Log("버튼 클릭");
        var plr = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
        if (plr.inventory[(int)InventoryItem.Branch] < 1) StartCoroutine(CantDeal());
        else
        {
            plr.inventory[(int)InventoryItem.Branch]--;
            itemLinkNote[nowLinkCount] = (int)InventoryItem.Branch;
            itemLink[nowLinkCount].sprite  = itemSprite[(int)InventoryItem.Branch];
            nowLinkCount++;
            if (nowLinkCount > 1)
                StartCoroutine(Clear(itemLinkNote[0] + itemLinkNote[1]));
            RefreshText();
        }
    }

    IEnumerator CantDeal()
    {
        sellText.text = "재료가 없습니다!";
        yield return new WaitForSeconds(1f);
        sellText.text = "";
    }
    
    IEnumerator Clear(int count)
    {
        var plr = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
        if (count < 2)
        {
            sellText.text = "훌륭한 상품!";
            plr.score += 500;
        }
        else if (count < 4)
        {
            sellText.text = "썩 괜찮은 상품!";
            plr.score += 400;
        }
        else if (count < 6)
        {
            sellText.text = "그저 그런 상품";
            plr.score += 300;
        }
        else if (count < 8)
        {
            sellText.text = "...상품?";
            plr.score += 100;
        }
        else if (count < 12)
        {
            sellText.text = "와..이건 못팔겠는데요?";
            plr.score += 0;
        }
        nowLinkCount = 0;
        hammer.Play();
        yield return new WaitForSeconds(1f);
        sellText.text = ""; 
        itemLink[0].sprite  = itemSprite[5];
        itemLink[1].sprite  = itemSprite[5];
    }
}
