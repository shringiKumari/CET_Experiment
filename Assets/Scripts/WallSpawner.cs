using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallSpawner : MonoBehaviour {

     public struct WallStruct
     {
          public GameObject wall;
          int stackHeight;
          public WallStruct(GameObject wall, int stackHeight)
          {
               this.wall = wall;
               this.stackHeight = stackHeight;
          }
     }

     public GameObject brick;
     public GameObject top;
     public GameObject player;
     public Slider competenceSlider;
     public Button apply;

     //private List<GameObject> wallList = new List<GameObject> ();
     private List<WallStruct> wallStructList = new List<WallStruct> ();

     private float brickX;
     private float brickHeight;

     public int brickStackLimit;
     private float lastProcessedCompetenceValue;

     // Use this for initialization
	void Start () {
		
	}

     void Awake () {

          //brickStackLimit should be a function of competence slider.
          float tempBrickStackLimit = brickStackLimit * competenceSlider.value;
          lastProcessedCompetenceValue = competenceSlider.value;
          brickStackLimit = Mathf.CeilToInt (tempBrickStackLimit);


          brickHeight = brick.GetComponent<SpriteRenderer>().sprite.bounds.size.y/6;
          Debug.Log (brickHeight);


          GameObject tempBrick = null;
          brickX = UnityEngine.Random.Range (player.transform.position.x + 5f, player.transform.position.x + 25f);

          //"i" limit should depend on competence
          int iCount = Mathf.CeilToInt(competenceSlider.value * 30); 

          for (int i =1; i<=iCount; i++) {

               brickX = brickX + UnityEngine.Random.Range(5, 15);
               int brickStackHeight = UnityEngine.Random.Range (0, brickStackLimit);

               GameObject wall = new GameObject();
               WallStruct W = new WallStruct(wall, brickStackHeight); 

               for (int j = 1; j <= brickStackHeight; j++) {
                    tempBrick = GameObject.Instantiate (brick);
                    Vector3 initialPosition = new Vector3 (brickX, GlobalConstants.bankHeight + (j-1) * brickHeight); 
                    tempBrick.transform.position = initialPosition;
                    tempBrick.transform.parent = W.wall.transform;
               }

               if (tempBrick != null) {
                    GameObject tempTop = GameObject.Instantiate (top);
                    Vector3 initialTopPosition = new Vector3 (tempBrick.transform.position.x, tempBrick.transform.position.y + 0.7f); 
                    tempTop.transform.position = initialTopPosition;
                    tempTop.transform.parent = W.wall.transform;
               }
               wallStructList.Add (W);
          }



     }
	
     public void OnClickApply() {
          if (lastProcessedCompetenceValue != competenceSlider.value) {
               
               lastProcessedCompetenceValue = competenceSlider.value;
          }
          
     }


     // Update is called once per frame
	void Update () {


          

		
	}
}
