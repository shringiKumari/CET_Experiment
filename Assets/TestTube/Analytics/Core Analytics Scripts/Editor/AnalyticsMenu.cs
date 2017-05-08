using UnityEngine;
using UnityEditor;
using System.Collections;

public class AnalyticsMenu : MonoBehaviour {

    [MenuItem("TestTube/UI/Create Load Next Scene Panel")]
    private static void CreateLoadingPanel()
    {

        GameObject loadingPanel = (PrefabUtility.InstantiatePrefab(AssetDatabase.LoadAssetAtPath("Assets/TestTube/Quick UI/Panels/Loading Panel.prefab", typeof(GameObject)) as GameObject)) as GameObject;

        loadingPanel.transform.SetParent(GameObject.Find("Blank UI").transform);


        RectTransform r = ((RectTransform)loadingPanel.transform);
        r.localPosition = Vector2.zero;
        r.localScale = Vector3.one;
        r.offsetMax = Vector2.zero;
        r.offsetMin = Vector2.zero;

    }



    [MenuItem("TestTube/Set up Analytics")]
	private static void SetupAnalytics(){
		PrefabUtility.InstantiatePrefab(AssetDatabase.LoadAssetAtPath("Assets/TestTube/Quick UI/Analytics.prefab", typeof(GameObject)) as GameObject);

	}


	[MenuItem("TestTube/Setup UI and Analytics")]
	private static void SetupAll()
	{
	
		PrefabUtility.InstantiatePrefab(AssetDatabase.LoadAssetAtPath("Assets/TestTube/Quick UI/Analytics.prefab", typeof(GameObject)) as GameObject);
		PrefabUtility.InstantiatePrefab(AssetDatabase.LoadAssetAtPath("Assets/TestTube/Quick UI/Blank UI.prefab", typeof(GameObject)) as GameObject);
		PrefabUtility.InstantiatePrefab(AssetDatabase.LoadAssetAtPath("Assets/TestTube/Quick UI/EventSystem.prefab", typeof(GameObject)) as GameObject);
		


	}

	[MenuItem("TestTube/Setup UI (not Analytics)")]
	private static void SetupUI(){
		PrefabUtility.InstantiatePrefab(AssetDatabase.LoadAssetAtPath("Assets/TestTube/Quick UI/Blank UI.prefab", typeof(GameObject)) as GameObject);
		PrefabUtility.InstantiatePrefab(AssetDatabase.LoadAssetAtPath("Assets/TestTube/Quick UI/EventSystem.prefab", typeof(GameObject)) as GameObject);
	}


}
