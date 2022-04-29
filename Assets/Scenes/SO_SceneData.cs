
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode]
[CreateAssetMenu(fileName = "New Scene Data", menuName = "Scriptable Objects/SceneData")]
public class SO_SceneData : ScriptableObject
{
    public string Name;
    public Sprite LoadingScreen;
    public SceneAsset Scene;
    public List<string> additiveScenes = new List<string>();

    public async void Enter()
    {
        await SceneController.Instance.LoadScene(Scene.name);
    }

    void Update()
    {
        Debug.Log("UpdateMenuItemOnClick");
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(SO_SceneData))]
public class SO_SceneDataInspector : Editor
{
    // public override void OnInspectorGUI()
    // {
    //     Debug.Log("OnInspectorGUI");
    // }
}
#endif