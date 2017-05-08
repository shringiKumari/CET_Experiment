using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LikertTrial : MonoBehaviour {


    public int Index;
    public int Response;
	public bool Reversed;
	public string Stimulus;
    
  
    public Text previousAnswer;
	public Text Question, LeftEnd, RightEnd;
	public GameObject NumberLine;
	public GameObject NumberPrefab;
    public int OriginalIndex;
	private LikertPanel likertPanel;

	public void Setup(int index, string question, string leftEnd, string rightEnd,  int numbers,LikertPanel lp, int oIndex){

        OriginalIndex = oIndex;
		Stimulus = question;
		Index = index;
		Question.text = (index+1)+". "+question;
		LeftEnd.text = leftEnd;
		RightEnd.text = rightEnd;
		likertPanel = lp;

		for(int i = 1; i<numbers+1; i++){
			
			GameObject g = GameObject.Instantiate (NumberPrefab);
			g.transform.SetParent (NumberLine.transform);
			
			g.GetComponentInChildren<Text>().text = ""+i;
			g.GetComponent<Button>().onClick.AddListener(()=> Notify(g));
			
			
		}

		RectTransform r = (RectTransform)this.transform;
		r.localScale = Vector3.one;

	}


	public void Notify(GameObject g){


        if (previousAnswer != null)
        {

            previousAnswer.color = Color.black;



        }



        previousAnswer = g.GetComponentInChildren<Text>();
        
        previousAnswer.color = Color.red;


        int i = int.Parse (g.GetComponentInChildren<Text>().text);
        Response = i;
		likertPanel.QuestionAnswered (this, i);



	}

	
	// Update is called once per frame
	void Update () {

        }
}
