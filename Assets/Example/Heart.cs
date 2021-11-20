using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour, IInteractable
{
	
	Transform tr;
	bool scaling;
	
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    
    public void Interact()
    {
        StartCoroutine(ChangeSize());
    }
	
	IEnumerator ChangeSize()
	{
		scaling = true;
		tr.localScale *= 2;
		yield return new WaitForSeconds(1f);
		tr.localScale /= 2;
		scaling = false;
	}
}
