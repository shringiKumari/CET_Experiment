
using UnityEngine;
using System.Runtime.InteropServices;

public class TwitterButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Follow()
    {

        openWindow("https://twitter.com/davidzendle/");
        openWindow("https://twitter.com/davidzendle/");


        //        Application.OpenURL("https://youtu.be/PmbacKaXzw4");

        //        Application.OpenURL("https://twitter.com/davidzendle/");

    }


    [DllImport("__Internal")]
    private static extern void openWindow(string url);

}
