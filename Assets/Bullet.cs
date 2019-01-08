using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 弾オブジェクト（Inspectorでオブジェクトを指定）
    [SerializeField] // Inspectorで操作できるように属性を追加します
    private GameObject bullet;
    // 弾オブジェクトのRigidbody2Dの入れ物
    private Rigidbody2D rb2d;
    // 弾オブジェクトの移動係数（速度調整用）
    float bulletSpeed;
    void Start()
    {
        // オブジェクトのRigidbody2Dを取得
        rb2d = GetComponent<Rigidbody2D>();
        // 弾オブジェクトの移動係数を初期化
        bulletSpeed = 20.0f;
        // 出現から3秒後に弾オブジェクトを消滅させる（メモリの節約）
        Destroy(gameObject, 3.0f);
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
    // Cubeと接触したときの関数
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Cubeに弾が接触したら弾は消滅する
        if (collision.gameObject.tag == "Cube")
        {
            Destroy(gameObject);
        }
    }
}