using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    public float rotSpeed = 200f; // È¸Àü ¼Óµµ

    float mx = 0, my = 0; // È¸Àü °ª

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        // ¸¶¿ì½º ÀÔ·Â ¹Þ±â
        float mouse_X = Input.GetAxis("Mouse X");
        float mouse_Y = Input.GetAxis("Mouse Y");

        // È¸Àü°ª º¯¼ö¿¡ ¸¶¿ì½º ÀÔ·Â °ª¸¸Å­ ´©Àû
        mx += mouse_X * rotSpeed * Time.deltaTime;
        my += mouse_Y * rotSpeed * Time.deltaTime;

        // ¸¶¿ì½º »óÇÏ ÀÌµ¿ º¯¼ö myÀÇ °ª -90µµ~90µµ·Î Á¦ÇÑ
        my = Mathf.Clamp(my, -90f, 90f);

        //¹°Ã¼¸¦ È¸Àü ¹æÇâÀ¸·Î È¸Àü½ÃÅ°±â
        transform.eulerAngles = new Vector3(-my, mx, 0);
    }
}
