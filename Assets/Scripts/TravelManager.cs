
using UnityEngine;

public class TravelManager : MonoBehaviour
{
  public static TravelManager Instance; 

  public string incomingDoorID;
  public string incomingSceneName;
  public string outgoingDoorID;
  public string outgoingSceneName;
  void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else {
            Destroy(gameObject);
        }
        
    }
}
