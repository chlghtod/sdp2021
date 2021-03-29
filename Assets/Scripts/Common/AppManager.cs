using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.SceneManagement;
public class AppManager : MonoSingleton<AppManager>
{
    public enum SceneState
    {
        Title,
        Login,
        Game
    }

    
    public enum GameState
    {
        Ready,
        Quit,
        Terminate
    }

    public SceneState sceneState { get; private set; }
    public GameState gameState { get; private set; }

    private void Awake() 
    {
        sceneState = SceneState.Title;
        gameState = GameState.Ready;   
    }

    private void Update() 
    {
    }
    public void Terminate() 
    {
        gameState = GameState.Terminate;    
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBPLAYER
            Application.OpenURL("http://google.com");       
        #else
            Application.Quit();
        #endif                        
    }

    public void SetScene(SceneState newScene)
    {
        sceneState = newScene;
        gameState = GameState.Ready;   
   }
}