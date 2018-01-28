using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{

    public class GameController : Behaviour {

	
	    // Update is called once per frame
	    void Update () {
            Input.Instance.Update();
	    }
    }


}