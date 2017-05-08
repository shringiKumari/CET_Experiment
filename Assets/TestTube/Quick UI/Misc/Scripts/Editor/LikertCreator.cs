using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
public class LikertCreator : EditorWindow
{

    string questionnaireName = "";
    int numberOfQuestions = 1;
    int pointsOnScale = 5;
    string leftHandText = "Not at all";
    string rightHandText = "All the time";
    List<Question> questions = new List<Question>();

    [MenuItem("TestTube/UI/Create Questionnaire (Likert)")]

    static void Init()
    {

        // Get existing open window or if none, make a new one:
        LikertCreator window = (LikertCreator)EditorWindow.GetWindow(typeof(LikertCreator), false, "Likert Creator", true);
        window.minSize = new Vector2(640, 480);
        window.Show();


    }

    void OnGUI()
    {

        GUILayout.Label("General Parameters", EditorStyles.boldLabel);

        questionnaireName = EditorGUILayout.TextField("Questionnaire name", questionnaireName);
        leftHandText = EditorGUILayout.TextField("Left hand teft", leftHandText);
        rightHandText = EditorGUILayout.TextField("Left hand teft", rightHandText);


        pointsOnScale = EditorGUILayout.IntSlider("Points on scale", pointsOnScale, 1, 50);


        numberOfQuestions = EditorGUILayout.IntSlider("Number of questions", numberOfQuestions, 1, 50);

        while (questions.Count < numberOfQuestions)
        {

            Question q = new Question();

            questions.Add(q);

        }

        while (questions.Count > numberOfQuestions)
        {
            questions.RemoveAt(questions.Count - 1);
        }

        GUILayout.Label("Questions", EditorStyles.boldLabel);

        foreach (Question q in questions)
        {

            EditorGUILayout.BeginHorizontal();

            q.prompt = EditorGUILayout.TextField("Question", q.prompt);


            EditorGUILayout.EndHorizontal();

        }


        if (GUILayout.Button("Create questionnaire"))
        {

            GameObject questionnaire = (PrefabUtility.InstantiatePrefab(AssetDatabase.LoadAssetAtPath("Assets/TestTube/Quick UI/Panels/Likert Panel.prefab", typeof(GameObject)) as GameObject)) as GameObject;

            questionnaire.transform.SetParent(GameObject.Find("Blank UI").transform);

            LikertPanel qPanel = questionnaire.GetComponent<LikertPanel>();

            List<string> trialText = new List<string>();

            foreach(Question q in questions)
            {
                trialText.Add(q.prompt);
            }

            qPanel.Questions = trialText.ToArray();

            qPanel.name = questionnaireName;
            qPanel.NumbersOnLine = pointsOnScale;
            qPanel.LeftHandText = new string[] { leftHandText };
            qPanel.RightHandText = new string[] { rightHandText };

            qPanel.LikertTitle = questionnaireName;

            RectTransform r = ((RectTransform)questionnaire.transform);
            r.localPosition = Vector2.zero;
            r.localScale = Vector3.one;
            r.offsetMax = Vector2.zero;
            r.offsetMin = Vector2.zero;


        }


    }



}