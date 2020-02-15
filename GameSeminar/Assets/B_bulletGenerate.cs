using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_bulletGenerate : MonoBehaviour
{
    public int bulletnumber;//弾の数
    float x;
    float y;

    // Start is called before the first frame update
    void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
        for (int i = 0; i <= bulletnumber; i++)
        {
            GameObject obj = (GameObject)Resources.Load("Bombbullet");
            GameObject instantiate = Instantiate(obj, new Vector2(x, y), Quaternion.identity);//弾の生成される位置
        }
    }
        // Update is called once per frame
        void Update()
    {
    }
}
