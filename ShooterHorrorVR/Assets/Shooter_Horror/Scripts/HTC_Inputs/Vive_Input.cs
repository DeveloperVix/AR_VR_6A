using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Vive_Input : MonoBehaviour 
{
    //https://valvesoftware.github.io/steamvr_unity_plugin/api/index.html

    public SteamVR_ActionSet m_ActionSet;

	public SteamVR_Action_Boolean m_BooleanAction;
	public SteamVR_Action_Vector2 m_TouchPosition;

	private void Awake() 
	{
		m_BooleanAction = SteamVR_Actions._default.GrabGrip;

		#region Events
		m_BooleanAction[SteamVR_Input_Sources.Any].onStateDown += BoolTest;

		//Fires when the action is non-zero
		m_TouchPosition[SteamVR_Input_Sources.Any].onAxis += AxisTest;
		#endregion	
	}

	private void Start() {
		m_ActionSet.Activate(SteamVR_Input_Sources.Any, 0, true);
	}

	// Update is called once per frame
	void Update ()
	{
		#region Boolean Action
		//Still works
		if(m_BooleanAction.GetStateDown(SteamVR_Input_Sources.Any))
		{

		}

		//Alternative - Data Access
		if(m_BooleanAction[SteamVR_Input_Sources.LeftHand].stateDown)
		{

		}

		//Alternative - Shortcut
		if(m_BooleanAction.stateDown)
		{
			print("AJA");
		}

		//New
		if(SteamVR_Actions._default.Teleport.GetStateUp(SteamVR_Input_Sources.Any))
		{

		}
		#endregion
	
		#region Vector2 Action

		Vector2 delta = m_TouchPosition[SteamVR_Input_Sources.RightHand].delta;
		
		#endregion
	}

	private void BoolTest (SteamVR_Action_Boolean action, SteamVR_Input_Sources source)
	{

	}

	private void AxisTest(SteamVR_Action_Vector2 action, SteamVR_Input_Sources source, Vector2 axis, Vector2 delta)
	{

	}
}
