using UnityEngine;

public class Information{

    /*
     * A piece of information consists of two strings.
     */

    public string title;
    public string info;


    public Information(string informationTitle, string informationValue)
    {
        this.title = informationTitle;
        this.info = informationValue;

    }

    /*
     * Static helper method for quickly grabbing a timestamp
     */

    public static Information time
    {

        get
        {
            return new Information("time", Time.time + "");
        }

    }

}
