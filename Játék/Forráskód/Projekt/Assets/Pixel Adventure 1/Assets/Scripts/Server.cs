using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Threading;
using System.Threading.Tasks;

public class Server : MonoBehaviour
{
	[SerializeField] public InputField Lusername;
	public Text id;
	[SerializeField] InputField Lpassword;
	[Space]
	[SerializeField] InputField Rusername;
	[SerializeField] InputField Rpassword;
	[SerializeField] InputField SecRpassword;
	[Space]
	[SerializeField] Text LerrorMessages;
	[SerializeField] Text RerrorMessages;
	[Space]
	[SerializeField] Button loginButton;
	[SerializeField] Button registerButton;

	public int skin = 0;
	public string name = "";





	public void OnLoginButtonClicked()
	{
		loginButton.interactable = false;
		StartCoroutine(getPont());
		StartCoroutine(getHalal());
		StartCoroutine(getLevel());
		StartCoroutine(Login());
	}
	public void OnRegisterButtonClicked()
	{
		registerButton.interactable = true;
		StartCoroutine(Register());
	}


	IEnumerator Login()
	{
		WWWForm form1 = new WWWForm();
		form1.AddField("jatekosnev", Lusername.text);
		form1.AddField("jatekosjelszo", Lpassword.text);
		WWW w = new WWW("http://localhost/unity/PHP/Login.php", form1);
		yield return w;

		if (w.error != null)
		{
			//-- van hibaüzenet -----
			LerrorMessages.text = "404 not found!";
			Debug.Log("<color=red>" + w.text + "</color>");//error
		}
		else
		{
			if (w.isDone)
			{
				if (w.text.Contains("error"))
				{
					LerrorMessages.text = "invalid username or password!";
					Debug.Log("<color=red>" + w.text + "</color>");//error
				}
				else if (w.text.Contains("0"))
				{
					//Bejelentkezés után -> főmenü
					//-- id???
					PlayerPrefs.SetString("Lusername", Lusername.text);
					PlayerPrefs.Save();
					SceneManager.LoadSceneAsync("Start Menu");
				}
				else
				{
					LerrorMessages.text = "Valami nem kóser.";
					Debug.Log("<color=red>" + w.text + "</color>");//error

				}
			}
		}

		loginButton.interactable = true;

		w.Dispose();
	}
	IEnumerator Register()
	{
		WWWForm form = new WWWForm();
		form.AddField("jatekosnev", Rusername.text);
		form.AddField("jatekosjelszo", Rpassword.text);
		WWW www = new WWW("http://localhost/unity/PHP/RegisterUser.php", form);
		yield return www;
		if (www.text == "0")
		{
			Debug.Log("Sikeres regisztráció");
			RerrorMessages.text = "Sikeres regisztráció";
			Lusername.text = Rusername.text;
			Lpassword.text = Rpassword.text;

		}
		else if (www.text == "1")
		{
			Debug.Log("Sikertelen regisztráció. Error #" + www.text);
			RerrorMessages.text = "Sikertelen regisztráció.";
			registerButton.interactable = true;
		}
	}
	public void VerifyInput()
	{
		//registerButton.interactable = (Rusername.text.Length >= 5 && Rpassword.text.Length >= 8 && Rpassword.text == SecRpassword.text);
	}
	public void Sleep()
	{
		Thread.Sleep(1000);
	}
	IEnumerator getPont()
	{
		WWWForm form = new WWWForm();
		form.AddField("jatekosnev", Lusername.text);
		WWW wwww = new WWW("http://localhost/unity/PHP/getPontszam.php", form);
		yield return wwww;
		if (wwww.text == "00")
		{
			Debug.Log(wwww.text);
		}
		else
		{
			PlayerPrefs.SetString("pont", wwww.text);
			PlayerPrefs.Save();
			Debug.Log("A pont szöveg: " + wwww.text);
		}
	}
	IEnumerator getHalal()
	{
		WWWForm form = new WWWForm();
		form.AddField("jatekosnev", Lusername.text);
		WWW wwww = new WWW("http://localhost/unity/PHP/getHalalszam.php", form);
		yield return wwww;
		if (wwww.text == "00")
		{
			Debug.Log(wwww.text);
		}
		else
		{
			PlayerPrefs.SetString("halal", wwww.text);
			PlayerPrefs.Save();
			Debug.Log("A halal szöveg: " + wwww.text);
		}
	}
	public void teszt()
	{
		Debug.Log("Fut");
	}
	public IEnumerator setHalal(string nev, string halal)
	{
		WWWForm form = new WWWForm();
		form.AddField("jatekosnev", nev);
		form.AddField("halalokszama", halal);
		WWW wwwsethalal = new WWW("http://localhost/unity/PHP/setHalalszam.php", form);
		yield return wwwsethalal;
		Debug.Log(wwwsethalal.text);
		if (wwwsethalal.text == "0")
		{
			Debug.Log("Sikeres halálszám frissítés");
		}
		else if (wwwsethalal.text == "1")
		{
			Debug.Log("Sikertelen halálszám frissítés. Error #" + wwwsethalal.text);
		}
	}
	public IEnumerator setPontszam(string nev, string pont)
	{
		WWWForm form = new WWWForm();
		form.AddField("jatekosnev", nev);
		form.AddField("pontszam", pont);
		WWW wwwsetpont = new WWW("http://localhost/unity/PHP/setPontszam.php", form);
		yield return wwwsetpont;
		Debug.Log(wwwsetpont.text);
		if (wwwsetpont.text == "0")
		{
			Debug.Log("Sikeres pontszám frissítés");
		}
		else if (wwwsetpont.text == "1")
		{
			Debug.Log("Sikertelen pontszám frissítés. Error #" + wwwsetpont.text);
		}
	}
	public IEnumerator setLevels(string nev, string level)
	{
		WWWForm form = new WWWForm();
		form.AddField("jatekosnev", nev);
		form.AddField("Levels", level);
		WWW wwwsetlevel = new WWW("http://localhost/unity/PHP/setLevel.php", form);
		yield return wwwsetlevel;
		Debug.Log(wwwsetlevel.text);
		if (wwwsetlevel.text == "0")
		{
			Debug.Log("Sikeres szint frissítés");
		}
		else if (wwwsetlevel.text == "1")
		{
			Debug.Log("Sikertelen szint frissítés. Error #" + wwwsetlevel.text);
		}
	}

