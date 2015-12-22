using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.Collections;

[CustomEditor(typeof(GameGui))]
public class GameGuiEditor : Editor {

	ReorderableList list;
	
	private void OnEnable()
	{
		list = new ReorderableList(this.serializedObject,this.serializedObject.FindProperty("panels"),true,false,true,true);
		
		list.drawElementCallback = DrawListElement;
		
	}
	
	public override void OnInspectorGUI ()
	{
		this.serializedObject.Update();
		GUILayout.Space(10);
		
		EditorGUILayout.PropertyField(this.serializedObject.FindProperty("defaultPanel"));
		
		GUILayout.Label("Panels");
		list.DoLayoutList();
		this.serializedObject.ApplyModifiedProperties();
		//base.OnInspectorGUI();
	}
	
	//250 = 50
	//180 = 30
	
	void DrawListElement(Rect rect, int index, bool isActive, bool isFocused)
	{
		var element = list.serializedProperty.GetArrayElementAtIndex(index);
		rect.y += 2;
		EditorGUI.PropertyField(
			new Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight),
			element, GUIContent.none);
		/*EditorGUI.PropertyField(
			new Rect(rect.x + 60, rect.y, rect.width - 60 - 30, EditorGUIUtility.singleLineHeight),
			element.FindPropertyRelative("Prefab"), GUIContent.none);
		EditorGUI.PropertyField(
			new Rect(rect.x + rect.width - 30, rect.y, 30, EditorGUIUtility.singleLineHeight),
			element.FindPropertyRelative("Count"), GUIContent.none);*/
	}
	
}
