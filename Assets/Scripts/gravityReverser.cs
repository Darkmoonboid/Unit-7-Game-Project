using UnityEngine;
public class gravityReverser : MonoBehaviour
{
    private bool isGravityReversed = false;
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            Physics2D.gravity *= -1;
            isGravityReversed = !isGravityReversed;

            
            if (isGravityReversed)
            {
                Debug.Log("Gravity has been reversed!");
            }
            else
            {
                Debug.Log("Gravity has been restored!");
            }
        }
    }

}