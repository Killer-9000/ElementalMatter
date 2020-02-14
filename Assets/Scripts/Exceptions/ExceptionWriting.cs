using System;
using UnityEngine;

namespace Assets.Scripts.Exceptions
{
    public static class ExceptionWriting
    {
        public static void WriteException(Exception ex)
        {
            string exceptionMsg = "-- Message\n" +
                $"{ex.Message}\n" +
                $"-- Entire Message -----------\n" +
                $"{ex}\n";

            Debug.LogError(exceptionMsg);
        }
    }
}
