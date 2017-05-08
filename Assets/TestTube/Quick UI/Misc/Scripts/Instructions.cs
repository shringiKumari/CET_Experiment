using UnityEngine;
using System.Collections;

public class Instructions : MonoBehaviour
{
    public bool AllowNext = true;
    private UISequencer UIController;
    private bool Accepted = false;
  


    // Use this for initialization
    void Start()
    {

          Analytics.LogCritical ("test", "testVal");

        if (AllowNext)
        {
            this.transform.Find("Loading Text").gameObject.SetActive(true);
        }

        UIController = this.gameObject.GetComponentInParent<UISequencer>();

    }

    // Update is called once per frame
    void Update()
    {

        if (AllowNext) { 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!Accepted)
            {
                Accepted = true;
                UIController.Next();
            }
        }
        }
    }
}
