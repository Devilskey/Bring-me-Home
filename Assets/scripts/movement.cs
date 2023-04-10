using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float flospeed;
    public float flojumpspeed;
    public Rigidbody2D rb;
    public bool boGroundChecks;
    public bool boCheckWallR;
    public bool boCheckWallL;
    public player playerMain;
    public LayerMask lm;
    public Animator playerAnimation;
    public AudioSource Jumpsound;
    public Joystick joystick;
    public float dis;

    void Start()
    {
    }

    void Update()
    {
        PowerCheck(playerMain.floPowerState);
    }

    private void FixedUpdate()
    {
        Controles();
        groundCheck();
        WallCheck();
    }

        public void Jump()
    {
        Jumpsound.Play();
        rb.AddForce(transform.up * flojumpspeed );
    }

    private void Controles()
    {
        // axis = 
        float AxisH = joystick.Horizontal;
        float AxisV = joystick.Vertical;

        if (AxisV > 0.5f && boGroundChecks == true)
        {
            rb.AddForce(new Vector3(0, flojumpspeed * 3f, 0) / 100, ForceMode2D.Impulse);
            Jumpsound.Play();
        }
        if (AxisH < -0.5 && boCheckWallL == false)
        {
            transform.Translate(new Vector3(-(flospeed), 0, 0) * Time.deltaTime);
            playerMain.bodirection = true;
            playerAnimation.SetBool("movement", true);

        }
        if (AxisH > 0.5 && boCheckWallR == false)
        {
            transform.Translate(new Vector3((flospeed), 0, 0) * Time.deltaTime);
            playerMain.bodirection = false;
            playerAnimation.SetBool("movement", true);
        }
        if (AxisH == 0)
        {
            playerAnimation.SetBool("movement", false);
        }
    }

    public void PowerCheck(float _flopower)
    {
        switch (_flopower)
        {
            case 0:
                flojumpspeed = 85;
                flospeed = 3;
                dis = .27f;
                break;
            case 1:
                flojumpspeed = 110;
                flospeed = 3.5f;
                dis = 0.33f;
                break;
            case 2:
                flojumpspeed = 100;
                flospeed = 4.5f;
                dis = .47f;
                break;
                flojumpspeed = 95;
                flospeed = 4f;
                dis = .49f; 
                break;
            case 4:
                flojumpspeed = 90;
                flospeed = 3.7f;
                dis = .52f;
                break;
        }
    }

    public void groundCheck()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, -transform.up, dis, lm);
        Debug.DrawRay(transform.position, -transform.up, Color.red, dis);
        if(ray.collider != null)
        {
            playerAnimation.SetBool("OnAir", false);
            boGroundChecks = true;
        }
        else
        {
            playerAnimation.SetBool("OnAir", true);
            boGroundChecks = false;
        }
    }

    public void WallCheck()
    {
        float floRayLength = (playerMain.transform.lossyScale.x / 2) + 0.026f;
        Debug.Log(floRayLength);
        RaycastHit2D rayR = Physics2D.Raycast(transform.position, -transform.right, floRayLength, lm);
        RaycastHit2D rayL = Physics2D.Raycast(transform.position, transform.right, floRayLength, lm);
        Debug.DrawRay(transform.position, -transform.right, Color.red, floRayLength);
        Debug.DrawRay(transform.position, transform.right, Color.red, floRayLength);
        if (rayL.collider != null)
        {
            boCheckWallL = false;
            boCheckWallR = true;
        }
        else if(rayR.collider != null)
        {
            boCheckWallL = true;
            boCheckWallR = false;
        }
        else
        {
            boCheckWallL = false;
            boCheckWallR = false;
        }
    }
}
