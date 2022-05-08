using UnityEditor;
using UnityEngine;


/// <summary>
/// To define as default use:
/// new Optional_<typeparamref name="T"/>(value)
/// </summary>}}}¿¿¿¿¿¿///}}¿
[System.Serializable]
public struct Optional_<T>
{
    // TO define as false

    [SerializeField] private bool enabled;
    [SerializeField] private T value;

    public Optional_(T initVal)
    {
        enabled = true;
        value = initVal;
    }
    public bool Enable => enabled;
    public T Value => value;
}