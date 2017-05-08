using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WordTaskTrial : MonoBehaviour {

	private WordTaskCompletionPanel overallTask;
	public Text Stimulus;
	public InputField Response;
	public int Index;
	public string Fragment;
	private bool scrollLock = false;
	// Use this for initialization
	void Start () {
	//	OverallTask = this.GetComponentInParent<WordTaskCompletionPanel> ();


	}



	void OnGUI(){

	}

	// Update is called once per frame
	void Update () {
		// Remember to include event handler for 'tabbing'			
		if (EventSystem.current.currentSelectedGameObject == this.Response.gameObject) {

			if(Input.GetAxis("Mouse ScrollWheel")>0f){


				scrollLock = true;
			}


			if (Input.GetKeyDown (KeyCode.Tab)) {

				
				Response.DeactivateInputField();
	

			}


			if(scrollLock == false){
			RectTransform rt = (RectTransform)overallTask.MaskPanel.transform;

			if(this.transform.position.y < rt.rect.yMax){
				RectTransform rt2 = (RectTransform)overallTask.MainPanel.transform;
				rt2.position += new Vector3(0f,20f,0f);

			}
			}
		
		
		
		}
	}

	public void SetParameters(string text, WordTaskCompletionPanel main, int index){
		overallTask = main;
		Fragment = text;
		Stimulus.text = (index+1)+". "+text;
		Index = index;

		((RectTransform)transform).localScale = Vector3.one;

	}

	public void EditFinished(){

		if (!EventSystem.current.alreadySelecting) {
			if (Index < overallTask.Trials.Count - 1) {

				scrollLock = false;
				EventSystem.current.SetSelectedGameObject (overallTask.Trials [Index + 1].Response.gameObject);


		
		
		
		
			}                                                       
		}
	}

}
