using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;

	void Start() {
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			text.text = "Hello";
		}
	}
}
