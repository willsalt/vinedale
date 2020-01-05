﻿using Logo.Core.Interpretation;
using Logo.Core.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logo.Core.Tokens
{
    /// <summary>
    /// A token representating an operator within an expression.
    /// </summary>
    public class LogoOperator : LogoWord
    {
        /// <summary>
        /// The kind of operation which this token represents.
        /// </summary>
        public OperatorType Operation { get; set; }

        /// <summary>
        /// The default constructor.
        /// </summary>
        protected LogoOperator() { }

        /// <summary>
        /// Constructs a token from an input string.
        /// </summary>
        /// <remarks>The input to this constructor should be a single-character string consisting of an operator symbol.</remarks>
        /// <param name="sym">The symbol to build a token from.</param>
        public LogoOperator(string sym)
        {
            Literal = sym;
            switch (sym)
            {
                case "+":
                    Operation = OperatorType.Add;
                    break;
                case "-":
                    Operation = OperatorType.Subtract;
                    break;
                case "*":
                    Operation = OperatorType.Multiply;
                    break;
                case "/":
                    Operation = OperatorType.Divide;
                    break;
                case "=":
                    Operation = OperatorType.Equals;
                    break;
            }
        }

        /// <summary>
        /// Produce a copy of this token.
        /// </summary>
        /// <returns>A token identical to this one.</returns>
        public override LogoToken Clone()
        {
            return new LogoOperator { Evaluated = Evaluated, Literal = Literal, Operation = Operation, TokenValue = TokenValue };
        }

        /// <summary>
        /// Carry out the computation represented by this operator.  The <c>TokenValue</c> property of this token is set to the result of the computation.
        /// </summary>
        /// <param name="args">The operator's arguments.</param>
        /// <returns>An <c>OperatorEvaluationResult</c> indicating success or failure and containing any error messages.</returns>
        public virtual OperatorEvaluationResult Perform(params LogoToken[] args)
        {
            switch (Operation)
            {
                case OperatorType.Add:
                    return PerformAddition(args);
                case OperatorType.Subtract:
                    return PerformSubtraction(args);
                case OperatorType.Multiply:
                    return PerformMultiplication(args);
                case OperatorType.Divide:
                    return PerformDivision(args);
                default:
                    return new OperatorEvaluationResult { Result = InterpretationResult.Failure, Message = Strings.OperatorUnknownOperationError };
            }
        }

        private OperatorEvaluationResult PerformAddition(LogoToken[] args)
        {
            if (args[0].TokenValue.Type == args[1].TokenValue.Type && args[0].TokenValue.Type == ValueType.Number)
            {
                TokenValue = new LogoValue { Type = ValueType.Number, Value = (decimal)args[0].TokenValue.Value + (decimal)args[1].TokenValue.Value };
            }
            else if (args[0].TokenValue.Type == args[1].TokenValue.Type && args[0].TokenValue.Type == ValueType.String)
            {
                TokenValue = new LogoValue { Type = ValueType.String, Value = (string)args[0].TokenValue.Value + (string)args[1].TokenValue.Value };
            }
            else if (args[0].TokenValue.Type == ValueType.String && args[1].TokenValue.Type == ValueType.Number)
            {
                TokenValue = new LogoValue { Type = ValueType.String, Value = (string)args[0].TokenValue.Value + (decimal)args[1].TokenValue.Value };
            }
            else if (args[0].TokenValue.Type == ValueType.Number && args[1].TokenValue.Type == ValueType.String)
            {
                TokenValue = new LogoValue { Type = ValueType.String, Value = (string)args[1].TokenValue.Value + (decimal)args[0].TokenValue.Value };
            }
            else
            {
                return new OperatorEvaluationResult { Result = InterpretationResult.Failure, Message = Strings.OperatorAdditionTypeError };
            }
            return new OperatorEvaluationResult { Result = InterpretationResult.SuccessComplete, Message = string.Empty };
        }


        private OperatorEvaluationResult PerformSubtraction(LogoToken[] args)
        {
            if (args[0].TokenValue.Type == args[1].TokenValue.Type && args[0].TokenValue.Type == ValueType.Number)
            {
                TokenValue = new LogoValue { Type = ValueType.Number, Value = (decimal)args[0].TokenValue.Value - (decimal)args[1].TokenValue.Value };
            }
            else
            {
                return new OperatorEvaluationResult { Result = InterpretationResult.Failure, Message = Strings.OperatorSubtractionTypeError };
            }
            return new OperatorEvaluationResult { Result = InterpretationResult.SuccessComplete, Message = string.Empty };
        }


        private OperatorEvaluationResult PerformMultiplication(LogoToken[] args)
        {
            if (args[0].TokenValue.Type == args[1].TokenValue.Type && args[0].TokenValue.Type == ValueType.Number)
            {
                TokenValue = new LogoValue { Type = ValueType.Number, Value = (decimal)args[0].TokenValue.Value * (decimal)args[1].TokenValue.Value };
            }
            else
            {
                return new OperatorEvaluationResult { Result = InterpretationResult.Failure, Message = Strings.OperatorMultiplicationTypeError };
            }
            return new OperatorEvaluationResult { Result = InterpretationResult.SuccessComplete, Message = string.Empty };
        }


        private OperatorEvaluationResult PerformDivision(LogoToken[] args)
        {
            if (args[0].TokenValue.Type == args[1].TokenValue.Type && args[0].TokenValue.Type == ValueType.Number)
            {
                TokenValue = new LogoValue { Type = ValueType.Number, Value = (decimal)args[0].TokenValue.Value / (decimal)args[1].TokenValue.Value };
            }
            else
            {
                return new OperatorEvaluationResult { Result = InterpretationResult.Failure, Message = Strings.OperatorDivisionTypeError };
            }
            return new OperatorEvaluationResult { Result = InterpretationResult.SuccessComplete, Message = string.Empty };
        }
    }
}