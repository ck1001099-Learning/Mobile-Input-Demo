using UnityEngine;
using System.Collections;
using TouchScript.Gestures;

public class CharacterTransform : MonoBehaviour {

	public TransformGesture transformGesture;

	// Use this for initialization
	void Start () {

		transformGesture.TransformStarted += (object sender, System.EventArgs e) => 
		{
		};

		transformGesture.Transformed += (object sender, System.EventArgs e) => 
		{
			this.transform.localScale *= transformGesture.DeltaScale;
		};

		transformGesture.TransformCompleted += (object sender, System.EventArgs e) => 
		{
		};
	}
}
