using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{

    public float FloMonsterAmount;
    public float floPowerState = 0;
    public GameObject bullet;
    public bool bodirection;
    public SpriteRenderer sRPlayer;
    public Animator playerAnimation;
    float floTransparent;

    public bool boimune;
    public float immunitytimer;
    public bool transparantplus;
    public int intlevel;
    public movement m;
    public AudioSource powerup;
    public AudioSource hurt;
    public AudioSource shoot;
    void Start()
    {
        
    }

    void Update()
    {
        immunitytimer -= Time.deltaTime;
        if (floPowerState <= -1)
        {
            SceneManager.LoadScene(intlevel);
        }

        playerAnimation.SetInteger("PowerState", (int)floPowerState);
        LookDir();
        if (floPowerState > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            Shooting();
            PowerStateCheck();
        }
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "monster")
        {
            if (floPowerState < 4)
            {
                floPowerState += 1;
                Destroy(col.gameObject);
                PowerStateCheck();
                powerup.Play();
            }
        }
    }

    public void TakeDamage()
    {
        if (m.boGroundChecks == true)
        {
            m.Jump();
        }
        hurt.Play();
        floPowerState -= 1;
        PowerStateCheck();

    }

    public void LookDir()
    {
     sRPlayer.flipX = bodirection;
    }

    public void PowerStateCheck()
    {
        switch(floPowerState){
            case 0:
                transform.localScale = new Vector3(0.5f, 0.5f, 1);
                break;
            case 1:
                transform.localScale = new Vector3(0.6f, 0.6f, 1);
                break;
            case 2:
                transform.localScale = new Vector3(0.8f, 0.8f, 1);
                break;
            case 3:
                transform.localScale = new Vector3(0.8f, 0.8f, 1);
                break;
            case 4:
                transform.localScale = new Vector3(0.8f, 0.8f, 1);
                break;
        }
    }

    public void Shooting()
    {
        shoot.Play();
        floPowerState -= 1;
        GameObject firedBullet = Instantiate(bullet, transform.position, transform.rotation);

        firedBullet.GetComponent<bullet>().boDirection = bodirection;
        firedBullet.GetComponent<SpriteRenderer>().flipX = bodirection;
    }
}
