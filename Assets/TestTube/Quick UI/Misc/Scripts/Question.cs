
using System;

[Serializable]
public class Question
{
    public string prompt = "";
    public bool textbox;
    public bool forceCompletion;
    public string[] options;

    public Question()
    {

        forceCompletion = true;
        textbox = false;
        options = new string[] { "" };

    }


}