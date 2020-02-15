﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    // 弾オブジェクトのRigidbody2Dの入れ物
    private Rigidbody2D rb2d;
    // 弾オブジェクトの移動係数（速度調整用）
    float bulletSpeed;

    void Start()
    {
        // オブジェクトのRigidbody2Dを取得
        rb2d = GetComponent<Rigidbody2D>();
        // 弾オブジェクトの移動係数を初期化
        bulletSpeed = 10.0f;
    }

    void Update()
    {
        // 弾オブジェクトの移動関数
        BulletMove();
    }

    // 弾オブジェクトの移動関数
    void BulletMove()
    {
        // 弾オブジェクトの移動量ベクトルを作成（数値情報）
        Vector2 bulletMovement = new Vector2(1, 0).normalized;
        // Rigidbody2D に移動量を加算する
        rb2d.velocity = bulletMovement * bulletSpeed;
    }

    // ENEMYと接触したときの関数
    void OnCollisionEnter2D(Collision2D collision)
    {
        // ENEMYに弾が接触したら弾は消滅する
        if (collision.gameObject.tag == "enemy")
        {
            Destroy(gameObject);
        }
    }
}