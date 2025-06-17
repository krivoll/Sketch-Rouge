
using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public string scene; 

    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Hallo");
        if (player == other.gameObject) {
        StartCoroutine(LoadYourAsyncScene());
        }
    }
    IEnumerator LoadYourAsyncScene() {
        Scene currentScene = SceneManager.GetActiveScene();
        
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);

        while (!asyncLoad.isDone) {
            yield return null;
        }
        SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByName(scene));
      
        SceneManager.UnloadSceneAsync(currentScene); //Litt usikker hva dette gjør, men fant det på unity nettside
    }
}
