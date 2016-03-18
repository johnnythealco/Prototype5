using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameSetup : MonoBehaviour 
{
	public InputField nameInput;
	public Dropdown factionDropdown;
	public Button startGameButton;

	void Awake()
	{
		startGameButton.interactable = false;
	}

	void Start()
	{
		getFactionList ();
	}

	public void enableStarGameButton ()
	{
		startGameButton.interactable = true;
	}

	void CreatePlayer()
	{
		GameObject _playerObject = new GameObject ("Player: " + nameInput.text);
		var _player = _playerObject.AddComponent<Player> ();
		_playerObject.AddComponent<PlayerInputController> ();

		_player.faction = Game.Manager.getFaction (factionDropdown.value);

		Game.Manager.player = _playerObject.GetComponent<Player> ();
	}

	void getFactionList ()
	{
		factionDropdown.ClearOptions ();
		factionDropdown.AddOptions (Game.Manager.getfactionNameList ());
	}

	public void StartGame()
	{
		CreatePlayer ();
		SceneManager.LoadScene ("FleetBuilderTest");
	}
}
