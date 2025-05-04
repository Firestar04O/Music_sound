using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChayaneManager : MonoBehaviour
{
    //DEFINICION
    public static ChayaneManager Instance { get; private set; }
    //public -> público
    //static -> todas las instancias posibles de esta clase comparten ese mismo valor en esa variable
    //T o Tipo de tu clase
    //Instance -> nombre de la variable, ALTAMENTE RECOMENDADO: Usar Instance
    //{ get; private set; } -> getter y setter
    //get -> cualquiera puede obtener su valor actual
    //private set -> solo esta clase puede alterar su valor

    //VALIDACION
    private void Awake()
    {
        //Validar que sea ÚNICO
        //  NO SE TIENE QUE REPETIR
        //  NO TIENE QUE HABER UN VALOR YA ASIGNADO
        // si la Instancia ya tiene un valor && si la Instancia tiene un valor diferente a ESTA instancia
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }

        Instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    public void ChayaneMessage()
    {
        Debug.Log("Torero");
    }
}