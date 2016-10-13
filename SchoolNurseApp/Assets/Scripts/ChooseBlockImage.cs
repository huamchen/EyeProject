using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChooseBlockImage : MonoBehaviour {
    public int unblock = 6;
	// Use this for initialization
	void Start () {
        chooseThis(unblock);
	}

    public void chooseThis(int index)
    {
        Transform parent = GameObject.Find("BlockImage").transform;
        for(int i = 0; i < parent.childCount; i++)
        {
            if (i != index)
            {
                parent.GetChild(i).GetComponent<Image>().enabled = true;
            }
            else parent.GetChild(i).GetComponent<Image>().enabled = false;
        }
        unblock = index;
    }

}
