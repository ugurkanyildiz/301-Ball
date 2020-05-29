using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Mover : MonoBehaviour
{
    public Text scoreText;
    Rigidbody rbody; //Rigidbody Objenin üzerindeki fizik hesaplanmasını(objenin hareketini) başlatır
    int score = 0;
    [SerializeField] float speed = 5; //[Serialize Field] bizim için arayüzde değişkenin görünmesini sağlar
    // public float speed; Serialize ile aynı tepkiyi verir
    void Start()
    {
        scoreText.text = "Score: " + score;
        rbody = GetComponent<Rigidbody>(); //GetComponent<Type>() bizim için verilen Type ta özelliği(Component) var ise objeden çekip getirir.
    }
    void Update()
    {

        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rbody.AddForce(dir * speed);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Red"))
        {
            score++;
        } 
        else
        {
            SceneManager.LoadScene(0);
        }
        scoreText.text = "Score: " + score;
        Destroy(other.gameObject);
    }
}
