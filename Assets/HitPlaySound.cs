using UnityEngine;
using System.Collections;

public class HitPlaySound : MonoBehaviour
{

    private AudioSource sound01;

    void Start()
    {
        //AudioSourceコンポーネントを取得し、変数に格納
        sound01 = GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        string yourTag = collision.gameObject.tag;

        if (yourTag == "Cube" || yourTag == "Ground")
        {
            sound01.PlayOneShot(sound01.clip);
        }
    }
}
