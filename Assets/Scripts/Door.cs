using UnityEngine;

public class Door : MonoBehaviour
{
    public string doorID; 
    public string linkedSceneName;
    public string linkedDoorID;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        doorID = gameObject.name.Substring(4);
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