	IEnumerator getLevel()
	{
		WWWForm form = new WWWForm();
		form.AddField("jatekosnev", Lusername.text);
		WWW wwwws = new WWW("http://localhost/unity/PHP/getLevel.php", form);
		yield return wwwws;
		if (wwwws.text == "00")
		{
			Debug.Log(wwwws.text);
		}
		else
		{
			PlayerPrefs.SetString("ReachedIndex", wwwws.text);
			PlayerPrefs.Save();
			Debug.Log("A ReachedIndex szöveg : " + wwwws.text);
		}
	}

	public void applySkin()
	{
		StartCoroutine(getSkin());
	}
	public IEnumerator setSkin(string nev, int skin)
	{
		WWWForm form = new WWWForm();
		form.AddField("jatekosnev", nev);
		form.AddField("skin", skin);
		WWW wwwsetskin = new WWW("http://localhost/unity/PHP/setSkin.php", form);
		yield return wwwsetskin;
		Debug.Log(wwwsetskin.text);
		if (wwwsetskin.text == "0")
		{
			Debug.Log("Sikeres skin frissítés");
		}
		else if (wwwsetskin.text == "1")
		{
			Debug.Log("Sikertelen skin frissítés. Error #" + wwwsetskin.text);
		}
	}

	IEnumerator getSkin()
	{
		WWWForm form = new WWWForm();
		form.AddField("jatekosnev", PlayerPrefs.GetString("Lusername"));
		WWW wwwws = new WWW("http://localhost/unity/PHP/getSkin.php", form);
		yield return wwwws;
		if (wwwws.text == "00")
		{
			Debug.Log(wwwws.text);
		}
		else
		{
			int skinID = int.Parse(wwwws.text);
			PlayerPrefs.SetInt("skinId", skinID);
			PlayerPrefs.Save();
			Debug.Log("A Skin szöveg : " + wwwws.text);
		}
	}
}

