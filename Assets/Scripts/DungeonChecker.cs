using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonChecker : MonoBehaviour
{
    // Update is called once per frame
    // Check if the player is in contact with the dungeon entry
    // If so, change scene to dungeon and teleports player
    // If not, do nothing
    public CharacterController player;
    public GameObject dungeonEntry;
    public GameObject playerObject;

    public int coroutineCounter = 0;

    void Start()
    {   
        DontDestroyOnLoad(dungeonEntry);
    }

    void Update()
    {
        // If player is in contact with dungeon entry
        if (player.bounds.Intersects(dungeonEntry.GetComponent<BoxCollider>().bounds) && coroutineCounter == 0)
        {   
            // Load dungeon scene
            StartCoroutine(LoadYourAsyncScene());
            coroutineCounter++;
            // Teleport player to dungeon
            
        }
    }

    IEnumerator LoadYourAsyncScene() {
        // Set the current Scene to be able to unload it later
        Scene currentScene = SceneManager.GetActiveScene();

        // The Application loads the Scene in the background at the same time as the current Scene.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Dungeon", LoadSceneMode.Additive);

        // Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Move the GameObject (you attach this in the Inspector) to the newly loaded Scene
        SceneManager.MoveGameObjectToScene(playerObject, SceneManager.GetSceneByName("Dungeon"));
        // Unload the previous Scene
        SceneManager.UnloadSceneAsync(currentScene);
        player.transform.position = new Vector3(6, 0, 5);
        coroutineCounter = 0;

        Destroy(this);
    }
}
