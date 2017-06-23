using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SSActionEventType:int {Started, Competeted};

public interface ISSActionCallback {
	void SSActionEvent (SSAction source);
}
 