using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Player: MonoBehaviour
{
    public float moveSpeed = 5f;
    public int oxygenMax = 120;
    public int oxygenCurrent = 120;
    public int healthMax = 5;
    public int healthCurrent = 5;
    public Text infoText;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    private float elapsed = 0f;

    //inventory for elements
    public int inventoryCarbon = 0;
    //private int inventoryOxygen = 0;
    //private int inventorySulfur = 0;
    //private int inventoryHydrogen = 0;

    // Start is called before the first frame update
    void Start()
    {
        SetInfoText();
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= 1f)
        {
            elapsed = elapsed % 1f;
            oxygenCurrent -= 1;
        }
        SetInfoText();

        //input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //animation values
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        //other animation values
        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            animator.SetFloat("LastHorizontal", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("LastVertical", Input.GetAxisRaw("Vertical"));
        }

        //sets depth
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y*(0.1f));

        //test
        Input.GetKey("a");
        //{
        //    Hp++;
        //}
    }

    void FixedUpdate()
    {
        //movement
        rb.MovePosition(rb.position + movement*moveSpeed * Time.fixedDeltaTime);
    }

    void SetInfoText()
    {
        infoText.text = "Health: " + healthCurrent.ToString () + "/" + healthMax.ToString () +  "\n" + "Oxygen: " + oxygenCurrent.ToString() + "/" + oxygenMax.ToString();
    }
}