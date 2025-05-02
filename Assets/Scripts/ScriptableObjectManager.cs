using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;

public class ScriptableObjectManager : MonoBehaviour
{
    [SerializeField] public string targetFolder = "Assets/Data/ScriptableObjects/Items/Items"; // Folder path
    [SerializeField] public List<ItemSO> loadedObjects = new List<ItemSO>();
    
    // Your methods to work with the loaded objects
}

#if UNITY_EDITOR
[CustomEditor(typeof(ScriptableObjectManager))]
public class ScriptableObjectManagerEditor : Editor
{
    private ScriptableObjectManager manager;
    
    private void OnEnable()
    {
        manager = (ScriptableObjectManager)target;
    }
    
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        EditorGUILayout.Space(10);
        
        if (GUILayout.Button("Refresh ScriptableObjects from Folder"))
        {
            RefreshObjects();
        }
        
        EditorGUILayout.Space(5);
        
        if (GUILayout.Button("Apply Changes"))
        {
            // Apply any changes you've made to the SOs
            ApplyChanges();
        }
    }
    
    private void RefreshObjects()
    {
        var manager = (ScriptableObjectManager)target;
        string[] guids = AssetDatabase.FindAssets("t:ScriptableObject", new[] { manager.targetFolder });
        
        // Clear the existing list
        SerializedProperty listProp = serializedObject.FindProperty("loadedObjects");
        listProp.ClearArray();
        
        // Add all found ScriptableObjects to the list
        for (int i = 0; i < guids.Length; i++)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guids[i]);
            ScriptableObject obj = AssetDatabase.LoadAssetAtPath<ScriptableObject>(assetPath);
            
            listProp.arraySize++;
            listProp.GetArrayElementAtIndex(listProp.arraySize - 1).objectReferenceValue = obj;
        }
        
        serializedObject.ApplyModifiedProperties();
    }
    
    private void ApplyChanges()
    {
        // Mark all the objects as dirty so Unity saves them
        SerializedProperty listProp = serializedObject.FindProperty("loadedObjects");
        for (int i = 0; i < listProp.arraySize; i++)
        {
            var obj = listProp.GetArrayElementAtIndex(i).objectReferenceValue as ScriptableObject;
            if (obj != null)
            {
                EditorUtility.SetDirty(obj);
            }
        }
        AssetDatabase.SaveAssets();
    }
}
#endif