﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logo.Core.Procedures
{
    /// <summary>
    /// The interface for classes which implement Logo commands in .NET.
    /// </summary>
    public interface ICommandModule
    {
        /// <summary>
        /// Provide definitions of the procedures implemented by this class.
        /// </summary>
        /// <returns>A list of procedure definitions.</returns>
        IList<LogoProcedure> RegisterProcedures();
    }
}
