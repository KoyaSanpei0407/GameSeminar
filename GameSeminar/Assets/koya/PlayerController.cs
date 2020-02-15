using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int hp;
    public float speed;
    public string pnum;
    private float lh, lv, rh, rv;

    void Start()
    {
        hp = 10;
    }

    // Update is called once per frame
    void Update()
    {
        //Lスティックの入力
        lh = Input.GetAxis("Controller" + pnum + "_LStickX");
        lv = Input.GetAxis("Controller" + pnum  + "_LStickY");

        if ((lh != 0) || (lv != 0))
        {
            Vector3 pos = transform.position;
            pos.y += speed * Time.deltaTime * lv;
            pos.x += speed * Time.deltaTime * lh;
            transform.position = pos;
        }

        //Rスティックの入力
        rh = Input.GetAxis("Controller" + pnum + "_RStickX");
        rv = Input.GetAxis("Controller" + pnum + "_RStickY");


        if ((rh != 0) || (rv != 0))
        {
            var angle = (Mathf.Atan2(rv, rh) * Mathf.Rad2Deg) - 90.0f;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "bullet")
        {
            hp -= 1;
        }
    }
}
