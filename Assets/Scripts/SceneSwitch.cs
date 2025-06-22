using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    Door thisDoor;
    string thisScene; 
    void Start() {
        GameObject theDoor = gameObject; 
        thisDoor = theDoor.GetComponent<Door>();
        thisScene = SceneManager.GetActiveScene().name;
    }
    void OnTriggerExit2D(Collider2D other)
    {   
        
        if (Player.Instance.gameObject != other.gameObject) return;
        
        if (thisDoor == null) { Debug.Log("Is it always null?"); }

        if (!string.IsNullOrEmpty(thisDoor.linkedDoorID))
        {
            StartCoroutine(TravelToScene(thisDoor.linkedSceneName, thisDoor.linkedDoorID, 2));
        }
       
        else {
            Debug.Log("Check if you switch scene");
            TravelManager.Instance.incomingDoorID = thisDoor.doorID;
            TravelManager.Instance.incomingSceneName = thisScene;
        
            StartCoroutine(RandomScene(thisDoor, TravelManager.Instance.incomingSceneName));

 
                 //  foreach (GameObject gameObject in SceneManager.GetSceneByName(SceneTracker.previousScene).GetRootGameObjects()) {
            //     if (!gameObject.CompareTag("Door")) {
                  
            //     gameObject.SetActive(false); }
            // }
           
        }
        // else {
       
        //     // foreach (GameObject gameObject in SceneManager.GetSceneByName(SceneTracker.previousScene).GetRootGameObjects()) {
        //     //     gameObject.SetActive(true);
        //     // }
            
        //     StartCoroutine(LoadPreviousScene());
        // }
    }

    IEnumerator RandomScene(Door oldDoor, string previousScene) {
        Scene currentScene = SceneManager.GetActiveScene();
        
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        int sceneIndex;

        do {
            sceneIndex = Random.Range(0, sceneCount);
        } while (SceneManager.GetSceneByBuildIndex(sceneIndex) == currentScene);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);
    
         while (!asyncLoad.isDone)
    {
        yield return null; // Venter en fram hvis asyncLoad ikke er ferdig
    }
        yield return null;
     
        Scene newScene = SceneManager.GetSceneByBuildIndex(sceneIndex);
        SceneManager.MoveGameObjectToScene(Player.Instance.gameObject, newScene);
         
        Door[] doors = FindObjectsOfType<Door>(true)
    .   Where(d => d.gameObject.scene == newScene)
        .ToArray();                                             //System LINQ lol, noe streams lignende greier? 
          foreach (Door door in doors)
{
            Debug.Log(door.name + " Hallo");
        };

        MovePlayerToOppositeDoor(oldDoor, doors);
        
        SceneManager.UnloadSceneAsync(currentScene);

    }

    void MovePlayerToOppositeDoor(Door oldDoor, Door[] doors) {
      
        Rigidbody2D rb = Player.Instance.gameObject.GetComponent<Rigidbody2D>();
        float offsetAmount = 2f; 
       
      

        foreach (Door door in doors) {
        if (door.name.Contains(door.getOppositeDoor(gameObject.name))) {
            Vector2 newPosition = (Vector2)door.transform.position;
            rb.position = newPosition + direction(door) * offsetAmount;
            rb.linearVelocity = Vector2.zero;

            //Lagrer ny dør sin dørID 
            Debug.Log(door.name);
            TravelManager.Instance.outgoingDoorID = door.doorID;
            TravelManager.Instance.outgoingSceneName = door.sceneName;

            //
            door.linkedDoorID = TravelManager.Instance.incomingDoorID;
            door.linkedSceneName = TravelManager.Instance.incomingDoorID;
            BiDirectionalLinkDoors(oldDoor, door, TravelManager.Instance.incomingDoorID, TravelManager.Instance.incomingSceneName);
            break;
        }
    }
}

  
    IEnumerator TravelToScene(string sceneName, string targetDoorID, int offset) {
        yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        yield return null;

        Scene newScene = SceneManager.GetSceneByName(sceneName);
        SceneManager.MoveGameObjectToScene(Player.Instance.gameObject, newScene);
        
        Door[] doors =  Resources.FindObjectsOfTypeAll<Door>();

        foreach (Door door in doors) {
            if (targetDoorID == door.doorID) {
            Player.Instance.gameObject.transform.position = (Vector2)door.transform.position + direction(door)*offset;}
        }
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
    
    }
    Vector2 direction(Door door) {

            if (door.name.Contains("North")) {
                return Vector2.down;
            }
            else if (door.name.Contains("South")) {
                return Vector2.up;
            }
            else if (door.name.Contains("East")) {
                return Vector2.left;
            }
            else if (door.name.Contains("West")) {
                return Vector2.right;
            }
    
         
    return Vector2.zero;
    }
    void BiDirectionalLinkDoors(Door oldDoor, Door newDoor, string previousDoor, string previousScene) {
            newDoor.linkedDoorID = previousDoor;
            newDoor.linkedSceneName = previousScene;
            oldDoor.linkedDoorID = newDoor.doorID;
            oldDoor.linkedSceneName = newDoor.sceneName;

    }

}
