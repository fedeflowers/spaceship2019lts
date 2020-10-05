using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
	#region SIngleton:Game

	public static Game Instance;

	void Awake ()
	{
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}
	}

	#endregion
	// da mettere i players prefs ogni volta che si toccano i coins
	[SerializeField] Text[] allCoinsUIText;

	public int Coins;

	void Start ()
	{
		if (PlayerPrefs.HasKey("Coins")== true)
		{
			//UnityEngine.Debug.Log("coinsprefs");
			Coins = PlayerPrefs.GetInt("Coins");
        }
		UpdateAllCoinsUIText ();
	}

	public void UseCoins (int amount)
	{
		Coins -= amount;
		PlayerPrefs.SetInt("Coins", Coins);
	}

	public bool HasEnoughCoins (int amount)
	{
		return (Coins >= amount);
	}

	public void UpdateAllCoinsUIText ()
	{
		for (int i = 0; i < allCoinsUIText.Length; i++) {
			allCoinsUIText [i].text = Coins.ToString ();
		}
	}

}
