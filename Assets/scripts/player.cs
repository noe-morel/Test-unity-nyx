using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public int maxhealth= 100;
    public int health;
    public HealthBar healthbar;
    public Renderer rend;
    public Color hitColor;
    public Color healColor;
    public float _DurationHit = 0.1f;
    public float _DurationHeal = 0.1f;
    public bool isHit;
    public bool isHeal;
    public float time;

    void Start(){
        health = maxhealth;
        healthbar.SetMaxHealth(maxhealth);
        rend = GetComponent<Renderer>();
        rend.material.SetColor("_ColorHit",hitColor);
        rend.material.SetColor("_ColorHeal",healColor);
        isHit=false;
        isHeal=false;
        time=Time.fixedTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)){
            transform.position = transform.position+transform.forward*0.2f;
        }
        if (Input.GetKey(KeyCode.DownArrow)){
            transform.position = transform.position-transform.forward*0.2f;
        }
        if (Input.GetKey(KeyCode.LeftArrow)){
            transform.RotateAround(transform.position,Vector3.up,-50*Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow)){
            transform.RotateAround(transform.position,Vector3.up,50*Time.deltaTime);
        }


        if (isHit && Time.time-time>_DurationHit){
            isHit = false;
            rend.material.SetInt("_IsHit",0);
        }
        if (isHeal && Time.time-time>_DurationHeal){
            isHeal = false;
            rend.material.SetInt("_IsHeal",0);
        }

        if (!isHeal && !isHit){
            if (Input.GetKeyDown(KeyCode.T)){
                TakeDamage(30);
                time = Time.fixedTime;
                isHit=true;
            rend.material.SetInt("_IsHit",1);
            }
            if (Input.GetKeyDown(KeyCode.H)){
                Heal(20);
                time = Time.fixedTime;
                isHeal = true;
                rend.material.SetInt("_IsHeal",1);
            }
        }


        if (health==0){
            Destroy(gameObject);
        }

        rend.material.SetInt("_NLines",health/10);
    }

    public void TakeDamage(int damage){
        health=Mathf.Max(0,health-damage);
        healthbar.SetHealth(health);
    }

    public void Heal(int heal){
        health=Mathf.Min(maxhealth,health+heal);
        healthbar.SetHealth(health);
    }
}   
