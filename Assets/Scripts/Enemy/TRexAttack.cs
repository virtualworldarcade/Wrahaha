using UnityEngine;
using System.Collections;

public class TRexAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;
	public GameObject player;

    Animator anim;
    
    PlayerHealth playerHealth;
    //EnemyHealth enemyHealth;
    bool playerInRange = false;
    float timer;

    Transform trex;
    bool attacking = false;

    void Awake ()
    {
        //trex = GameObject.FindGameObjectWithTag("TRex").transform;
        //player = GameObject.FindGameObjectWithTag ("MainCamera");
        //playerHealth = player.GetComponent <PlayerHealth> ();
        //enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent <Animator> ();
		timer = 0.0f;
    }


    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = true;
        }
    }


    void OnTriggerExit (Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = false;
        }
    }


    void Update ()
    {
		
        timer += Time.deltaTime;
		//Debug.Log("timer: " + timer.ToString());
        //transform.Rotate(new Vector3(90f, 0f, 0f));
        //trex.rotation = Quaternion.Slerp(trex.rotation, Quaternion.Euler(90, 0, 0), Time.time);
        if (timer >= timeBetweenAttacks && playerInRange/* && enemyHealth.currentHealth > 0*/)
        {
            Attack ();
        }
		
        //if (attacking)
        //{
        //    trex.rotation = Quaternion.Slerp(trex.rotation, Quaternion.Euler(33, 247, 359), 1); //Time.deltaTime * 10
        //}
		
        //if(playerHealth.currentHealth <= 0)
        //{
        //    anim.SetTrigger ("PlayerDead");
        //}

    }


    void Attack ()
    {
        // unity wont display the log id you just put in "Attack" maybe it detected that
        // it already outputs it so it doesnt wanna output duplicates ? lame
        //Debug.Log("Attack: " + timer.ToString()); 
        Debug.Log("Attack");
        attacking = true;

		var playerHealth = player.GetComponent<PlayerHealth>();
		playerHealth.TakeDamage(10);
        timer = 0f;

        //trex.rotation = Quaternion.Slerp(trex.rotation, Quaternion.Euler(33, 247, 359), Time.deltaTime);
        //trex.rotation = Quaternion.Slerp(trex.rotation, Quaternion.Euler(33, 247, 359), Time.time * 10);
        //transform.Rotate(Quaternion.Euler(33, 247, 359), time.deltaTime*10);
        //trex.rotation = Quaternion.Euler(33, 247, 359);
        

        //if(playerHealth.currentHealth > 0)
        //{
        //    playerHealth.TakeDamage (attackDamage);
        //}
    }
}
