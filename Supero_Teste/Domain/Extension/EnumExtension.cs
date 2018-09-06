using System;
using Domain.Enum;

namespace Domain.Extension
{
    public static class EnumExtension
    {
        public static T ToEnum<T>(this int enumString)
        {
            return (T)System.Enum.Parse(typeof(T), enumString.ToString());
        }

        public static string StatusDescription(this EStatus status)
        {
            switch (status)
            {
                case EStatus.NotStarted:
                    return "Não iniciada";
                case EStatus.InProgress:
                    return "Em andamento";
                case EStatus.Waiting:
                    return "Aguardando";
                case EStatus.Concluded:
                    return "Concluida";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
