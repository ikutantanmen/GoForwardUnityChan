using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour
{
    [SerializeField] GameObject m_explosionPrefab;

    // キューブの移動速度
    private float speed = -0.2f;

    // 消滅位置
    private float deadLine = -10;

    // 爆発効果音
    public AudioClip explosionSE;

    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = explosionSE;        // 鳴らす音(変数)を格納.
        audioSource.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        // キューブを移動させる
        transform.Translate(this.speed, 0, 0);

        // 画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // もしもtagがbulletであるオブジェクトと接触したら
        if (collision.gameObject.tag == "Bullet")
        {
            // オーディオを再生
            AudioSource.PlayClipAtPoint(explosionSE, transform.position);
            //爆発のエフェクト追加
            Instantiate(m_explosionPrefab, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
