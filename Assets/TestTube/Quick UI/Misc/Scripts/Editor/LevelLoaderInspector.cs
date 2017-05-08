using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor (typeof(Loading))]
public class LevelLoaderInspector : Editor {

	public override void OnInspectorGUI(){

		var red = new GUIStyle(GUI.skin.label); red.normal.textColor = Color.red;

		int con = EditorPrefs.GetInt("Conditions",0);
		bool analyticsExists = con > 0;

		showLogo ();

		if (analyticsExists) { // Main stuff goes here
			if(EditorBuildSettings.scenes.Length>0){

				main();


			}
			else{
				EditorGUILayout.LabelField("Error! Zero Scenes in Build:",red);
				EditorGUILayout.LabelField("\t(1) Setup your build from File->Build Settings",red);
				EditorGUILayout.LabelField("\t(2) Use 'Add Current' to add levels",red);
				EditorGUILayout.LabelField("\t(3) Select from those levels here",red);
				EditorGUILayout.LabelField ("");
			}
		} else {

				EditorGUILayout.LabelField("Error! Analytics object not detected:",red);
				EditorGUILayout.LabelField("\t(1) Set up Analytics from the Game4Science Menu",red);
				EditorGUILayout.LabelField("\t(2) Add UI and Panels",red);


		}



	}



	private void showLogo(){
		Texture image = (Texture)Resources.Load ("LoadLevelBanner");

		
		
		int width = Screen.width-36;
		int height = (int)((float)((float)width / (float)image.width) * image.height);
		GUILayout.Label (image,GUILayout.MaxWidth(width),GUILayout.MaxHeight(height));
	}


	private string[] getScenes(){

		var temp = new List<string>();


		foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes){
			if(scene.enabled){
				string name = scene.path.Substring(scene.path.LastIndexOf('/')+1);
				name = name.Substring(0,name.Length-6);
				temp.Add(name);
			}
		}


		return temp.ToArray ();
	}

	private void main(){

		int con = EditorPrefs.GetInt ("Conditions");
		Loading loading = (Loading)target;

		EditorGUI.BeginChangeCheck();
		
		GUIStyle blue = new GUIStyle(GUI.skin.label);
		blue.normal.textColor = new Color(0f,0f,1f);

		EditorGUILayout.LabelField("Your game has "+con+" different condition(s):",blue);
		
		if(loading.LevelToLoadByCondition.Length!=con){
			loading.LevelToLoadByCondition = new string[con];
	
			EditorUtility.SetDirty (target);

		}
		
		
		
		
		string[] names = getScenes();
		
		
		
		for(int i = 0; i<con; i++){

			int index = 0;

			for(int j = 0; j<names.Length; j++){
				if(loading.LevelToLoadByCondition[i]==names[j]){
					index = j; break;
				}
			}

            string oldLevelToLoad = loading.LevelToLoadByCondition[i];


            EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField("In Condition "+i+" load:");

            Undo.RecordObject(target, "Changed level to load");

			loading.LevelToLoadByCondition[i]= names[EditorGUILayout.Popup(index,names)];
			EditorGUILayout.EndHorizontal ();


            if (loading.LevelToLoadByCondition[i] != oldLevelToLoad)
            {
                EditorUtility.SetDirty(target);
            }

			
		}
		
		
		
		if(GUI.changed){
			EditorUtility.SetDirty (loading);
		}

	}


}
