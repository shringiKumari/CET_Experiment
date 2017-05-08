using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class QuestionnaireTrial : MonoBehaviour
{

    public int Index;
    public string AnswerString;

    public Text QuestionText;
    public Text ForceCompletionText;
    public Text Tick;
    public bool ForceCompletion = false;

    public InputField MyInputField;
    public Dropdown MyDropdown;

    public string Prompt;

    private QuestionnairePanel parent;
    private LayoutElement layout;

    private void Update()
    {

        layout.minHeight = ((RectTransform)QuestionText.transform).rect.height + 120;

    }

    public void Setup(int index, string question, QuestionnairePanel parent, bool dropdown, string[] dropdownOptions, bool forceCompletion)
    {
        ForceCompletion = forceCompletion;

        this.parent = parent;
        Prompt = question;

        Index = index;

        QuestionText.text = (index + 1) + ". " + question;

        if (!dropdown)
        {

            MyInputField.gameObject.SetActive(true);
            MyDropdown.gameObject.SetActive(false);
            MyInputField.onEndEdit.AddListener(delegate { TrialFinished(MyInputField.text); });

        }

        else
        {



            MyInputField.gameObject.SetActive(false);
            MyDropdown.gameObject.SetActive(true);

            MyDropdown.options.Add(new Dropdown.OptionData(""));

            foreach (string s in dropdownOptions)
            {
                MyDropdown.options.Add(new Dropdown.OptionData(s));
            }


            //  MyDropdown.One.AddListener(delegate { TrialFinished(MyDropdown.options[MyDropdown.value].text); });
            MyDropdown.onValueChanged.AddListener(delegate { TrialFinished(MyDropdown.value); });
        }

        if (forceCompletion)
        {
            ForceCompletionText.gameObject.SetActive(true);
        }
        else
        {
            ForceCompletionText.gameObject.SetActive(false);
        }

        Tick.gameObject.SetActive(false);



        RectTransform r = (RectTransform)this.transform;
        r.localScale = Vector3.one;

        layout = GetComponent<LayoutElement>();


    }


    int oldValue = 0;

    public void TrialFinished(int i)
    {
        string answer = MyDropdown.options[MyDropdown.value].text;


        if (i > 0)
        {
            oldValue = i;
            TrialFinished(answer);
        }
        else
        {
            MyDropdown.value = oldValue;
        }

    }

    public void TrialFinished(string answer)
    {
        Tick.gameObject.SetActive(true);
        AnswerString = answer;
        parent.QuestionAnswered(this);

    }


}
