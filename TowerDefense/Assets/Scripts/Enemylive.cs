using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Enemylive : MonoBehaviour
{
    private int life = 5;
    EnemyWaves wavesCode;
    private GameObject GameController;
    private Animator anim;
    [SerializeField] CinemachineDollyCart cinemachine;

    private void Start()
    {
        GameController = GameObject.Find("GAME CONTROLLER");
        wavesCode = GameController.GetComponent<EnemyWaves>();
        anim = GetComponent<Animator>();
        cinemachine = GetComponent<CinemachineDollyCart>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            GetDamage(10);
        }
    }

    public void GetDamage(int damage)
    {
        life = life - damage;
        if (life<=0)
        {
            anim.SetBool("isDead", true);//Animación de muerte
            
            Destroy(gameObject, 8f);
            cinemachine.m_Speed = 0; //Se apaga la velocidad para que quede estático
            wavesCode.AliveCount();
            
            /*if(wavesCode.currentAliveEnemies<=0)
            {
                StartCoroutine(wavesCode.WaveWaiter());
            }*/
        }
    }

}
