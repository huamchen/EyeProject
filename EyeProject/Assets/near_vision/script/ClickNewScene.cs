using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClickNewScene : MonoBehaviour {
    public string levelname;

	// Use this for initialization
	void Start () {
        var button = this.gameObject.GetComponent<Button>();
        if (button != null)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(TestClick);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void TestClick()
    {
        SceneManager.LoadScene(levelname);
    }
}
