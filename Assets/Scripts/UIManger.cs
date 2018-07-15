using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManger : MonoBehaviour {

    public static UIManger instance;

	public Canvas canvas_gameover;

    public Image bloodBar_Up;
    public Image bloodBar_Down;
    public Text weaponInfoUp;
    public Text weaponInfoDown;

    void Awake()
	{
		if(instance == null)
		{
            instance = this;
        }
	}

    // Use this for initialization
    void Start () {

		DisableGameoverCanvas ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateBloodDisplay(bool up, int maxBlood, int currentBlood)
	{
		if(up)
		{
            bloodBar_Up.fillAmount = (float)currentBlood / (float)maxBlood;
        }
		else
		{
			bloodBar_Down.fillAmount = (float)currentBlood / (float)maxBlood;
		}
	}

	public void UpdateWeapon(bool up, Ninja.Weapon type, int amount)
	{
		switch (type)
		{
			case Ninja.Weapon.none:
			if(up)
			{
                weaponInfoUp.text = "";
            }
			else
			{
				weaponInfoDown.text = "";
			}
                break;
			case Ninja.Weapon.ninjaDouble:
			if(up)
			{
                weaponInfoUp.text = "替身  " + amount;
            }
			else
			{
				weaponInfoDown.text = "替身  " + amount;
			}
                break;
			case Ninja.Weapon.shuriken:
						if(up)
			{
                weaponInfoUp.text = "手裡劍  " + amount;
            }
			else
			{
				weaponInfoDown.text = "手裡劍  " + amount;
			}
                break;
			case Ninja.Weapon.vanish:
			if(up)
			{
                weaponInfoUp.text = "黑洞  " + amount;
            }
			else
			{
				weaponInfoDown.text = "黑洞  " + amount;
			}
                break;
            default:
                break;
        }
	}

	public void EnableGameoverCanvas () {

		canvas_gameover.gameObject.SetActive (true);
	}

	public void DisableGameoverCanvas () {

		canvas_gameover.gameObject.SetActive (false);
	}

	public void RestartLevel () {

		SceneManager.LoadScene (0);
	}
}
