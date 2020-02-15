using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    float x;//ｘ方向の成分
    float y;//ｙ方向の成分
    private float bullettime = 0.0f;//弾が生まれてから経った秒数
    public float speed;//弾の速度
    public float lifespan;//寿命

    // Start is called before the first frame update
    void Start()//ｘとｙの角度をランダム生成する
    {
         x = Random.Range(-1f, 1f);
        y = Random.Range(-1f, 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)//壁に当たったら反射させる
    {
            if(collision.gameObject.name == "SquareUp") 
            x *= -1;
            if (collision.gameObject.name == "SquareDown")
            x *= -1;
            if (collision.gameObject.name == "SquareLeft")
            y *= -1;
            if (collision.gameObject.name == "SquareRight")
            y *= -1;
    }
    // Update is called once per frame
    void Update()
    {
        var muki = new Vector2(x, y).normalized;//弾のベクトルを正規化して向きだけを求める
        var houkou = Quaternion.Euler(muki) * Vector3.forward;//弾の向きを固定する

        transform.position += houkou * speed * Time.deltaTime;//弾の移動

        bullettime += Time.deltaTime;//秒数計測

        if (bullettime > lifespan)//２秒で弾を消す
            Destroy(gameObject);

    }
}
