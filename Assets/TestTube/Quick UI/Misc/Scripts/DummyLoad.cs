using UnityEngine;
using System.Collections;

public class DummyLoad : MonoBehaviour
{

    public float LoadLength = 5f;
    private UISequencer UIController;
    private bool Accepted = false;
    // Use this for initialization
    void Start()
    {
        UIController = this.gameObject.GetComponentInParent<UISequencer>();

    }

    // Update is called once per frame
    void Update()
    {

        if (isActiveAndEnabled) { 
        LoadLength -= Time.deltaTime;
        }

        if (LoadLength < 0f) { 
            if (!Accepted)
            {
                Accepted = true;
                UIController.Next();
            }
        }
    }
    }

