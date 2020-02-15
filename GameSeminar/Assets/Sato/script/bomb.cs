using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    public int bulletnumber=25;//弾の数
    float x;
    float y;


    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "P2_bullet")
        {
            //BulletだったらBombが消える
            Destroy(this.gameObject);
        }
        if (col.gameObject.tag == "P1_bullet")
        {
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        x = Random.Range(-8, 8);
        y = Random.Range(-5, 5);
        for (int i = 0; i <= bulletnumber; i++)
        {
            GameObject obj = (GameObject)Resources.Load("BomBullet");
            GameObject instantiate = Instantiate(obj, new Vector2(x, y), Quaternion.identity);//弾の生成される位置
        }
    }

}
