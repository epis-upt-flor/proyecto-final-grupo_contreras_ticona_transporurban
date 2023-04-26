﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Funciones
{
    public class Utilitarios
    {
        public static bool ValidarBool(System.Object aValue)
        {
            if (Convert.IsDBNull(aValue))
            {
                return false;
            }
            else
            {
                return Convert.ToBoolean(aValue);
            }
        }
        public static string ValidarStr(System.Object aValue)
        {
            //IsDBNull(aValue) 
            if (Convert.IsDBNull(aValue))
            {
                return String.Empty;
            }
            else
            {
                return Convert.ToString(aValue);

            }

        }
        public static DateTime ValidarDate(System.Object aValue)
        {
            if (Convert.IsDBNull(aValue))
            {
                return DateTime.Parse("01/01/1753");
            }
            else
            {
                return Convert.ToDateTime(aValue);
            }
        }
        public static int ValidarInteger(System.Object aValue)
        {
#pragma warning disable CS0252 // Posible comparación de referencias involuntaria: El lado de la mano izquierda necesita conversión
            if (Convert.IsDBNull(aValue) || aValue == "")
            {
                return short.Parse("0");
            }
            else
            {
                return Convert.ToInt32(aValue);
            }
#pragma warning restore CS0252 // Posible comparación de referencias involuntaria: El lado de la mano izquierda necesita conversión
        }
    }
}