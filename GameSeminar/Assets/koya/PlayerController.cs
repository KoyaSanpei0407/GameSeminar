using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int hp;
    public float speed;
    public int pnum;
    private string pnum_s;
    private float lh, lv, rh, rv;

    float angle;

    public Shot m_shotPrefab; // 弾のプレハブ
    public float m_shotSpeed; // 弾の移動の速さ
    public float m_shotAngleRange; // 複数の弾を発射する時の角度
    public float m_shotTimer; // 弾の発射タイミングを管理するタイマー
    public int m_shotCount; // 弾の発射数
    public float m_shotInterval; // 弾の発射間隔（秒）

    void Start()
    {
        hp = 10;
        pnum_s = pnum.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //Lスティックの入力
        lh = Input.GetAxis("Controller" + pnum_s + "_LStickX");
        lv = Input.GetAxis("Controller" + pnum_s  + "_LStickY");
        //移動
        if ((lh != 0) || (lv != 0))
        {
            Vector3 pos = transform.position;
            pos.y += speed * Time.deltaTime * lv;
            pos.x += speed * Time.deltaTime * lh;
            transform.position = pos;
        }

        //Rスティックの入力
        rh = Input.GetAxis("Controller" + pnum_s + "_RStickX");
        rv = Input.GetAxis("Controller" + pnum_s + "_RStickY");
        //回転
        if ((rh != 0) || (rv != 0))
        {
            angle = (Mathf.Atan2(rv, rh) * Mathf.Rad2Deg) - 90.0f;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);
        }

        if(hp == 0)
        {
            Destroy(gameObject);
        }

        // 弾の発射タイミングを管理するタイマーを更新する
        m_shotTimer += Time.deltaTime;

        // まだ弾の発射タイミングではない場合は、ここで処理を終える
        if (m_shotTimer < m_shotInterval) return;

        // 弾の発射タイミングを管理するタイマーをリセットする
        m_shotTimer = 0;

        // 弾を発射する
        ShootNWay(angle + 90.0f, m_shotAngleRange, m_shotSpeed, m_shotCount);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if(pnum == 1)
        {
            if (col.gameObject.tag == "P2_bullet")
            {
                hp -= 1;
                Destroy(col.gameObject);
            }
        }
        else if(pnum == 2)
        {
            if (col.gameObject.tag == "P1_bullet")
            {
                hp -= 1;
                Destroy(col.gameObject);
            }
        }


    }

    private void ShootNWay(
    float angleBase, float angleRange, float speed, int count)
    {
        var pos = transform.localPosition; // プレイヤーの位置
        var rot = transform.localRotation; // プレイヤーの向き

        // 弾を複数発射する場合
        if (1 < count)
        {
            // 発射する回数分ループする
            for (int i = 0; i < count; ++i)
            {
                // 弾の発射角度を計算する
                var angle = angleBase +
                    angleRange * ((float)i / (count - 1) - 0.5f);

                // 発射する弾を生成する
                var shot = Instantiate(m_shotPrefab, pos, rot);

                // 弾を発射する方向と速さを設定する
                shot.Init(angle, speed);
            }
        }
        // 弾を 1 つだけ発射する場合
        else if (count == 1)
        {
            // 発射する弾を生成する
            var shot = Instantiate(m_shotPrefab, pos, rot);

            // 弾を発射する方向と速さを設定する
            shot.Init(angleBase, speed);
        }
    }
}
