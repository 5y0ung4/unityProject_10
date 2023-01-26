using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage_pr : MonoBehaviour
{

    public Sprite[] ImagesArr;
    public Sprite change_img1;
    public Sprite change_img2;

    Image thisImg;
    
    // Start is called before the first frame update
    void Start()
    {
        thisImg = GetComponent<Image>();
        
    }

    public void ChangeImage1()
    {
        thisImg.sprite = change_img1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
