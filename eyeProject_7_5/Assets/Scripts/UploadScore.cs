using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UploadScore : MonoBehaviour {

    public void LoadScene(int level)
    {

        string sid = PlayerPrefs.GetString("sid","001");
        string score = GameObject.Find("Result/Score").GetComponent<Text>().text;
        string result = GameObject.Find("Result/Text").GetComponent<Text>().text;

        SqliteDbHelper db = new SqliteDbHelper("Data Source=./sqlite.db");
        if (!db.CheckTable("test1"))
            db.CreateTable("test1", new string[] { "recordID", "userId", "score", "result","date" }, new string[] { "integer primary key autoincrement", "int not null", " text not null", "text not null"," timestamp default (date('now'))" });
        db.InsertIntoSpecific("test1", new string[] { "userId", "score", "result" }, new string[] { sid, "'" + score + "'", "'" + result + "'" });
        db.CloseSqlConnection();
        Debug.Log("OK!");
        SceneManager.LoadScene(level);
    }
}
