using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{

    void OnTriggerExit2D(Collider2D other)
    {
        if (Player.Instance.gameObject != other.gameObject) return;


        if (!SceneTracker.returnToPreviousDoor) {
      
            SceneTracker.previousScene = SceneManager.GetActiveScene().name; //for å kunne gå tilbake
            SceneTracker.previousPositon = Player.Instance.gameObject.transform.position;
            
            //  foreach (GameObject gameObject in SceneManager.GetSceneByName(SceneTracker.previousScene).GetRootGameObjects()) {
            //     if (!gameObject.CompareTag("Door")) {
                  
            //     gameObject.SetActive(false); }
            // }
            StartCoroutine(RandomScene());
           
        }
        else {
       
            // foreach (GameObject gameObject in SceneManager.GetSceneByName(SceneTracker.previousScene).GetRootGameObjects()) {
            //     gameObject.SetActive(true);
            // }
            StartCoroutine(LoadPreviousScene());
            
            
        }
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

        Debug.Log("Hakllo");

        string oppositeDoor = SceneTracker.getOppositeDoor(gameObject.name);
        GameObject[] doors = GameObject.FindGameObjectsWithTag("Door");

        foreach (GameObject door in doors) {
            if (door.name.Contains(oppositeDoor)) {
                Player.Instance.gameObject.transform.position = door.transform.position;
                break;
            }
            
        }
        
    
        SceneManager.UnloadSceneAsync(currentScene);

        Debug.Log("Hei");
    }

    IEnumerator LoadPreviousScene() {
        yield return SceneManager.LoadSceneAsync(SceneTracker.previousScene, LoadSceneMode.Additive);
        
        Player.Instance.gameObject.transform.position = SceneTracker.previousPositon;
        SceneManager.MoveGameObjectToScene(Player.Instance.gameObject, SceneManager.GetSceneByName(SceneTracker.previousScene));

        string oppositeDoor = SceneTracker.getOppositeDoor(gameObject.name);
        GameObject[] doors = GameObject.FindGameObjectsWithTag("Door");

           foreach (GameObject door in doors) {
            
            if (door.name.Contains(oppositeDoor)) {
                Player.Instance.gameObject.transform.position = door.transform.position;
                break;
            }
            
        }
        SceneManager.MoveGameObjectToScene(Player.Instance.gameObject, SceneManager.GetSceneByName(SceneTracker.previousScene));
        
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

 
    }
}
