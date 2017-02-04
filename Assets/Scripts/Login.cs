using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using System.Linq;//contains
using System;

public class Login : MonoBehaviour {
    public GameObject username;
    public GameObject password;

    private string USERNAME;
    private string PASSWORD;

    private string db_login;

    private string URL = "http://localhost/social_vr/LoginData.php?username_post=";

    // Use this for initialization
    public void Start()
    {


    }

    public IEnumerator check_form(string newURL)
    {

        WWW userData = new WWW(newURL);
        yield return userData;

 
        db_login = userData.text;
        //print("print: "+ db_login);
        login_check();

    }

    string get_col(string data, string index)
    {
        string value = data;
        if (value != null)
        {
            if (data.Contains(index))
                value = data.Substring(data.IndexOf(index) + index.Length);
            else
            {
                print("No User exists!");
                return "";
            }

            value = value.Contains("|") ? value.Remove(value.IndexOf("|")) : value;
        }
            
        return value;
    }


    public string search()
    {
        string pattern = @"Username:(\w+)\|Password:(\w+);";
        MatchCollection m = Regex.Matches(db_login, pattern);
        string db_user;
        string db_pass;

        foreach (Match match in m)
        {
            db_user = match.Groups[1].Value;
            db_pass = match.Groups[2].Value;

            if (db_user == USERNAME)
                return db_pass;
        }
        return "";
    }
    public void login_check()
    {
  
        if (db_login != null)
        {
            string db_pass;

            db_pass = get_col(db_login, "Password:");
            if (db_pass == "")
                return;
            db_pass= db_pass.Remove(db_pass.Length-1);


            if (db_pass != PASSWORD)
                print("INCORRECT PASSWORD");
            else
                print("Login Succesful!");
        }
    }

    public void login_button()
    {
        //if (System.IO.File.Exists(!@"C:/Programs/UnityTestFolder/" + WORLDNAME+ ".txt"))
        //else{
        //Debug.LogWarning("World Name is already in use");
        //}
        

        USERNAME = username.GetComponent<InputField>().text;
        PASSWORD = password.GetComponent<InputField>().text;
        

        string newURL = URL + USERNAME;

        StartCoroutine(check_form(newURL));

        print(db_login);


        

        
        

    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (username.GetComponent<InputField>().isFocused)
            {
                password.GetComponent<InputField>().Select();
            }

        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (PASSWORD != "" && USERNAME != "")
            {
                login_button();
            }

        }
        
    }
}
