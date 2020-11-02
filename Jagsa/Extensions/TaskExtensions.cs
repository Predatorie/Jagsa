// TaskExtensions.cs
//
// Author:
//       mac-dev <aphextwin@gamerunners.co>
//
// Copyright (c) 2020 

namespace Jagsa.Extensions
{
    using System;
    using System.Threading.Tasks;

    public static class TaskExtensions
    {
        /// <summary> A Task extension method that awaits. </summary>
        /// <param name="task">              The task to act on. </param>
        /// <param name="completedCallback"> The completed callback. </param>
        /// <param name="errorCallback">     The error callback. </param>
        public static async void Await(this Task task, Action completedCallback, Action<Exception> errorCallback)
        {
            try
            {
                await task;
                completedCallback?.Invoke();
            }
            catch (Exception e)
            {
                errorCallback?.Invoke(e);
            }
        }
    }
}
