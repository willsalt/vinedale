﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logo.Core.Tokens
{
    /// <summary>
    /// The possible result states of tokenisation.
    /// </summary>
    public enum TokeniserResultType
    {
        /// <summary>
        /// All input was successfully tokenised and produced a complete token list.
        /// </summary>
        SuccessComplete,

        /// <summary>
        /// Input was successfully tokenised, but the token list is incomplete and cannot be executed.
        /// </summary>
        SuccessIncomplete,

        /// <summary>
        /// Input was not successfully tokenised.
        /// </summary>
        Failure
    }
}