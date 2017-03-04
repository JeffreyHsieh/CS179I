using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class Register : MonoBehaviour {
    public GameObject username;
    public GameObject password;
    public GameObject confirm_Password;

    private string USERNAME;
    private string PASSWORD;
    private string CONFIRM_PASSWORD;
    public string ip_address;
    private string URL = "/social_vr/insertUser.php";

    private bool valid_user = false;
    private bool valid_pass = false;
    private bool matching_pass = false;

    public string input_username;
    public string input_password;

	// Use this for initialization
	void Start () {
	    	URL = "http://"+ip_address+URL;
	}
	
    public void create_user(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("username_post", username);
        form.AddField("password_post", password);

        WWW www = new WWW(URL, form);
    }

    public void register_button()
    {
        USERNAME = username.GetComponent<InputField>().text;
        PASSWORD = password.GetComponent<InputField>().text;
        CONFIRM_PASSWORD = confirm_Password.GetComponent<InputField>().text;

        string user = "(^[a-zA-Z]+$|^[a-zA-Z]+([0-9]|[a-zA-Z]|[_-])*([0-9]|[a-zA-Z])+$)";


        if (Regex.IsMatch(USERNAME, user))
        {
            valid_user = true;
        }

        if(PASSWORD.Length >= 6)
        {
            valid_pass = true;
        }

        if(PASSWORD == CONFIRM_PASSWORD)
        {
            matching_pass = true;
        }

        if(valid_user && valid_pass && matching_pass)
        {
            create_user(USERNAME, PASSWORD);
            print("Registration was successful!");
        }

        else
        {
            if (!valid_user)
            {
                print("INVALID USERNAME");
            }
            if (!valid_pass)
            {
                print("INVALID PASSWORD -- PASSWORD MUST BE ATLEAST 6 CHARS");
            }
            if (!matching_pass)
            {
                print("PASSWORDS DON'T MATCH");
            }
        }
        valid_user = false;
        valid_pass = false;
        matching_pass = false;
    }
	// Update is called once per frame
	void Update () {
        
        
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (username.GetComponent<InputField>().isFocused)
            {
                password.GetComponent<InputField>().Select(); 
            }

            if (password.GetComponent<InputField>().isFocused)
            {
                confirm_Password.GetComponent<InputField>().Select();
            }

        }
        

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (PASSWORD != "" && USERNAME != "" && CONFIRM_PASSWORD != "")
            {
                register_button();
            }

        }

    }
}
