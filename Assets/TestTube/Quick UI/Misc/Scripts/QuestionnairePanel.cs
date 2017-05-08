using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class QuestionnairePanel : MonoBehaviour
{
    public bool centringOnNext;
    public Button NextButton;
    public string QuestionnaireTitle;
    public GameObject QuestionPrefab;

    public Scrollbar Scroll;
    private Transform trialTarget;
    private bool centringOnTrial = false;

    public GameObject QuestionHolderPanel;
    public GameObject WhitespaceMask;

    public List<QuestionnaireTrial> Trials;
    public List<QuestionnaireTrial> DoneTrials;

    public Question[] Questions;
     
   float timeFirstAnswered = -1f;

    // Use this for initialization
    void Start()
    {

        Analytics.LogWithTimestamp("Questionnaire Task Begun", this.name);

        Trials = new List<QuestionnaireTrial>();
        DoneTrials = new List<QuestionnaireTrial>();

        for (int i = 0; i < Questions.Length; i++)
        {
           
            Question q = Questions[i];

            NewQuestion(i, q.prompt, q.textbox, q.options, q.forceCompletion);


        }

        NextButton.interactable = false;
        NextButton.onClick.AddListener(EndQuestionnaire);
        NextButton.transform.parent.SetSiblingIndex(NextButton.transform.parent.parent.childCount-1);


    }


    public void NewQuestion(int index, string prompt, bool textbox, string[] options, bool forceCompletion)
    {

        GameObject trialObject = GameObject.Instantiate<GameObject>(QuestionPrefab);
        trialObject.transform.SetParent(QuestionHolderPanel.transform);
        QuestionnaireTrial t = trialObject.GetComponent<QuestionnaireTrial>();
        Trials.Add(t);

        t.Setup(index, prompt, this, !textbox, options, forceCompletion);

    }






    public void QuestionAnswered(QuestionnaireTrial trial)
    {
        if (timeFirstAnswered < 0f)
        {
            timeFirstAnswered = Time.time;
        }
        Trials.Remove(trial);

        if (DoneTrials.Contains(trial) == false)
        {
            DoneTrials.Add(trial);
        }

        bool flag = false;

        foreach(QuestionnaireTrial t in Trials)
        {
            if(t.ForceCompletionText.enabled == true)
            {
                flag = true;

                centringOnTrial = true;
                trialTarget = t.gameObject.transform;

                break;
            }
        }


        if (!flag)
        {

            NextButton.interactable = true;
            centringOnNext = true;

            return;
        }


    }


    public void EndQuestionnaire()
    {

        foreach(QuestionnaireTrial t in DoneTrials)
        {
            Process(t);
        }

        EventData e = new EventData();

        float calc = Time.time - timeFirstAnswered;

        e.Add("Time", "" + Time.time);
        e.Add("Questionnaire Ended", this.name);
        e.Add("Time taken", "" + calc);


        Analytics.LogEvent(e);


        UISequencer.current.Next();
    }

    public void Process(QuestionnaireTrial trial)
    {
        EventData e = new EventData();
        e.Add(Information.time);
        e.Add("Index", trial.Index + "");
        e.Add("Question", trial.Prompt);
        e.Add("Response", "" + trial.AnswerString);
        Analytics.LogEvent(e);
        Analytics.LogCritical(QuestionnaireTitle + "_" + trial.Index,trial.AnswerString);

    }




    float oldTrialPosition;
    float resetCentring;


    private void Update()
    {

        if(centringOnTrial && Mathf.Abs(trialTarget.transform.position.y - oldTrialPosition) < 5f)
        {
            resetCentring += Time.deltaTime;
        }

        if (!centringOnTrial)
        {
            resetCentring = 0f;
        }

        if (resetCentring > 0.5f)
        {
            centringOnTrial = false;
        }

  
        if (centringOnTrial)
        {

                oldTrialPosition = trialTarget.transform.position.y;

            if (trialTarget.transform.position.y  < (QuestionHolderPanel.transform.parent.position.y+40))
            {
                Scroll.value -= (Time.deltaTime * (500f/QuestionHolderPanel.GetComponent<RectTransform>().rect.height));
            }
            else if (trialTarget.transform.position.y - trialTarget.GetComponent<RectTransform>().rect.height > QuestionHolderPanel.transform.parent.position.y + (QuestionHolderPanel.transform.parent.GetComponent<RectTransform>().rect.height/2f))
            {
                Scroll.value += (Time.deltaTime * (500f/QuestionHolderPanel.GetComponent<RectTransform>().rect.height));
            }
            else
            {
                centringOnTrial = false;
            }
        }

        if (centringOnNext)
        {
            if (NextButton.transform.position.y < 135f)
            {
                Scroll.value -= (Time.deltaTime * 1f);
            }
        }


    }


}
