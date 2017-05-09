using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartGame : MonoBehaviour {

     [SerializeField] private GameObject gameStartScreen;
     [SerializeField] private Pauser pauser;

     // Use this for initialization
	void Start () {
          pauser.Pause (true);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

     public void Onclick () {


         
          SceneManager.LoadScene("Level", LoadSceneMode.Single);
          gameStartScreen.SetActive(false);
          pauser.Pause (false);
     }

}
