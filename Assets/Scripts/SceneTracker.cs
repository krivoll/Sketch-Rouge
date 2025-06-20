

using UnityEngine;

public static class SceneTracker 
{
  public static string previousScene; 
  public static bool returnToPreviousDoor => !string.IsNullOrEmpty(previousScene);
  public static Vector2 previousPositon;

  public static string getOppositeDoor(string str) {
    if (str.Contains("North")) {return "South";}
    if (str.Contains("East")) {return "West";}
    if (str.Contains("South")) {return "East";}
    if (str.Contains("West")) {return "North";}
    return "";
   
  }
}
