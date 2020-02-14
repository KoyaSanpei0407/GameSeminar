using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;       //歩行速度
    private float lh, lv, rh, rv;
    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Lスティックの入力
        lh = Input.GetAxis("Controller1_LStickX");
        lv = Input.GetAxis("Controller1_LStickY");

        if ((lh != 0) || (lv != 0))
        {
            Vector3 pos = transform.position;
            pos.y += speed * Time.deltaTime * lv;
            pos.x += speed * Time.deltaTime * lh;
            transform.position = pos;
        }

        rh = Input.GetAxis("Controller1_LStickX");
        rv = Input.GetAxis("Controller1_LStickY");
        

        if ((rh != 0) || (rv != 0))
        {

            var angle = (Mathf.Atan2(rv, rh) * Mathf.Rad2Deg) - 90.0f;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);
        }


    }
}
