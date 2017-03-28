using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperAnimatiorScript : MonoBehaviour {

    private Animator anim;

	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();

    }

    public void Animator_SetSpeed(float speed)
    {
        anim.SetFloat("Speed", speed);
    }
    
    public void Animator_SetSquat(bool value)
    {
        anim.SetBool("Squat", value);
    }

    public void Animator_SetAiming(bool value)
    {
        anim.SetBool("Aiming", value);
    }

    public void Animator_Attack()
    {
        anim.SetTrigger("Attack");
    }

    public void Animator_Jump()
    {
        anim.SetTrigger("Jump");
    }

    public void Animator_Damage()
    {
        anim.SetTrigger("Damage");
    }

    public void Animator_SetDamageID(int DamageID)
    {
        anim.SetInteger("DamageID", DamageID);
    }

    public void Animator_Death()
    {
        anim.SetTrigger("Death");
    }
}
