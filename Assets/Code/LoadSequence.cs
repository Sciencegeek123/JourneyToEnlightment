using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSequence : MonoBehaviour {

	[SerializeField] float LoadDelay = 15;
	[SerializeField] float KillDelay = 20;

	bool loadOnce = false;
	[SerializeField] Gradient PaneAlpha;
	[SerializeField] Image image;

	// Update is called once per frame
	void Update () {
		image.color = PaneAlpha.Evaluate(Time.realtimeSinceStartup / 20);
		if(!loadOnce && Time.realtimeSinceStartup > LoadDelay) {
			LoadAll();
			loadOnce = true;
		}
		if(Time.realtimeSinceStartup > KillDelay) {
			SceneManager.UnloadSceneAsync("Intro");
			this.gameObject.SetActive(false);
		}
	}

	void LoadAll() {
		SceneManager.LoadSceneAsync("MainGameEnvironment",LoadSceneMode.Additive);
		SceneManager.LoadSceneAsync("AmbientSourceScene",LoadSceneMode.Additive);
		SceneManager.LoadSceneAsync("EnemyScene",LoadSceneMode.Additive);
		SceneManager.LoadSceneAsync("MainGameEnvironment",LoadSceneMode.Additive);
		SceneManager.LoadSceneAsync("MasterScene",LoadSceneMode.Additive);
		SceneManager.LoadSceneAsync("Starting Decoration",LoadSceneMode.Additive);
		SceneManager.LoadSceneAsync("WallColliders",LoadSceneMode.Additive);
		SceneManager.LoadSceneAsync("WallScene1",LoadSceneMode.Additive);
		SceneManager.LoadSceneAsync("WallScene2",LoadSceneMode.Additive);
		SceneManager.LoadSceneAsync("WallScene3",LoadSceneMode.Additive);
		SceneManager.LoadSceneAsync("WallScene4",LoadSceneMode.Additive);
		SceneManager.LoadSceneAsync("WallScene5",LoadSceneMode.Additive);
	}
}
