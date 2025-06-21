using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    void Start() {
        
    }
    void OnTriggerExit2D(Collider2D other)
    {
        Door thisDoor = GetComponent<Door>();
        if (Player.Instance.gameObject != other.gameObject) return;

        if (thisDoor.linkedDoorID != null) {
            StartCoroutine(TravelToScene(thisDoor.linkedSceneName,thisDoor.linkedDoorID, 2));
        }
       
        if (!SceneTracker.isOppositeDoor(Door.doorID)) {
            Debug.Log("Check if you switch scene");
            SceneTracker.previousScene = SceneManager.GetActiveScene().name; //for å kunne gå tilbake
            SceneTracker.previousDoor = Door.doorID;
            //  foreach (GameObject gameObject in SceneManager.GetSceneByName(SceneTracker.previousScene).GetRootGameObjects()) {
            //     if (!gameObject.CompareTag("Door")) {
                  
            //     gameObject.SetActive(false); }
            // }
            StartCoroutine(RandomScene());
           
        }
        // else {
       
        //     // foreach (GameObject gameObject in SceneManager.GetSceneByName(SceneTracker.previousScene).GetRootGameObjects()) {
        //     //     gameObject.SetActive(true);
        //     // }
            
        //     StartCoroutine(LoadPreviousScene());
        // }
    }

    IEnumerator RandomScene() {
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

        MovePlayerToOppositeDoor();
        
        SceneManager.UnloadSceneAsync(currentScene);
    }

    // IEnumerator LoadPreviousScene() {
    //     yield return SceneManager.LoadSceneAsync(SceneTracker.previousScene, LoadSceneMode.Additive);
    //     yield return null;

    //     SceneManager.MoveGameObjectToScene(Player.Instance.gameObject, SceneManager.GetSceneByName(SceneTracker.previousScene));
    //     MovePlayerToOppositeDoor();
     
    //     SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
    // }
    void MovePlayerToOppositeDoor() {
           Rigidbody2D rb = Player.Instance.gameObject.GetComponent<Rigidbody2D>();
        float offsetAmount = 2f; 
       
        string oppositeDoor = SceneTracker.getOppositeDoor(gameObject.name);
        Door[] doors =  Resources.FindObjectsOfTypeAll<Door>();

        foreach (Door door in doors) {
        if (door.name.Contains(oppositeDoor)) {
            Vector2 newPosition = (Vector2)door.transform.position;
            rb.position = newPosition + direction(doors) * offsetAmount;
            rb.linearVelocity = Vector2.zero;
            break;
        }
    }
}

  
    IEnumerator TravelToScene(string sceneName, string targetDoorID, int offset) {
        yield return SceneManager.LoadSceneAsync(SceneTracker.previousScene, LoadSceneMode.Additive);
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

}
