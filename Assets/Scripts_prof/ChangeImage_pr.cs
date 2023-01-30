using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage_pr : MonoBehaviour
{

    public Sprite[] ImagesArr;

    public SpriteRenderer Img_Renderer;
    public Sprite change_img1;
    public Sprite change_img2;

    Sprite thisImg;
    //public SpriteRenderer=Getcomponent.<SpriteRenderer>();

    
    
    
    // Start is called before the first frame update
    void Start()
    {
        Img_Renderer = GetComponent<SpriteRenderer>();
        
    }

    public void ChangeImage1()
    {
        Img_Renderer.sprite = change_img1;
        // thisImg.Sprite = change_img1;
        Debug.Log("함수호출됨");
    }

    public void ChangeImage2()
    {
        Img_Renderer.sprite = change_img2;
        // thisImg.Sprite = change_img1;
        Debug.Log("함수호출됨");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
