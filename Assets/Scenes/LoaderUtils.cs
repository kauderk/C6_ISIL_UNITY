using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderUtils : MonoBehaviour
{
    public ScriptableObject scriptableObject;

    public async void LoadScene(SwipeMenu.Menu MenuRef)
    {
        var sceneIndex = MenuRef.getCurrentItem();
        var obj = MenuRef.gameObject.transform.GetChild(sceneIndex);
        var loader = obj.GetComponent<LoaderUtils>();
        var data = (SO_SceneData)loader.scriptableObject;
        var id = data.Scene.name;
        await SceneController.Instance.LoadScene(id);
    }
    public async void LoadScene(int index)
    {
        await SceneController.Instance.LoadScene(index);
    }
    public async void LoadScene(string nameOrPath)
    {
        await SceneController.Instance.LoadScene(nameOrPath);
    }
}
