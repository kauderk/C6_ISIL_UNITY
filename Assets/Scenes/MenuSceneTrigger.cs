using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSceneTrigger : MonoBehaviour
{
    [SerializeField] SwipeMenu.Menu MenuRef;

    public async void LoadScene()
    {
        var sceneIndex = MenuRef.getCurrentItem();
        var itemObj = MenuRef.gameObject.transform.GetChild(sceneIndex);
        var trigger = itemObj.GetComponent<MenuItemTrigger>();
        var id = trigger.sceneData.Scene.name;
        await SceneController.Instance.LoadScene(id);
    }
}
