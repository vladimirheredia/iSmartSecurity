using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviorModule
{
    /// <summary>
    /// Interface for command pattern
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Execute method
        /// </summary>
        void Execute();
    }
}
