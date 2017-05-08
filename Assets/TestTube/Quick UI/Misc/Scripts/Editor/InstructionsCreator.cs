using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UI;

public class InstructionsCreator : EditorWindow
{

    string instructionsName = "Instructions panel";
    string instructions = "Instructions go here";
    bool allowNext = true;

    List<Question> questions = new List<Question>();

    [MenuItem("TestTube/UI/Create Instructions Panel")]

    static void Init()
    {

        // Get existing open window or if none, make a new one:
        InstructionsCreator window = (InstructionsCreator)EditorWindow.GetWindow(typeof(InstructionsCreator), false, "Instructions Creator", true);
        window.minSize = new Vector2(640, 480);
        window.Show();


    }

    void OnGUI()
    {

        GUILayout.Label("General Parameters", EditorStyles.boldLabel);

        instructionsName = EditorGUILayout.TextField("Instructions name", instructionsName);
        allowNext =  EditorGUILayout.Toggle("Allow user to move to next panel", allowNext);

        instructions = EditorGUILayout.TextArea(instructions, GUILayout.Height(300));
       if( GUILayout.Button("Create instructions"))
        {
            GameObject instructionsPanel = (PrefabUtility.InstantiatePrefab(AssetDatabase.LoadAssetAtPath("Assets/TestTube/Quick UI/Panels/Instructions Panel.prefab", typeof(GameObject)) as GameObject)) as GameObject;

            instructionsPanel.GetComponent<Instructions>().AllowNext = allowNext;

            instructionsPanel.transform.SetParent(GameObject.Find("Blank UI").transform);
            instructionsPanel.name = instructionsName;

            instructionsPanel.transform.Find("Instructions").GetComponent<Text>().text = instructions;


            RectTransform r = ((RectTransform)instructionsPanel.transform);
            r.localPosition = Vector2.zero;
            r.localScale = Vector3.one;
            r.offsetMax = Vector2.zero;
            r.offsetMin = Vector2.zero;

        }



    }
}