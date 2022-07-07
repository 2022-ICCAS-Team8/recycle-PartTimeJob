using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Login : MonoBehaviour
{
  public InputField inputUserName;
	public InputField inputPassword;

  public GameObject txtUserName;
  public GameObject UserName;
  
  public GameObject StartGroup;
  public GameObject LoginGroup;
  WWW www;


	string CreateUserURL = "https://unity-db-kutsm.run.goorm.io/Unity_DB/login.php";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void userLogin()
	  {
      string username = inputUserName.text;
      string password = inputPassword.text;
    
      WWWForm form = new WWWForm ();
      form.AddField ("usernamePost", username);
      form.AddField ("passwordPost", password);
      Debug.Log(username);
      Debug.Log(password);

      WWW www = new WWW (CreateUserURL, form);

      form.AddField ("usernamePost", username);
      form.AddField ("passwordPost", password);

      StartCoroutine (Send(form));

    }
    
    IEnumerator Send(WWWForm wF){
      www = new WWW(CreateUserURL, wF);
      yield return www;

      Debug.Log(www.text);

      if(www.error != null){
        print(www.error);
      } else{
        txtUserName.GetComponent<Text>().text = inputUserName.text;
        UserName.GetComponent<Text>().text = inputUserName.text;

        Debug.Log(www.text);
        LoginGroup.SetActive(false);
        StartGroup.SetActive(true);
      }
    }
}
