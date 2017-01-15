using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class RanDotStereogram : MonoBehaviour {
    public Texture2D pic;
    public int flag;
    // Use this for initialization
    public void newRandomImage () {
	    pic = new Texture2D(200,200,TextureFormat.RGBA32,true);
        for (int i = 0; i < 200; i++)
            for (int j = 0; j < 200; j++)
                pic.SetPixel(i, j, new Color(0, 0, 0, 0));
        pic.Apply();
  /*      for (int i = 0; i < 200; i++)
            for (int j = 0; j < 200; j++)
                if((i+j)%10==0)
                    pic.SetPixel(i, j, new Color(1, 0, 0, 1));*/
          for (int i=0;i<10000;i++)
                pic.SetPixel(Random.Range(0,190), Random.Range(0, 200), new Color(1,0,0,1));
        pic.Apply();
        flag = Random.Range(0, 3);
        if (flag == 0)
            RandomRect();
        if (flag == 1)
            RandomTri();
        if (flag == 2)
            RandomCir();
        GameObject.Find("Image").GetComponent<Image>().sprite = Sprite.Create(pic, GameObject.Find("Image").GetComponent<Image>().sprite.textureRect, new Vector2(0.5f, 0.5f));
    }
    void RandomRect()
    {
        for (int i = 199; i >=10; i--)
            for (int j = 0; j < 200; j++)
            {
                if (i > 60 && i < 140 && Mathf.Abs(100- j)< 40 - Mathf.Abs(i-100))
                {
                    if (pic.GetPixel(i-5, j) == new Color(1, 0, 0, 1))
                        pic.SetPixel(i, j, pic.GetPixel(i, j) + new Color(0, 1, 0, 1));
                }
                else if (pic.GetPixel(i-10, j) == new Color(1, 0, 0, 1))
                    pic.SetPixel(i, j, pic.GetPixel(i, j)+ new Color(0, 1, 0, 1)); 
            }
        pic.Apply();
    }
    void RandomTri()
    {
        for (int i = 199; i >= 10; i--)
            for (int j = 0; j < 200; j++)
            {
                if (i > 50 && i < 150 &&  j > 70 && j < 50 + 100-2*Mathf.Abs(100- i))
                {
                    if (pic.GetPixel(i-5, j) == new Color(1, 0, 0, 1))
                        pic.SetPixel(i, j, pic.GetPixel(i, j) + new Color(0, 1, 0, 1));
                }
                else if (pic.GetPixel(i-10 , j) == new Color(1, 0, 0, 1))
                    pic.SetPixel(i, j, pic.GetPixel(i, j) + new Color(0, 1, 0, 1));
            }
        pic.Apply();
    }
    void RandomCir()
    {
        for (int i = 199; i >= 10; i--)
            for (int j = 0; j < 200; j++)
            {
                if ((i-100)*(i-100)+(j-100)*(j-100)<2000)
                {
                    if (pic.GetPixel(i-5, j) == new Color(1, 0, 0, 1))
                        pic.SetPixel(i, j, pic.GetPixel(i, j) + new Color(0, 1, 0, 1));
                }
                else if (pic.GetPixel(i-10, j) == new Color(1, 0, 0, 1))
                    pic.SetPixel(i, j, pic.GetPixel(i, j) + new Color(0, 1, 0, 1));
            }
        pic.Apply();
    }
    void Start()
    {
        newRandomImage();
    }
}
