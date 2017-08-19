using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {
	
	public Text text;
	
	private enum State
	{
		Cell,
		CellMirror,
		Mirror,
		Sheets0,
		Sheets1,
		Lock0,
		Lock1,
		Freedom
	}
	private State curState;

	void Start() {
		curState = State.Cell;
	}

	void Update() {
		switch (curState) {
		default:
			break;
		case State.Cell:    StateCell();    break;
		case State.Sheets0: StateSheets0(); break;
		}
	}

	void StateCell() {
		text.text =
			"You are in a prison cell, and you want to escape. There are " +
			"some dirty sheets on the bed, a mirror on the wall, and the door " +
			"is locked from outside.\n\n" +
			"Press S to view Sheets, M to view Mirror or L to view Lock.";
		if (Input.GetKeyDown(KeyCode.S)) {
			curState = State.Sheets0;
		}
	}

	void StateSheets0() {
		text.text =
			"You can't believe you sleep in these things. Surely it's " +
			"time somebody changed them. The pleasures of prison life " +
			"I guess!\n\n" +
			"Press R to Return to roaming your cell.";
		if (Input.GetKeyDown(KeyCode.R)) {
			curState = State.Cell;
		}
	}
}
