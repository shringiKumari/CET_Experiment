using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InformedConsentPanel : MonoBehaviour {


	bool accepted = false;
	bool runOnceFlag = true;

	private UISequencer UIController;
	public Button AcceptButton;


	// Use this for initialization
	void Start () {

        AcceptButton.interactable = true;

        UIController = this.gameObject.GetComponentInParent<UISequencer>();


}


	private void greenButton(Button button){

		var newGreen = new Color(0f,0.7f,0f);
		var colorBlock = button.colors;
		colorBlock.normalColor = newGreen;	
		colorBlock.highlightedColor = newGreen;
		colorBlock.pressedColor = Color.green;
		button.colors = colorBlock;

	}


public void Accept(){

        /*
         * Any additional code to reject participants on the basis of their answer to 
         * demographics questions could go here.
         */

accepted = true;

}

	// Update is called once per frame
	void Update () {

			

		if(accepted && runOnceFlag){
			
			if(Analytics.Get ().SessionSet){

				runOnceFlag = false;
													
	
				UIController.Next ();
			}
			
		}



	}
}
