using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class EventHandler : MonoBehaviour {

	public Color red;
	public Color green;
	public Color blue;

	public class MessageEventArgs : EventArgs {
		public String Message { get; set; }
		
		public MessageEventArgs(String msg) {
			Message = msg;
		}
	}

	public delegate void GameEventHandler(object sender, MessageEventArgs e);

	public event GameEventHandler GameOver;
	public event GameEventHandler RedPortal;
	public event GameEventHandler BluePortal;
	public event GameEventHandler GreenPortal;
	public event GameEventHandler InitPlatforms;

	public void OnGameOver(MessageEventArgs e) {
		if (GameOver != null)
			GameOver (this, e);
	}

	void OnNewGameClick() {
		Application.LoadLevel ("MainScene");	
	}

	void OnExitClick() {
		Application.Quit ();
	}

	void RetryLevel() {
		Application.LoadLevel (Application.loadedLevelName);
	}
	
	void MainMenu() {
		Application.LoadLevel ("MainMenu");
	}

	void InitializePlatforms(String color) {
		if (InitPlatforms != null)
			InitPlatforms (this, new MessageEventArgs(color));
	}

	void SetColor(PlatformController sender) {
		if (sender.colorString == "red")
			sender.SendMessage ("SetColor", red);
		else if (sender.colorString == "green")
			sender.SendMessage ("SetColor", green);
		else if (sender.colorString == "blue")
			sender.SendMessage ("SetColor", blue);
	}

}
