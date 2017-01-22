using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    InputSingleton input;
    void Start() {

		RenderSettings.ambientIntensity = 0;
		RenderSettings.fog = true;
		RenderSettings.fogColor = new Color(0,13,23,34);
		RenderSettings.fogMode = FogMode.Linear;
		RenderSettings.fogStartDistance = 15;
		RenderSettings.fogEndDistance = 30;
        StartCoroutine(LoadScenesCoroutine());
    }

	IEnumerator LoadScenesCoroutine() {
		AsyncOperation status;
        {
			 status = SceneManager.LoadSceneAsync("MainGameEnvironment",LoadSceneMode.Additive);
			while(!status.isDone) {
				yield return null;
			}
		}
		{
			 status = SceneManager.LoadSceneAsync("WallScene1",LoadSceneMode.Additive);
			while(!status.isDone) {
				yield return null;
			}
		}
		{
			 status = SceneManager.LoadSceneAsync("WallScene2",LoadSceneMode.Additive);
			while(!status.isDone) {
				yield return null;
			}
		}
		{
			 status = SceneManager.LoadSceneAsync("WallScene3",LoadSceneMode.Additive);
			while(!status.isDone) {
				yield return null;
			}
		}
		{
			 status = SceneManager.LoadSceneAsync("WallScene4",LoadSceneMode.Additive);
			while(!status.isDone) {
				yield return null;
			}
		}
		{
			 status = SceneManager.LoadSceneAsync("WallScene5",LoadSceneMode.Additive);
			while(!status.isDone) {
				yield return null;
			}
		}
		{
			 status = SceneManager.LoadSceneAsync("Starting Decoration",LoadSceneMode.Additive);
			while(!status.isDone) {
				yield return null;
			}
		}
		{
			 status = SceneManager.LoadSceneAsync("WallColliders",LoadSceneMode.Additive);
			while(!status.isDone) {
				yield return null;
			}
		}
		{
			 status = SceneManager.LoadSceneAsync("AmbientSourceScene",LoadSceneMode.Additive);
			while(!status.isDone) {
				yield return null;
			}
		}
		{
			 status = SceneManager.LoadSceneAsync("EnemyScene",LoadSceneMode.Additive);
			while(!status.isDone) {
				yield return null;
			}
		}
    }
    void Update() {
    }
}