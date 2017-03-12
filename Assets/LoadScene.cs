using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	[SerializeField] private GameObject levelStart;
	[SerializeField] private GameObject enemySpawner;
	[SerializeField] private GameObject gameUI;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

     public void OnClick () {
          gameUI.SetActive(true);
		  enemySpawner.SetActive(true);
		  levelStart.SetActive(false);

     }
}
