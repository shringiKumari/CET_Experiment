using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour {


	
	public string[] LevelToLoadByCondition;
	public Text loadingPercent;
	
	string LevelToLoad;
	
	
	void Awake(){
		
		this.gameObject.SetActive(false);
		
	}


	// Use this for initialization
	void Start () {
		LevelToLoad = LevelToLoadByCondition[0];
		float f = Application.GetStreamProgressForLevel(LevelToLoad)*100f;
		string s = f.ToString ("n0");
		s = s + "%";

		Analytics.LogWithTimestamp ("Level Loaded",s);

		Debug.Log (s);

	}
	
	// Update is called once per frame
	void Update () {

		
		float f = Application.GetStreamProgressForLevel(LevelToLoad)*100f;
		string s = f.ToString ("n0");
		loadingPercent.text = "Loading: "+s+"%";
		
		if(Application.CanStreamedLevelBeLoaded(LevelToLoad)){
			Analytics.LogWithTimestamp ("Level Loaded",s+"%");

				Application.LoadLevel(LevelToLoad);
			Debug.Log (s+"%");
		}

    

	}
}
