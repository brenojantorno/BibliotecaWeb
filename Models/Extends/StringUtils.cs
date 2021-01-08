using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace BibliotecaWeb.Models.Extends
{
    /// <summary>
    /// Classe para extensão de metodos de string e Enums
    /// Ex: validação CPF/CNPJ
    /// </summary>
    public static class StringUtils
    {
        public static string Description(this Enum enumValue)
        {
            var desc = GetDisplayAttribute(enumValue);
            return desc != null ? desc.Description : desc.ToString();
        }
        private static DisplayAttribute GetDisplayAttribute(object value)
        {
            Type type = value.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException(string.Format("Type {0} is not an enum", type));
            }

            // Get the enum field.
            var field = type.GetField(value.ToString());
            return field == null ? null : field.GetCustomAttribute<DisplayAttribute>();
        }
    }

}