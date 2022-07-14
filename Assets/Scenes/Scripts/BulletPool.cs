using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour {

    int memorySize = 15;

    [SerializeField] GameObject bullet;
    GameObject[] bullets;
    [SerializeField] GameObject origen;

    int shootNumber = -1;

    void Awake() {

        bullets = new GameObject[memorySize];
        
    }

    void Start() {

        for(int i = 0; i < memorySize; i++){

            bullets[i] = Instantiate(bullet, new Vector3(0, -i, 0), origen.transform.localRotation);
            bullets[i].SetActive(false);

        }
        
    }

    void ShootIncreaser(){

        shootNumber++;

        if(shootNumber > 14){

            shootNumber = 0;

        }

    }

    public void ShootBullet(){

        ShootIncreaser();

        if (bullets[14] != null ){

            bullets[shootNumber].transform.position = origen.transform.position;
            bullets[shootNumber].transform.rotation = origen.transform.rotation;
            bullets[shootNumber].SetActive(true);

        }

    }

}
