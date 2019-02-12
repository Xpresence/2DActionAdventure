using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

//namespace Death
//{
public class KillPlayer : MonoBehaviour 
{
    public GameObject spawnPoint;
    public GameObject player;

    void Awake ()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("Respawn"); // Точки нужно будет обновлять
        player = Resources.Load("Prefabs/Player") as GameObject;
        //player = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Player", typeof(GameObject)) as GameObject;
    }

    IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);

            yield return new WaitForSeconds(1f);

            Instantiate(player, spawnPoint.transform.position, Quaternion.identity);
        }
    }
}
//}
