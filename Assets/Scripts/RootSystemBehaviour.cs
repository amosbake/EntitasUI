using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class RootSystemBehaviour : MonoBehaviour
{
	private Systems systems;
	
	// Use this for initialization
	void Start ()
	{
		var contexts = Contexts.sharedInstance;

		systems = new TutorialSystems(contexts);
		contexts.game.CreateEntity().AddTickComponents(0);
	}

	private void Update()
	{
		//执行系统集中的所有Execute方法  
		systems.Execute();
		//执行系统集中的所有Cleanup方法  
		systems.Cleanup();
	}
}
