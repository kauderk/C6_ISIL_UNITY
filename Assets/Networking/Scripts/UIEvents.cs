using UnityEngine;
using TMPro;

public class UIEvents : MonoBehaviour
{
    public void SetText(string text)
    {
        gameObject.GetComponent<TMP_Text>().text = text;
    }
}
