using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Fruit : MonoBehaviour {

    public GameObject fruitSlicedPrefab;
    public float startForce = 15f;
    private Rigidbody2D rb;


	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Blade")
        {
            Vector3 direction = (collision.transform.position - this.transform.position).normalized;

            Quaternion rotation = Quaternion.LookRotation(direction);

            Instantiate(fruitSlicedPrefab, this.transform.position, rotation);
            Destroy(this.gameObject);
        }
    }


}
