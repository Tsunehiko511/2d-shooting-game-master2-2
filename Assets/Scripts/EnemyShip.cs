using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 敵が弾を発射する
 * ・弾を作る
 * ・弾の移動を実装する
 * ・発射ポイントを作る // なし
 * ・敵から弾を生成する
 * ・Playerが弾に当たったら破壊される
 * 　・弾にコライダーをつける
 * ・敵が自分の弾に当たったら破壊されるバグの修正
 */

public class EnemyShip : MonoBehaviour
{
    //爆破エフェクト
    public GameObject explosion;

    public GameObject bulletPrefab;

    //GameControllerのAddScoreメソッドを使用するため入れ物を用意
    GameController gameController;


    float offset;

    void Start()
    {
        //揺れ方をランダムにする
        offset = Random.Range(0, 2f * Mathf.PI);
        InvokeRepeating("Shot", 2f, 1f);
        //GameObject.Find("")でカッコ内のオブジェクトを取得し、GetComponentでそのオブジェクトの指定した部品を取得してくる
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    void Shot()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }


    //接触判定があった場合(collisonには接触したオブジェクトの情報が入っている)
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //playerと敵が接触した時
        if (collision.CompareTag("Player") == true)
        {
            //破壊する時に爆破エフェクト生成（生成したいもの、場所、回転）
            Instantiate(explosion, collision.transform.position, transform.rotation);
            gameController.GameOver();
        }
        //Bulletと敵が接触した時
        else if (collision.CompareTag("Bullet") == true)
        {
            //スコア加算
            gameController.AddScore();
        }
        else if (collision.CompareTag("EnemyBullet") == true)
        {
            return;// この関数に関してはここで、実行を終える
        }
        else if (collision.CompareTag("BossEnemy") == true)
        {
            return;// この関数に関してはここで、実行を終える
        }

        //破壊する時に爆破エフェクト生成（生成したいもの、場所、回転）
        Instantiate(explosion, transform.position, transform.rotation);
        //enemyの機体を破壊
        Destroy(gameObject);
        //collisionはぶつかった相手の情報が入っている。この場合は弾
        Destroy(collision.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //左右に揺れながら、下に移動する＊＊＊＊＊＊＊＊＊＊＊＊＊今回修正
        transform.position -= new Vector3(
            Mathf.Cos(Time.frameCount * 0.05f + offset) * 0.01f,
            Time.deltaTime,
            0);

        //撃った弾のy軸が-3以下の位置にいったら破壊
        if (transform.position.y < -3)
        {
            Destroy(gameObject);
        }
    }
}