
using System;
using System.Collections.Generic;
using UnityEngine;

public class SaveableEntity : MonoBehaviour
{
    [SerializeField] private string id = string.Empty;

    public string Id => id;

    [ContextMenu("Generate Id")]
    private void GenerateId() => id = Guid.NewGuid().ToString();

    public object SaveState()
    {
        var state = new Dictionary<string, object>();

        foreach (var saveAble in GetComponents<ISaveable>())
        {
            state[saveAble.GetType().ToString()] = saveAble.SaveState();
        }

        return state;
    }

    public void LoadState(object state)
    {
        var stateDictionary = (Dictionary<string, object>)state;

        foreach (var saveable in GetComponents<ISaveable>())
        {
            string typeName = saveable.GetType().ToString();

            if (stateDictionary.TryGetValue(typeName, out object saveState))
            {
                saveable.LoadState(saveState);
            }
        }
    }
}
