using UnityEngine;
using System.Collections;

/// <summary>
/// Clase axuliar que se usa junto con la clase Button y se encarga de procesar las acciones de los botones.
/// </summary>
public abstract class ButtonExecution: MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	/// <summary>
	/// Metodo abstracto que permite obtener el nombre del boton en el cual se hizo clic.
	/// </summary>
	/// <param name='nombreBoton'>
	/// Nombre boton.
	/// </param>
	public abstract void Execute(string nombreBoton, string destino);
	/// <summary>
	/// Executes the press.
	/// </summary>
	/// <param name='nombreBoton'>
	/// Nombre boton.
	/// </param>
	/// <param name='destino'>
	/// Destino.
	/// </param>
	public virtual void ExecutePress(string nombreBoton, string destino){
	}
}
