using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControllerTrigger : MonoBehaviour
{
    public async void LoadScene(int sceneName)
    {
        await SceneController.Instance.LoadScene(sceneName);
    }
}
