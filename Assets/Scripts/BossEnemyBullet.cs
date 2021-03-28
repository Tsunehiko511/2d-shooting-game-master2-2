using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyBullet : MonoBehaviour
{
    // 設定された方向に弾を移動させる
    float dx;
    float dy;
    public void Setting(float angle, float speed)
    {
        // 敵の右側が0°
        // 反時計回りに角度は増える

        // 2PIが360°
        // PIが180°
        // PI/2が90°

        dx = Mathf.Cos(angle) * speed;
        dy = Mathf.Sin(angle) * speed;
    }

    void Update()
    {
        transform.position += new Vector3(dx, dy, 0) * Time.deltaTime;

        if (transform.position.x < -3 || transform.position.x > 3||
            transform.position.y < -3 || transform.position.y > 3)
        {
            Destroy(gameObject);
        }
    }
}
