using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class geral : MonoBehaviour
{


    // Update is called once per frame


    // Update is called once per frame
    void Update()
    {
        foreach (tareas.tarea t in tareas.listaTareas)
        {
            if (Time.time > t.momInicio)
            {
                t.accion();
                tareas.listaTareas.Remove(t);
                break;
            }
        }
    }
}

public static class tareas
{
    public class tarea
    {
        public float momInicio;
        public Action accion;
    }

    public static List<tarea> listaTareas = new List<tarea>();
    public static void Nueva(float tiempo, Action accion)
    {
        listaTareas.Add(new tarea
        {
            momInicio = Time.time + tiempo,
            accion = accion

        });
    }

    public static void limpiar()
    {
        listaTareas.Clear();
    }


}

