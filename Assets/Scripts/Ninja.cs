using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : MonoBehaviour
{

    public enum Weapon
    {
        shuriken, ninjaDouble, vanish, none
    }

    public enum WeaponState
    {
        WaitForVanish, WaitForninjaDouble, none
    }

    [SerializeField] public int hp;
    [SerializeField] private bool canBeHurt;
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform foot;
    [SerializeField] private Transform hand;
    [SerializeField] private LayerMask LM;
    [SerializeField] bool isGrounded;
    [SerializeField] bool isJump;
    [SerializeField] AnimationCurve jumpCurve;
    [SerializeField] float maxJumpTime;
    [SerializeField] int ammoAmount;
    [SerializeField] bool isUp;

    private Weapon currentWeapon = Weapon.none;
    public WeaponState currentWeaponState = WeaponState.none;
    public const int MAX_HP = 3;
    public const int MIN_HP = 1;
    private float jumpTimer;
    private Animator anim;


    public GameObject shuriken;
    public GameObject ninjaDouble;
    public GameObject vanish;

    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hp = MAX_HP;
        canBeHurt = true;
        UIManger.instance.UpdateWeapon(isUp, currentWeapon, ammoAmount);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1") && ammoAmount > 0 && currentWeaponState == WeaponState.none)
        {
            anim.SetTrigger("Attack");
            GameObject clone;
            switch (currentWeapon)
            {
                case Weapon.shuriken:
                    Instantiate(shuriken, this.transform.position + new Vector3(0.8f, 0, 0), Quaternion.identity);
                    break;
                case Weapon.ninjaDouble:
                    clone = Instantiate(ninjaDouble, this.transform.position + new Vector3(1.5f, 0, 0), Quaternion.identity);
                    clone.GetComponent<NinjaDouble>().owner = this;
                    clone.transform.SetParent(gameObject.transform);
                    currentWeaponState = WeaponState.WaitForninjaDouble;
                    break;
                case Weapon.vanish:
                    clone = Instantiate(vanish, this.transform.position + new Vector3(0.8f, 0, 0), Quaternion.identity);
                    clone.GetComponent<Vanish>().owner = this;
                    currentWeaponState = WeaponState.WaitForVanish;
                    break;
                default:
                    break;
            }
            ammoAmount--;
            UIManger.instance.UpdateWeapon(isUp, currentWeapon, ammoAmount);


        }

        isGrounded = Physics2D.OverlapCircle(foot.position, 0.2f, LM, 0);
        if(!isGrounded)
        {
            anim.SetBool("isGrounded", false);
        }
        else
        {
            anim.SetBool("isGrounded", true);
        }
        if ((Input.GetButtonDown("Fire2") && isGrounded))
        {
            isJump = true;
        }

        if (Input.GetButton("Fire2") && isJump == true && jumpTimer < .5f)
        {
            jumpTimer += Time.deltaTime;
            rb.velocity = new Vector2(0, jumpForce * jumpCurve.Evaluate(jumpTimer));
        }

        if ((Input.GetButtonUp("Fire2")))
        {
            jumpTimer = 0;
            isJump = false;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        switch (other.tag)
        {

            case "heart":
                GainHp();
                Destroy(other.gameObject);
                break;

            case "sting":
                LoseHp();
                Destroy(other.gameObject);
                break;

            case "bomb":
                LoseHp();
                Destroy(other.gameObject);
                break;

            case "star":
                GetStar();
                Destroy(other.gameObject);
                break;

            case "box":
                GetBox();
                Destroy(other.gameObject);
                break;

            case "Shuriken":
                GetWeapon(Weapon.shuriken, 5);
                Destroy(other.gameObject);
                break;

            case "NinjaDouble":
                GetWeapon(Weapon.ninjaDouble, 3);
                Destroy(other.gameObject);
                break;

            case "Vanish":
                GetWeapon(Weapon.vanish, 3);
                Destroy(other.gameObject);
                break;
        }
    }

    void GainHp()
    {
        if (!IsValidHp(++hp))
        {
            hp = MAX_HP;

        }
        if (isUp)
        {
            UIManger.instance.UpdateBloodDisplay(true, MAX_HP, hp);
        }
        else
        {
            UIManger.instance.UpdateBloodDisplay(false, MAX_HP, hp);
        }
    }

    void LoseHp()
    {

        if (canBeHurt)
        {
            if (IsDead(--hp))
                GameOver();

        }
        if (isUp)
        {
            UIManger.instance.UpdateBloodDisplay(true, MAX_HP, hp);
        }
        else
        {
            UIManger.instance.UpdateBloodDisplay(false, MAX_HP, hp);
        }
    }

    bool IsValidHp(int hp)
    {

        return (hp > MAX_HP) ? false : true;
    }

    bool IsDead(int hp)
    {

        return (hp < MIN_HP) ? true : false;
    }

    void GetStar()
    {
        canBeHurt = false;
		this.gameObject.GetComponent<SpriteRenderer> ().color = Color.black;
        if (IsInvoking("LoseStar"))
            CancelInvoke();

        Invoke("LoseStar", 3.0f);
    }

    void LoseStar()
    {
		this.gameObject.GetComponent<SpriteRenderer> ().color = Color.white;
        canBeHurt = true;
    }

    void GetBox()
    {
        int r = Random.Range(0, 4);
        if(r == 0)
        {
            int[] c = new int[] { 100, 0, 0, 0, 0, 0, 0, 0 };
            SceneGeneratorSystem.instance.ChangeChoose(c);
            SceneGeneratorSystem.instance.Invoke("ChangeDefault", 5);
        }
        else if(r == 1)
        {
            GameManger.instance.scollingSpeed = 20;
            GameManger.instance.Invoke("ScollingSpeedDefault", 5);
        }
        else if(r == 2)
        {
            int[] c = new int[] { 0, 0, 0, 100, 0, 0, 0, 0 };
            SceneGeneratorSystem.instance.ChangeChoose(c);
            SceneGeneratorSystem.instance.Invoke("ChangeDefault", 5);
        }
        else if(r == 3)
        {
            SceneGeneratorSystem.instance.spawnRate = .3f;
            SceneGeneratorSystem.instance.Invoke("SpawnRateDefault", 3);
        }
    }

    void GameOver()
    {

        Destroy(this.gameObject);
        GameManger.instance.Gameover();
    }

    void GetWeapon(Weapon weaponType, int ammoMax)
    {
        UIManger.instance.UpdateWeapon(isUp, weaponType, ammoMax);
        currentWeapon = weaponType;
        ammoAmount = ammoMax;
    }
}
