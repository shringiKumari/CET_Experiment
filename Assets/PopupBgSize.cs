using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupBgSize : MonoBehaviour {

     private SpriteRenderer sr;

	// Use this for initialization
	void Start () {

          //float width = Screen.width;
          //gameObject.GetComponent<RectTransform> ().rect.width = width;
          //gameObject.GetComponent<RectTransform> ().rect.height = Screen.height;
          sr = GetComponent<SpriteRenderer> ();


          if(sr == null) return;

          transform.localScale = new Vector3(1,1,1);

          float width = sr.sprite.bounds.size.x;
          float height = sr.sprite.bounds.size.y;


          float worldScreenHeight = Camera.main.orthographicSize * 2.0f;
          float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

          Vector3 spriteSize = new Vector3(1,1,1);
          spriteSize.x = worldScreenWidth / width;
          spriteSize.y = worldScreenHeight / height;
          transform.localScale = spriteSize;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
