using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public static class PerformBootstrap
{
    const string SceneName = "BootstrapperScene";

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Execute()
    {
        for (int sceneIndex = 0; sceneIndex < SceneManager.sceneCount;  sceneIndex++)
        {
            var candidate = SceneManager.GetSceneAt(sceneIndex);

            if (candidate.name == SceneName)
            {
                return;
            }
        }
        SceneManager.LoadScene(SceneName, LoadSceneMode.Additive);


    }
}

public class BootStrapper : MonoBehaviour
{
    public static SceneManagerScript sceneManager;
    public static UiManagerScript UiManager;
    public static interactionManagerScript interactionManager;

    public static BootStrapper Instance {get; private set;}
    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        
        if (sceneManager != null)
        {
            Destroy(sceneManager);
            return;
        }
        GameObject obj = new GameObject("SceneManager");
        sceneManager = obj.AddComponent<SceneManagerScript>();
        DontDestroyOnLoad(sceneManager);

        if (UiManager != null)
        {
            Destroy(UiManager);
            return;
        }
        obj = new GameObject("UiManager");
        UiManager = obj.AddComponent<UiManagerScript>();
        DontDestroyOnLoad(UiManager);

        if (interactionManager != null)
        {
            Destroy(interactionManager);
            return;
        }
        obj = new GameObject("interactionManager");
        interactionManager = obj.AddComponent<interactionManagerScript>();
        DontDestroyOnLoad(interactionManager);


    }

    
}
