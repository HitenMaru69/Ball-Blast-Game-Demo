using System;
using System.Collections;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefeb;
    [SerializeField] Transform bulletSpwanPos;

    private void Start()
    {
        EventManager.Instance.FireBullet += SpwanBullet; 
    }

    private void Update()
    {
        //if(Input.GetKeyUp(KeyCode.Space))
        //{
        //    BulletFire();
        //}
    }

    private void SpwanBullet(object sender, EventArgs e)
    {
        BulletFire();  
    }

    void BulletFire()
    {
       
        Instantiate(bulletPrefeb, bulletSpwanPos.position, Quaternion.identity);
        
    }


    private void OnDisable()
    {
        EventManager.Instance.FireBullet -= SpwanBullet;
    }
}
