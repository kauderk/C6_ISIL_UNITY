using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

[ExecuteAlways]
public class TMPEvents : MonoBehaviour
{
    public Optional_<TMP_Text> text = new Optional_<TMP_Text>(null);
    public UnityEvent m_MyEvent;

    private void OnEnable()
    {
        m_MyEvent?.Invoke();
    }

    public void SetText(ScriptableObject compt)
    {
        var tmp = gameObject.GetComponent<TextMeshProUGUI>();
        tmp.text = compt.name;
    }
}