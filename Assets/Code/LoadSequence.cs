using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSequence : MonoBehaviour {

	[SerializeField] float CloseupTime = 10;
	[SerializeField] float TransitionLength = 5;
	[SerializeField] float TitleFadeTime = 1;
	[SerializeField] Camera myCamera;
	[SerializeField] Gradient FadeInGradient;
	[SerializeField] Gradient FadeOutGradient;
	[SerializeField] Gradient TitleFadeInGradient;
	[SerializeField] Image Background;
	[SerializeField] Image Title;

	void Awake() {
		StartCoroutine(LoadScenesCoroutine());
	}

	IEnumerator LoadScenesCoroutine() {
		float startTime = Time.realtimeSinceStartup;
		while(Time.realtimeSinceStartup - startTime < TransitionLength) {
			float delta = (Time.realtimeSinceStartup - startTime) / TransitionLength;
			Background.color = FadeInGradient.Evaluate(delta);
			yield return null;
		}

		startTime = Time.realtimeSinceStartup;
		while(Time.realtimeSinceStartup - startTime < CloseupTime) {
			yield return null;
		}

		startTime = Time.realtimeSinceStartup;
		while(Time.realtimeSinceStartup - startTime < TransitionLength) {
			float delta = (Time.realtimeSinceStartup - startTime) / TransitionLength;
			Background.color = FadeOutGradient.Evaluate(delta);
			yield return null;
		}

		startTime = Time.realtimeSinceStartup;
		while(Time.realtimeSinceStartup - startTime < TitleFadeTime) {
			float delta = (Time.realtimeSinceStartup - startTime) / TitleFadeTime;
			Title.color = TitleFadeInGradient.Evaluate(delta);
			yield return null;
		}

		startTime = Time.realtimeSinceStartup;

		AsyncOperation status;
		{
			status = SceneManager.LoadSceneAsync("MasterScene",LoadSceneMode.Additive);
			while(!status.isDone) {
				yield return null;
			}
		}
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

		while(Time.realtimeSinceStartup - startTime < CloseupTime) {
			yield return null;
		}

		myCamera.gameObject.SetActive(false);
		 SceneManager.UnloadSceneAsync("Intro");

	}
}
