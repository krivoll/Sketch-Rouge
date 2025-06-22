using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string doorID; 
    public string sceneName;
    public string linkedSceneName;
    public string linkedDoorID;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        doorID = gameObject.name.Substring(4);
        sceneName = SceneManager.GetActiveScene().name;
        
        if (TravelManager.Instance.incomingDoorID == null) return;
        
        else if (doorID == getOppositeDoor(TravelManager.Instance.incomingDoorID)) {
        // I’m the door the player just arrived at.
        linkedDoorID = TravelManager.Instance.incomingDoorID;
        linkedSceneName = TravelManager.Instance.incomingSceneName;

        // Store *my own info* in TravelManager for the return trip
        TravelManager.Instance.outgoingDoorID = doorID;
        TravelManager.Instance.outgoingSceneName = SceneManager.GetActiveScene().name;
    }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public string getOppositeDoor(string str) {
    if (str == null) {return "";}
    if (str.Contains("North")) {return "South";}
    if (str.Contains("East")) {return "West";}
    if (str.Contains("South")) {return "East";}
    if (str.Contains("West")) {return "North";}
    return "";
   
  }
}
