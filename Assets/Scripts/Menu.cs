using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public Texture2D backgruondTexture;
	public GameObject game;
	public GameObject menu;

	private int state;

	public void Start() {
		state = 0;
	}

	void OnGUI() {
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgruondTexture);
		int middle = Screen.width / 2;
		int vertical = Screen.height / 2;

		if (state == 0) {
			if (GUI.Button(new Rect(middle-100, vertical, 200, 20), "Pradėti"))
				StartClicked();
			if (GUI.Button(new Rect(middle-100, vertical+30, 200, 20), "Instrukcijos")) {
				state = 1;
			}
			if (GUI.Button(new Rect(middle-100, vertical+60, 200, 20), "Išeiti"))
				QuitClicked();
		}
		else if (state == 1) {
			if (GUI.Button(new Rect(middle-100, vertical, 200, 20), "Grįžti"))
				state = 0;
			string rules = @"<b>Taisyklės</b>

Žaidėjas turi ribotą kiekį laiko, kuriam pasibaigus, jis priverstas baigti lenktynes. Mieste išdėstyti kontrolės punktai, kuriuos pasiekus, žaidėjo laikas pratęsiamas. Žaidimo tikslas -- kuo ilgiau išlikti lenktynėse.

<b>Kontrolės punktas</b>

Kelią iki artimiausio kontrolės punkto rodo ekrano viršuje esanti rodyklė. Kontrolės punktai yra vienkartiniai, t.y., po aktyvavimo jie išnyksta. Kontrolės punktui išnykus, kitoje miesto dalyje atsiranda naujas kontrolės punktas.

<b>Valdymas</b>

Skraidyklė valdoma klaviatūra.
Naudojami šie klavišai:
	* A ir D sukioja skraidyklę į šonus.
	* S ir W kreipia skraidyklę aukštyn ir žemyn.
	* J ir L varto skraidyklę į šonus.
	* I ir K kontroliuoja skraidyklės greitį.
";
			GUI.Label(new Rect(middle-400, vertical+30, 800, 2000), rules);

		}
	}

	void StartClicked() {
		game.SetActive(true);
		menu.SetActive(false);
	}

	void QuitClicked() {
		Application.Quit();
	}
}
