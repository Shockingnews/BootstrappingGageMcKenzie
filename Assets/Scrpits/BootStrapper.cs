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
    }

    
}
