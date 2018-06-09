﻿using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
/// <summary>
/// Submit button for client text input field
/// </summary>
[RequireComponent(typeof( Button ))]
[Serializable]
public class NetSubmitButton : NetUIElement
{
	public override string Value {
		get { return SourceInputField?.text ?? "-1"; }
		set {
			externalChange = true;
			SourceInputField.text = value;
			externalChange = false;
		}
	}
	public StringEvent ServerMethod;
	public InputField SourceInputField;
//	public string Text;
	
	public override void ExecuteServer() {
		ServerMethod.Invoke(Value);
	}
//	public override void Init() {
//
//	}
}
/// <inheritdoc />
/// "If you wish to use a generic UnityEvent type you must override the class type."
[Serializable]
public class StringEvent : UnityEvent<string> {}