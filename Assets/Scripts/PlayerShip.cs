using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    public AudioClip shotSE;
    public GameObject BulletPrefab;
    public GameObject FiarPoint;
    public GameObject explosion;


    AudioSource audioSource;
    GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shot();
    }

    void Move()
    {   
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 nextPoint = transform.position + new Vector3(x, y, 0) * Time.deltaTime * 4;

        nextPoint = new Vector3(
            Mathf.Clamp(nextPoint.x,-2.9f,2.9f),
            Mathf.Clamp(nextPoint.y, -2f, 2f),
            0
            );

        transform.position = nextPoint;
    }
    void Shot()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.PlayOneShot(shotSE);
            Instantiate(BulletPrefab, FiarPoint.transform.position, transform.rotation);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet") == true)
        {
            // 爆破エフェクト
            Instantiate(explosion, transform.position, transform.rotation);
            // 自分を破壊
            Destroy(gameObject);
            // 弾を破壊
            Destroy(collision.gameObject);
            gameController.GameOver();
        }
    }
}
