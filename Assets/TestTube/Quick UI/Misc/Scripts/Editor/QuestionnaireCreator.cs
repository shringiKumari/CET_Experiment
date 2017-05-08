using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
public class QuestionnaireCreator : EditorWindow
{

    string questionnaireName = "";
    int numberOfQuestions = 1;

    List<Question> questions = new List<Question>();

    [MenuItem("TestTube/UI/Create Questionnaire (non-Likert)")]

    static void Init()
    {

        // Get existing open window or if none, make a new one:
        QuestionnaireCreator window = (QuestionnaireCreator)EditorWindow.GetWindow(typeof(QuestionnaireCreator),false,"Questionnaire Creator",true);
        window.minSize = new Vector2(640, 480);
        window.Show();


    }

    void OnGUI()
    {

        GUILayout.Label("General Parameters", EditorStyles.boldLabel);

        questionnaireName = EditorGUILayout.TextField("Questionnaire name", questionnaireName);

        numberOfQuestions = EditorGUILayout.IntSlider("Number of questions", numberOfQuestions,1,50);

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

        foreach(Question q in questions)
        {

            EditorGUILayout.BeginHorizontal();

            q.prompt = EditorGUILayout.TextField("Question", q.prompt);

            if (!q.textbox)
            {

                string qoptions="";

                foreach(string s in q.options)
                {
                    qoptions += s;
                    qoptions += ",";

                }

                qoptions = EditorGUILayout.TextField("Multiple choice options", qoptions);

                q.options = qoptions.Split(",".ToCharArray(), System.StringSplitOptions.RemoveEmptyEntries);

                

            }
            q.textbox = EditorGUILayout.Toggle("Text input", q.textbox);
            q.forceCompletion = EditorGUILayout.Toggle("Force completion", q.forceCompletion);

            EditorGUILayout.EndHorizontal();

        }


        if (GUILayout.Button("Create questionnaire"))
        {

            GameObject questionnaire = (PrefabUtility.InstantiatePrefab(AssetDatabase.LoadAssetAtPath("Assets/TestTube/Quick UI/Panels/Questionnaire Panel.prefab", typeof(GameObject)) as GameObject)) as GameObject;

            questionnaire.transform.SetParent(GameObject.Find("Blank UI").transform);

            QuestionnairePanel qPanel = questionnaire.GetComponent<QuestionnairePanel>();

            qPanel.Questions = questions.ToArray();

            qPanel.name = questionnaireName;
            qPanel.QuestionnaireTitle = questionnaireName;

            RectTransform r = ((RectTransform)questionnaire.transform);
            r.localPosition = Vector2.zero;
            r.localScale = Vector3.one;
            r.offsetMax = Vector2.zero;
            r.offsetMin = Vector2.zero;
 

        }


    }



}