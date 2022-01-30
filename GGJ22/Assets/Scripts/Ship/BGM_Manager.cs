using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

public class BGM_Manager : MonoBehaviour
{

    EventInstance menu, gameplay;
	private void Start()
	{
		menu = FMODUnity.RuntimeManager.CreateInstance("event:/BGM-Menu");
		gameplay = FMODUnity.RuntimeManager.CreateInstance("event:/BGM-GamePlay");
		StartMenuTheme();
	}


	public void StopMenuTheme()
	{
		menu.stop(STOP_MODE.IMMEDIATE);
		gameplay.start();
		//menu.release();
	}

	public void StartMenuTheme()
	{
		menu.start();
		gameplay.stop(STOP_MODE.IMMEDIATE);
		//gameplay.release();
		//environment.release();
	}
}
