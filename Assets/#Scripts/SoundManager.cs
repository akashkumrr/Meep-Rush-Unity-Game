using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public AudioSource BGM;
	public AudioClip[] musicStore;
	public int i;
	public Animator textAnimator;
	public Animator roundalAnimator;

	public GameObject gamobj;

	public IEnumerator coroutine;

	[Space(10)]
	public bool died;
	public bool completed;
	[Space(10)]
	public AudioClip deathMusicClip;
	public AudioClip completeMusicClip;

	// Use this for initialization
	void Start () {
		coroutine = Example();
		StartCoroutine(coroutine);
	}
	
	// Update is called once per frame
	void Update () {
		if (died == true) 
		{
			BGM.Stop ();
			BGM.clip = deathMusicClip;
			BGM.Play ();
			BGM.loop=true;
			died = false;
			StopCoroutine (coroutine);
		}

		if (completed == true) 
		{
			BGM.Stop ();
			BGM.clip = completeMusicClip;
			BGM.Play ();
			BGM.loop=true;
			completed = false;
			StopCoroutine (coroutine);
		}
		
	}

	public void ChangeBGM(AudioClip myMusic)
	{
		/*if (BGM.clip.name == myMusic.name)
			return;
		*/
		BGM.Stop ();
		BGM.clip = myMusic;
		BGM.Play ();

		coroutine = Example();
		StartCoroutine(coroutine);

	}

	IEnumerator Example()
	{gamobj.SetActive (true);
		i = Random.Range (0, musicStore.Length);
		textAnimator.enabled = true;
		roundalAnimator.enabled = true;
		yield return new WaitForSeconds (2);
		textAnimator.enabled = false;
		roundalAnimator.enabled = false;
		gamobj.SetActive (false);
		//BGM.Pause ();
	//	BGM.UnPause ();
	
		yield return new WaitForSeconds(BGM.clip.length);
		if(musicStore[i]!=null)
			ChangeBGM (musicStore[i]);
	
	}



}
