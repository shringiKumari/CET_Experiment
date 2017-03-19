using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {

     [SerializeField] private GameObject gameStartScreen;
     // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

     public void Onclick () {
          
          Debug.Log("on clickmmmmmmmmmmmmmmm");
          gameStartScreen.SetActive(false);
     }

}
