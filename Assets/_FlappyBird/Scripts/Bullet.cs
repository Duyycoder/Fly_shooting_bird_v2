using System;
using System.Collections;
using System.Collections.Generic;
using GameTool;
using UnityEngine;

public class Bullet : BasePooling
{
    public float speed;
    public float damage;
    public Rigidbody2D rb;
    public SpriteRenderer sr;

    private void OnEnable()
    {
        rb.velocity = new Vector2(speed, 0);
        int score = GameData.Instance.score;
        int index = score / 10;
        
        if (index >= GameData.Instance.bulletData.BulletInfos.Count)
        {
            index = GameData.Instance.bulletData.BulletInfos.Count - 1;
        }

        sr.sprite = GameData.Instance.bulletData.BulletInfos[index].sprite;
        damage = GameData.Instance.bulletData.BulletInfos[index].damage;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Block"))
        {
           // Debug.Log("Hit Block");
           var block = other.gameObject.GetComponent<Block>();
           block.TakeDamage(damage);
           gameObject.SetActive(false);
        }
    }
}
public enum BulletType
{
    Red = 0,
    Blue = 1,
    Green = 2
}
