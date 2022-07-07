using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class DataInserter : MonoBehaviour
{
  public InputField inputUserName;
	public InputField inputPassword;
	public InputField inputEmail;

  public GameObject SignUpGroup;
  public GameObject StartGroup;

  WWW www;
	string CreateUserURL = "https://unity-db-kutsm.run.goorm.io/Unity_DB/register.php";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateUser()
	  {
      string username = inputUserName.text;
      string password = inputPassword.text;
      string email = inputEmail.text;
      Debug.Log(username);
      Debug.Log(password);
      Debug.Log(email);
      
      WWWForm form = new WWWForm ();
      form.AddField ("usernamePost", username);
      form.AddField ("emailPost", email);
      form.AddField ("passwordPost", password);

      StartCoroutine (Send(form));
    }

    IEnumerator Send(WWWForm wF){
      www = new WWW(CreateUserURL, wF);
      yield return www;
      if(www.text == "저장성공"){
        SignUpGroup.SetActive(false);
        StartGroup.SetActive(true);
      }
    }
}
