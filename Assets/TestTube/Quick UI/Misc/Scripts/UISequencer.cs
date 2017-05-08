using UnityEngine;
using System.Collections;

public class UISequencer : MonoBehaviour {

public int index;
	public static UISequencer current;

public GameObject[] panels;

	// Use this for initialization
	void Start () {
		current = this;
int tcount = transform.childCount;

panels = new GameObject[tcount];

for(int i = 0; i<tcount; i++){
panels[i] = transform.GetChild (i).gameObject;
}

}


	
public void Next(){

index++;
Analytics.LogWithTimestamp ("UI Index Set", index + "");

}


    public void Previous()
    {
        if (index > 0)
        {
            index--;
        }
        Analytics.LogWithTimestamp("UI Index Set", index + "");

    }

    // Update is called once per frame
    void Update () {
	
		if (Cursor.lockState != CursorLockMode.None) {
			Cursor.lockState = CursorLockMode.None;
		}
		if (Cursor.visible != true) {
			Cursor.visible = true;
		}

for(int i = 0; i<panels.Length; i++){

if(panels[i].activeSelf){
if(i!=index){
panels[i].SetActive (false);
}
}
else{
if(i==index){
					
panels[i].SetActive (true);

}
}

}


	}
}
