
using System.Collections.Generic;
using UnityEngine;

public static class SceneTracker 
{
  public static string previousScene; 

  public static string previousDoor;
  
  public static List<int> loadedRooms;

  public static string getOppositeDoor(string str) {
    if (str == null) {return "";}
    if (str.Contains("North")) {return "South";}
    if (str.Contains("East")) {return "West";}
    if (str.Contains("South")) {return "East";}
    if (str.Contains("West")) {return "North";}
    return "";
   
  }
  public static bool isOppositeDoor(string DoorID) {
    if (getOppositeDoor(previousDoor) == DoorID) {
        return true;
    }
    return false;
  }
}
