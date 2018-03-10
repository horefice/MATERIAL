using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour {

	public GameObject button_Settings, button_Rotation, panel_Settings;

	// Use this for initialization
	public void Start () {
		OnCloseSettings ();
	}

	// button_Settings.OnClick
	public void OnSettings () {
		panel_Settings.SetActive (true);
		button_Settings.SetActive (false);
		button_Rotation.SetActive (false);
	}

	// button_CloseSettings.OnClick
	public void OnCloseSettings () {
		panel_Settings.SetActive (false);
		button_Settings.SetActive (true);
		button_Rotation.SetActive (true);
	}
}

