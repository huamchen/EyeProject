using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RanDotStereogram : MonoBehaviour {
    public Texture2D lpic;
    public Texture2D rpic;
    // Use this for initialization
    public void newRandomImage () {
	    lpic = new Texture2D(200,200,TextureFormat.RGBA32,true);
        rpic = new Texture2D(200,200, TextureFormat.RGBA32, true);
        for (int i = 0; i < 200; i++)
            for (int j = 0; j < 200; j++)
                lpic.SetPixel(i, j, new Color(0, 0, 0, 0));
        lpic.Apply();
        for (int i=0;i<20000;i++)
            lpic.SetPixel(Random.Range(0,200), Random.Range(0, 200), new Color(1,0,0,1));
        lpic.Apply();
        for (int i = 0; i < 200; i++)
            for (int j = 0; j < 200; j++)
            {
                if (i > 20 && i < 80 && j > 20 && j < 80)
                {
                    rpic.SetPixel(i, j, lpic.GetPixel(i+40,j+40));
                }
                else rpic.SetPixel(i, j, lpic.GetPixel(i, j));
                if (rpic.GetPixel(i, j) == new Color(1, 0, 0, 1))
                    rpic.SetPixel(i, j, new Color(0, 1, 0, 1));
            }

        rpic.Apply();
        GameObject.Find("LeftImage").GetComponent<Image>().sprite = Sprite.Create(lpic, GameObject.Find("LeftImage").GetComponent<Image>().sprite.textureRect, new Vector2(0.5f, 0.5f));
        GameObject.Find("RightImage").GetComponent<Image>().sprite = Sprite.Create(rpic, GameObject.Find("RightImage").GetComponent<Image>().sprite.textureRect, new Vector2(0.5f, 0.5f));
    }
    void Start()
    {
        newRandomImage();
    }
}
