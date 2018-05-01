using UnityEngine;
using UnityEditor;

public class ConditionCollectionEditor : EditorWithSubEditors<ConditionEditor, Condition>
{
    public SerializedProperty collectionsProperty;


    private SerializedProperty descriptionProperty;
    private SerializedProperty conditionsProperty;
    private SerializedProperty reactionCollectionProperty;


    private const float conditionButtonWidth = 30f;
    private const float collectionButtonWidth = 125f;
    private const string conditionCollectionPropDescriptionName = "description";
    private const string conditionCollectionPropRequiredConditionsName = "requiredConditions";
    private const string conditionCollectionPropReactionCollectionName = "reactionCollection";


    private void OnEnable ()
    {
        if (target == null)
        {
            DestroyImmediate (this);
            return;
        }

        descriptionProperty = serializedObject.FindProperty(conditionCollectionPropDescriptionName);
        conditionsProperty = serializedObject.FindProperty(conditionCollectionPropRequiredConditionsName);
        reactionCollectionProperty = serializedObject.FindProperty(conditionCollectionPropReactionCollectionName);
    }


    private void OnDisable ()
    {
        CleanupEditors ();
    }


    protected override void SubEditorSetup (ConditionEditor editor)
    {
        editor.editorType = ConditionEditor.EditorType.ConditionCollection;
        editor.conditionsProperty = conditionsProperty;
    }


    public override void OnInspectorGUI ()
    {
        
    }


    private void ExpandedGUI ()
    {
        EditorGUILayout.Space();

        EditorGUILayout.PropertyField(descriptionProperty);

        EditorGUILayout.Space();

        float space = EditorGUIUtility.currentViewWidth / 3f;

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Condition", GUILayout.Width(space));
        EditorGUILayout.LabelField("Satisfied?", GUILayout.Width(space));
        EditorGUILayout.LabelField("Add/Remove", GUILayout.Width(space));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginVertical(GUI.skin.box);
        for (int i = 0; i < subEditors.Length; i++)
        {
            subEditors[i].OnInspectorGUI();
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace ();
        if (GUILayout.Button("+", GUILayout.Width(conditionButtonWidth)))
        {
            Condition newCondition = ConditionEditor.CreateCondition();
            conditionsProperty.AddToObjectArray(newCondition);
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();

        EditorGUILayout.PropertyField(reactionCollectionProperty);
    }


    public static ConditionCollection CreateConditionCollection()
    {
        ConditionCollection newConditionCollection = CreateInstance<ConditionCollection>();
        return newConditionCollection;
    }
}
