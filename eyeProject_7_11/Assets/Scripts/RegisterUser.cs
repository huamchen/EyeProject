using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RegisterUser : MonoBehaviour {

    public void register()
    {
        string firstname = GameObject.Find("FirstName/InputField/Text").GetComponent<Text>().text;
        string lastname = GameObject.Find("LastName/InputField/Text").GetComponent<Text>().text;
        string grade = GameObject.Find("Grade/InputField/Text").GetComponent<Text>().text;
        string sid = GameObject.Find("SID/InputField/Text").GetComponent<Text>().text;


        SqliteDbHelper db = new SqliteDbHelper("Data Source=./sqlite.db");
        if (!db.CheckTable("user"))
            db.CreateTable("user", new string[] { "userid", "firstname", "lastname", "grade" }, new string[] { "integer primary key", "text not null", "text not null", "int not null" });
        db.InsertInto("user", new string[] { sid, "'" + firstname + "'", "'" + lastname + "'", grade });
        db.CloseSqlConnection();
        Debug.Log("OK!");
        PlayerPrefs.SetString("sid", sid);
    }
}
