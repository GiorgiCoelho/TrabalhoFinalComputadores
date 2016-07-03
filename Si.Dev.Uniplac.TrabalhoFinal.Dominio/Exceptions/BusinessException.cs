using System;

namespace Si.Dev.Uniplac.TrabalhoFinal.Dominio.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string msg) : base(msg)
        {
        }
    }
}