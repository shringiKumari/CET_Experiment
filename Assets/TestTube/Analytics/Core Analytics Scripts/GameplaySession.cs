using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GameplaySession {

/*
 * Class for holding a specific gaming session
 */

public int ID; // An integer defining a unique ID for the session - this is retrieved from the server via PHP
public int gameID; // An integer defining the game that is being played

public bool InformationPushed = false; // Have the details of this specific session been pushed to the server yet? (i.e. demographics)
public List<Information> DemographicsAnswers = new List<Information>();
public List<Information> AdditionalInformation = new List<Information>();

public GameplaySession(int sessionID, int gID){
ID = sessionID;
gameID = gID;
}

public void AddDemographic(string title, string info){DemographicsAnswers.Add (new Information(title, info));}
public void AddInfo(string title, string info){AdditionalInformation.Add (new Information(title, info));}
	

public void SetInformation(List<Information> Demo, List<Information> Additional){

DemographicsAnswers = Demo;
AdditionalInformation = Additional;


}

}
