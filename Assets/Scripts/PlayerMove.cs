using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    enum InventoryItem
    {
        Diamond,
        Gold,
        Silver,
        Iron,
        Branch
    }
    public int score;
    [SerializeField]private float moveSpeed = 4f;
    [SerializeField]private Animator anim;
    [SerializeField]private Vector2 moveDir;
    [SerializeField]private SpriteRenderer spriteRenderer;
    [SerializeField]private TextMeshProUGUI hpText;
    [SerializeField]private TextMeshProUGUI dynamicText;
    
    [SerializeField]private Transform sword;
    public int[] inventory;
    [SerializeField]private int hp;
    [SerializeField]private bool isDelay;
    [SerializeField]private bool isTeleportDelay;
    [SerializeField]private GameObject createUI;
    [SerializeField]private GameObject barier;
    [SerializeField] private bool noDamage;
    [SerializeField] private AudioSource hit;
    [SerializeField] private AudioSource slash;
    [SerializeField] private AudioSource gettingItem;
    [SerializeField] private AudioSource teleportSound;
    [SerializeField] private AudioSource dinkSound;

    private void Start()
    {
        hpText.text = $"hp: {hp}";
        anim = gameObject.GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        InputUpdate();
        Attack();
    }

    void Attack()
    {
        if (!isDelay && Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetTrigger("Sword");
            slash.Play();
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        isDelay = true;
        yield return new WaitForSeconds(0.75f);
        isDelay = false;
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void InputUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        anim.SetBool("IsWalk", h != 0|| v != 0);
        if (h < 0)
        {
            sword.rotation = Quaternion.Euler(0,180,0);
            spriteRenderer.flipX = true; 
        }
        if (h > 0)
        {
            sword.rotation = Quaternion.Euler(0,0,0);
            spriteRenderer.flipX = false; 
        }
        moveDir.Set(h, v);
    }

    private void Move()
    {
        transform.Translate(moveSpeed * Time.fixedDeltaTime * moveDir.normalized);
    }

    public void AddDamage(int damage)
    {
        if (noDamage) return;
        hp -= damage;
        hit.Play();
        hpText.text = $"hp: {hp}";
        if (hp <= 0)
        {
            Ranking.Instance.SetRank(score);
            SceneManager.LoadScene("GameOver");
        }
        StartCoroutine(NoDamage());
    }
    IEnumerator NoDamage()
    {
        noDamage = true;
        barier.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        barier.SetActive(false);
        noDamage = false;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Stairs") && !isTeleportDelay)
        {
            if (col.name == "StairA")
            {
                transform.position = new Vector3(99.54f, 6.07f);
            }
            else
            {
                transform.position = new Vector3(-1.5f, 7f);
            }
            teleportSound.Play();
            StartCoroutine(TeleportDelay());
        }

        if (col.CompareTag("Totem"))
        {
            dynamicText.text = "아이템을 만드시려면 토템에 다가가세요";
            Invoke("ClearDynamic", 2.5f);
        }
        if (col.CompareTag("Heal"))
        {
            dinkSound.Play();
            hp += 3;
            if (hp > 5)
                hp = 5;
            hpText.text = $"hp: {hp}";
            Destroy(col.gameObject);
        }
        if (col.CompareTag("Item"))
        {
            switch (col.name)
            {
                case "Diamond(Clone)":
                    inventory[(int)InventoryItem.Diamond] += 1;
                    break;
                case "Gold(Clone)":
                    inventory[(int)InventoryItem.Gold] += 1;
                    break;
                case "Iron(Clone)":
                    inventory[(int)InventoryItem.Iron] += 1;
                    break;
                case "Branch(Clone)":
                    inventory[(int)InventoryItem.Branch] += 1;
                    break;
                case "Silver(Clone)":
                    inventory[(int)InventoryItem.Silver] += 1;
                    break;
            }
            gettingItem.Play();
            Destroy(col.gameObject);
        }
    }
    IEnumerator TeleportDelay()
    {
        isTeleportDelay = true;
        yield return new WaitForSeconds(1f);
        isTeleportDelay = false;
    }

    void ClearDynamic()
    {
        dynamicText.text = "";
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Totem"))
        {
            createUI.SetActive(true);
        }
    }
}
