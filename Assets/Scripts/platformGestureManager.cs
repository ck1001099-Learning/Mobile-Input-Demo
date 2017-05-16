using UnityEngine;
using System.Collections;
using TouchScript.Gestures;
using TouchScript.Hit;
using DG.Tweening;

using UnityEngine.UI;


public class platformGestureManager : MonoBehaviour {

	public TapGesture singleTap;
	public TapGesture doubleTap;

	public FlickGesture flick;

	public GameObject character1;
	public GameObject character2;
	public GameObject nowCharacter;
	public bool switchCharacter;

	// Use this for initialization
	void Start () {

		switchCharacter = false;
		nowCharacter = character1;

		singleTap.Tapped += (object sender, System.EventArgs e) => 
		{
			TouchHit hit;
			singleTap.GetTargetHitResult(out hit);

			nowCharacter.GetComponent<Animator>().SetTrigger("OneTap");
		};

		doubleTap.Tapped += (object sender, System.EventArgs e) => 
		{
			TouchHit hit;
			doubleTap.GetTargetHitResult(out hit);

			nowCharacter.GetComponent<Animator>().SetTrigger("DoubleTap");
		};

		flick.Flicked += (object sender, System.EventArgs e) => {
			ChangeCharacter();
		};

	}

	void Update(){
		if (Input.acceleration.magnitude > 1.7f) {
			nowCharacter.GetComponent<Animator> ().SetTrigger ("Shake");
		}
	}

	void ChangeCharacter(){
		if (switchCharacter) {
			switchCharacter = false;
			character1.gameObject.SetActive (true);
			character2.gameObject.SetActive (false);
			nowCharacter = character1.gameObject;
		} else {
			switchCharacter = true;
			character1.gameObject.SetActive (false);
			character2.gameObject.SetActive (true);
			nowCharacter = character2.gameObject;
		}
	}
}
