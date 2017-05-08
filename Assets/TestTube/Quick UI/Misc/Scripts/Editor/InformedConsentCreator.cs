using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UI;

public class InformedConsentCreator : EditorWindow
{

    string consentInfo = "Thanks for taking part in this experiment! This is being run by Dr. David Zendle from the University of York. In this experiment you will play a rolling ball game. \n This should take less than 5 minutes in total.Your data will be completely anonymous.We intend to publish findings based on it but you will never be able to be linked back to the data when it is published. \n You must be 18 or over to take part in this experiment.If you still want to take part click 'Accept' to begin.";



   List<Question> questions = new List<Question>();

    [MenuItem("TestTube/UI/Create Informed Consent Panel")]

    static void Init()
    {

        // Get existing open window or if none, make a new one:
        InformedConsentCreator window = (InformedConsentCreator)EditorWindow.GetWindow(typeof(InformedConsentCreator), false, "Informed Consent Creator", true);
        window.minSize = new Vector2(640, 480);
        window.Show();


    }

    void OnGUI()
    {

        GUILayout.Label("General Parameters", EditorStyles.boldLabel);

        consentInfo = EditorGUILayout.TextArea(consentInfo, GUILayout.Height(300));
        if (GUILayout.Button("Create informed consent screen"))
        {

            GameObject consentPanel = (PrefabUtility.InstantiatePrefab(AssetDatabase.LoadAssetAtPath("Assets/TestTube/Quick UI/Panels/Informed Consent Panel.prefab", typeof(GameObject)) as GameObject)) as GameObject;

            consentPanel.transform.SetParent(GameObject.Find("Blank UI").transform);
            consentPanel.transform.SetAsFirstSibling();
            consentPanel.name = "Informed Consent";

            consentPanel.transform.Find("Consent Text").GetComponent<Text>().text = consentInfo;


            RectTransform r = ((RectTransform)consentPanel.transform);
            r.localPosition = Vector2.zero;
            r.localScale = Vector3.one;
            r.offsetMax = Vector2.zero;
            r.offsetMin = Vector2.zero;

        }



    }
}