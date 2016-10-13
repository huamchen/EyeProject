using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NearVisionAcuityResult : MonoBehaviour {

    // Use this for initialization
    public void Reset()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Upload()
    {

        string sid = PlayerPrefs.GetString("sid", "001");
        string score = GameObject.Find("Result/Score").GetComponent<Text>().text;
        string level = GameObject.Find("Result/Text").GetComponent<Text>().text;

        SqliteDbHelper db = new SqliteDbHelper("Data Source=./sqlite.db");
        if (!db.CheckTable("test1"))
            db.CreateTable("test1", new string[] { "recordID", "userId", "level", "score", "date" }, new string[] { "integer primary key autoincrement", "int not null", " text not null", "text not null", " timestamp default (date('now'))" });
        db.InsertIntoSpecific("test1", new string[] { "userId", "score", "level" }, new string[] { sid, "'" + score + "'", "'" + level + "'" });
        db.CloseSqlConnection();
        Debug.Log("OK!");
        SceneManager.LoadScene("menu");
    }
}
