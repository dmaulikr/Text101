using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {
	
	public Text text;
	
	private enum State
	{
		Cell,
		CellMirror,
		ClosetDoor,
		Corridor0,
		Corridor1,
		Corridor2,
		Corridor3,
		Courtyard,
		Floor,
		InCloset,
		Lock0,
		Lock1,
		Mirror,
		Sheets0,
		Sheets1,
		Stairs0,
		Stairs1,
		Stairs2
	}
	private State curState;

	void Start() {
		curState = State.Cell;
	}

	void Update() {
		switch (curState) {
		default:
			break;
		case State.Cell:       StateCell();       break;
		case State.CellMirror: StateCellMirror(); break;
		case State.ClosetDoor: StateClosetDoor(); break;
		case State.Corridor0:  StateCorridor0();  break;
		case State.Corridor1:  StateCorridor1();  break;
		case State.Corridor2:  StateCorridor2();  break;
		case State.Corridor3:  StateCorridor3();  break;
		case State.Courtyard:  StateCourtyard();  break;
		case State.Floor:      StateFloor();      break;
		case State.InCloset:   StateInCloset();   break;
		case State.Lock0:      StateLock0();      break;
		case State.Lock1:      StateLock1();      break;
		case State.Mirror:     StateMirror();     break;
		case State.Sheets0:    StateSheets0();    break;
		case State.Sheets1:    StateSheets1();    break;
		case State.Stairs0:    StateStairs0();    break;
		case State.Stairs1:    StateStairs1();    break;
		case State.Stairs2:    StateStairs2();    break;
		}
	}

	void StateCell() {
		text.text =
			"You are in a prison cell, and you want to escape. There are " +
			"some dirty sheets on the bed, a mirror on the wall, and the door " +
			"is locked from the outside.\n\n" +
			"Press S to view Sheets, M to view Mirror and L to view Lock." ;
		if      (Input.GetKeyDown(KeyCode.S)) curState = State.Sheets0;
		else if (Input.GetKeyDown(KeyCode.M)) curState = State.Mirror;
		else if (Input.GetKeyDown(KeyCode.L)) curState = State.Lock0;
	}

	void StateCellMirror() {
		text.text =
			"You are still in your cell, and you STILL want to escape! There are " +
			"some dirty sheets on the bed, a mark where the mirror was, " +
			"and that pesky door is still there, and firmly locked!\n\n" +
			"Press S to view Sheets, or L to view Lock." ;
		if      (Input.GetKeyDown(KeyCode.S)) curState = State.Sheets1;
		else if (Input.GetKeyDown(KeyCode.L)) curState = State.Lock1;
	}

	void StateClosetDoor() {
		text.text =
			"You are looking at a closet door, unfortunately it's locked. " +
			"Maybe you could find something around to help enourage it open?\n\n" +
			"Press R to Return to the corridor.";
		if (Input.GetKeyDown(KeyCode.R)) curState = State.Corridor0;
	}

	void StateCorridor0() {
		text.text =
			"You're out of your cell, but not out of trouble." +
			"You are in the corridor, there's a closet and some stairs leading to " +
			"the courtyard. There's also various detritus on the floor.\n\n" +
			"C to view the Closet, F to inspect the Floor, and S to climb the stairs.";
		if      (Input.GetKeyDown(KeyCode.S)) curState = State.Stairs0;
		else if (Input.GetKeyDown(KeyCode.F)) curState = State.Floor;
		else if (Input.GetKeyDown(KeyCode.C)) curState = State.ClosetDoor;
	}

	void StateCorridor1() {
		text.text =
			"Still in the corridor. Floor still dirty. Hairclip in hand. " +
			"Now what? You wonder if that lock on the closet would succumb to " +
			"to some lock-picking?\n\n" +
			"P to Pick the lock, and S to climb the stairs.";
		if      (Input.GetKeyDown(KeyCode.P)) curState = State.InCloset;
		else if (Input.GetKeyDown(KeyCode.S)) curState = State.Stairs1;
	}

	void StateCorridor2() {
		text.text =
			"Back in the corridor, having declined to dress-up as a cleaner.\n\n" +
			"Press C to revisit the Closet, and S to climb the stairs.";
		if      (Input.GetKeyDown(KeyCode.C)) curState = State.InCloset;
		else if (Input.GetKeyDown(KeyCode.S)) curState = State.Stairs2;
	}

	void StateCorridor3() {
		text.text =
			"You're standing back in the corridor, now convincingly dressed as a cleaner. " +
			"You strongly consider the run for freedom.\n\n" +
			"Press S to take the Stairs, or U to Undress.";
		if      (Input.GetKeyDown(KeyCode.S)) curState = State.Courtyard;
		else if (Input.GetKeyDown(KeyCode.U)) curState = State.InCloset;
	}

	void StateCourtyard() {
		text.text =
			"You walk through the courtyard dressed as a cleaner. " +
			"The guard tips his hat at you as you waltz past, claiming " +
			"your freedom. You heart races as you walk into the sunset.\n\n" +
			"Press P to Play again." ;
		if (Input.GetKeyDown(KeyCode.P)) curState = State.Cell;
	}

	void StateFloor() {
		text.text =
			"Rummagaing around on the dirty floor, you find a hairclip.\n\n" +
			"Press R to Return to the standing, or H to take the Hairclip." ;
		if      (Input.GetKeyDown(KeyCode.R)) curState = State.Corridor0;
		else if (Input.GetKeyDown(KeyCode.H)) curState = State.Corridor1;
	}

	void StateInCloset() {
		text.text =
			"Inside the closet you see a cleaner's uniform that looks about your size! " +
			"Seems like your day is looking-up.\n\n" +
			"Press D to Dress up, or R to Return to the corridor.";
		if      (Input.GetKeyDown(KeyCode.R)) curState = State.Corridor2;
		else if (Input.GetKeyDown(KeyCode.D)) curState = State.Corridor3;
	}

	void StateLock0() {
		text.text =
			"This is one of those button locks. You have no idea what the " +
			"combination is. You wish you could somehow see where the dirty " +
			"fingerprints were, maybe that would help.\n\n" +
			"Press R to Return to roaming your cell." ;
		if (Input.GetKeyDown(KeyCode.R)) curState = State.Cell;
	}

	void StateLock1() {
		text.text =
			"You carefully put the mirror through the bars, and turn it round " +
			"so you can see the lock. You can just make out fingerprints around " +
			"the buttons. You press the dirty buttons, and hear a click.\n\n" +
			"Press O to Open, or R to Return to your cell." ;
		if      (Input.GetKeyDown(KeyCode.O)) curState = State.Corridor0;
		else if (Input.GetKeyDown(KeyCode.R)) curState = State.CellMirror;
	}

	void StateMirror() {
		text.text =
			"The dirty old mirror on the wall seems loose.\n\n" +
			"Press T to Take the mirror, or R to Return to cell." ;
		if      (Input.GetKeyDown(KeyCode.T)) curState = State.CellMirror;
		else if (Input.GetKeyDown(KeyCode.R)) curState = State.Cell;
	}

	void StateSheets0() {
		text.text =
			"You can't believe you sleep in these things. Surely it's " +
			"time somebody changed them. The pleasures of prison life " +
			"I guess!\n\n" +
			"Press R to Return to roaming your cell." ;
		if (Input.GetKeyDown(KeyCode.R)) curState = State.Cell;
	}

	void StateSheets1() {
		text.text =
			"Holding a mirror in your hand doesn't make the sheets look " +
			"any better.\n\n" +
			"Press R to Return to roaming your cell." ;
		if (Input.GetKeyDown(KeyCode.R)) curState = State.CellMirror;
	}

	void StateStairs0() {
		text.text =
			"You start walking up the stairs towards the outside light. " +
			"You realise it's not break time, and you'll be caught immediately. " +
			"You slither back down the stairs and reconsider.\n\n" +
			"Press R to Return to the corridor." ;
		if (Input.GetKeyDown(KeyCode.R)) curState = State.Corridor0;
	}

	void StateStairs1() {
		text.text =
			"Unfortunately weilding a puny hairclip hasn't given you the " +
			"confidence to walk out into a courtyard surrounded by armed guards!\n\n" +
			"Press R to Retreat down the stairs." ;
		if (Input.GetKeyDown(KeyCode.R)) curState = State.Corridor1;
	}

	void StateStairs2() {
		text.text =
			"You feel smug for picking the closet door open, and are still armed with " +
			"a hairclip (now badly bent). Even these achievements together don't give " +
			"you the courage to climb up the staris to your death!\n\n" +
			"Press R to Return to the corridor.";
		if (Input.GetKeyDown(KeyCode.R)) curState = State.Corridor2;
	}
}
