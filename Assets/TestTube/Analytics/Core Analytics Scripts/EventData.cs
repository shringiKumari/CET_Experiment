
using System.Collections.Generic;

public class EventData
{

    /*
     * Each event which occurs contains a list of information objects
     */

	public List<Information> info = new List<Information> ();

	public EventData ()
	{

	}

    /*
     * Construct a new EventData object from an array of information.
     */

    public EventData(params Information[] i)
    {

        info = new List<Information>(i);

    }

    /*
     * Add a new piece of information to the event
     */

    public void Add (string title, string information)
	{

		info.Add (new Information (title, information));


	}

    public void Add(Information i)
    {

        info.Add(i);

    }






}
