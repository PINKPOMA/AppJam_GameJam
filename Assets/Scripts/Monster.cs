using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Monster : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject[] randomItem;
    
    [SerializeField] private float speed;
    [SerializeField] private int hp;
    [SerializeField] private int damages;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Animator anim;
    [SerializeField] private AudioSource hit ;
    

    private void Start()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        anim = gameObject.GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }


    private void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 dir = player.position - transform.position;
        dir.x = (dir.x < 0) ? -1 : 1;
        dir.y = (dir.y < 0) ? -1 : 1;
        transform.Translate(dir * speed * Time.deltaTime);
        _spriteRenderer.flipX = player.position.x < transform.position.x;

        if (transform.position.x > 29.25f)
            transform.position = new Vector3(29.25f, transform.position.y);
        if (transform.position.x < -27.2f)
            transform.position = new Vector3(-27.2f, transform.position.y);
        if (transform.position.y < -27f)
            transform.position = new Vector3(transform.position.x, -27);
        if (transform.position.y > 27.5f)
            transform.position = new Vector3(transform.position.x, 27.5f);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.tag)
        {
            case "Sword":
                AddDamage(1);
                break;
            case "Player":
                col.GetComponent<PlayerMove>().AddDamage(damages);
                Destroy(gameObject);
            break;
        }
    }

    void AddDamage(int num)
    {
        hp -= num;
        hit.Play();
        if (hp <= 0)
        {
            anim.SetTrigger("death");
        }
    }

    void Death()
    {
        ItemSpawn(Random.Range(0,10));
        Destroy(gameObject);
    }
    void ItemSpawn(int num)
    {
        if (num < 7)
        {
            Instantiate(randomItem[Random.Range(0, 5)], transform.position, Quaternion.identity);
        }
    }
}
