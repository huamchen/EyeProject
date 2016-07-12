using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RanDotStereogram : MonoBehaviour {
    public Texture2D lpic;
    public Texture2D rpic;
    // Use this for initialization
    void Start () {
	    lpic = new Texture2D(100, 100,TextureFormat.RGBA32,true);
        rpic = new Texture2D(100, 100, TextureFormat.RGBA32, true);
        for (int i = 0; i < 100; i++)
            for (int j = 0; j < 100; j++)
                lpic.SetPixel(i, j, new Color(0, 0, 0, 0));
        lpic.Apply();
        for (int i=0;i<5000;i++)
            lpic.SetPixel(Random.Range(0,100), Random.Range(0, 100), new Color(1,0,0,1));
        lpic.Apply();
        for (int i = 0; i < 100; i++)
            for (int j = 0; j < 100; j++)
            {
                if (i > 20 && i < 40 && j > 20 && j < 40)
                {
                    rpic.SetPixel(i, j, lpic.GetPixel(i+20,j+20));
                }
                else rpic.SetPixel(i, j, lpic.GetPixel(i, j));
                if (rpic.GetPixel(i, j) == new Color(1, 0, 0, 1))
                    rpic.SetPixel(i, j, new Color(0, 1, 0, 1));
            }

        rpic.Apply();
        GameObject.Find("Left").GetComponent<GUITexture>().texture= lpic;
        GameObject.Find("Right").GetComponent<GUITexture>().texture = rpic;
    }
	
	// Update is called once per frame
	void Update () {
   

	}
}
