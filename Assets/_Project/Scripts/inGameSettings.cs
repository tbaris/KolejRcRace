using UnityEngine;
using System.Collections;

public class inGameSettigns : MonoBehaviour {

	public AudioSource ses_kaynagi;
	public Resolution[] resolutions;
	public GameSettings gameSettings;

	void Start () {
		gameSettings = new GameSettings();
		resolutions = Screen.resolutions;
		//string jsonData = JsonUtility.ToJson(gameSettings, true);
		//gameSettings = JsonUtility.FromJson<GameSettings>(File.ReadAllText(Application.persistentDataPath + "/gamesettings.json"));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
