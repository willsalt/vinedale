﻿using Logo.Core.Interpretation;
using Logo.Core.Resources;
using Logo.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using ValueType = Logo.Core.Tokens.ValueType;

namespace Logo.Core.Procedures
{
    /// <summary>
    /// This class contains the implementations of core language features.
    /// </summary>
    public class CoreCommands : ICommandModule
    {
        /// <summary>
        /// Provides the definitions of procedures implemented in this class.
        /// </summary>
        /// <returns>The list of procedures defined in this class.</returns>
        public IList<LogoProcedure> RegisterProcedures()
        {
            return new LogoProcedure[]
            {
                new LogoCommand
                {
                    Name = "print",
                    Aliases = new[] { "pr" },
                    Redefinability = RedefinabilityType.DefineAlongside,
                    ParameterCount = 1,
                    Implementation = Print,
                    HelpText = Strings.CommandPrintHelpText,
                    ExampleText = Strings.CommandPrintExampleText,
                },
                new LogoCommand
                {
                    Name = "nodes",
                    Aliases = new string[0],
                    Redefinability = RedefinabilityType.DefineAlongside,
                    ParameterCount = 0,
                    Implementation = Nodes,
                    HelpText = Strings.CommandNodesHelpText,
                    ExampleText = string.Empty,
                },
                new LogoCommand
                {
                    Name = "recycle",
                    Aliases = new string[0],
                    Redefinability = RedefinabilityType.NonRedefinable,
                    ParameterCount = 0,
                    Implementation = Recycle,
                    HelpText = Strings.CommandRecycleHelpText,
                    ExampleText = string.Empty,
                },
                new LogoCommand
                {
                    Name = "repeat",
                    Aliases = new string[0],
                    Redefinability = RedefinabilityType.NonRedefinable,
                    ParameterCount = 2,
                    Implementation = Repeat,
                    HelpText = Strings.CommandRepeatHelpText,
                    ExampleText = Strings.CommandRepeatExampleText,
                },
                new LogoCommand
                {
                    Name = "space",
                    Aliases = new string[0],
                    Redefinability = RedefinabilityType.NonRedefinable,
                    ParameterCount = 0,
                    Implementation = SpaceUsed,
                    HelpText = Strings.CommandSpaceHelpText,
                    ExampleText = string.Empty,
                },
                new LogoCommand
                {
                    Name = "abs",
                    Aliases = new string[0],
                    Redefinability = RedefinabilityType.NonRedefinable,
                    ParameterCount = 1,
                    Implementation = MathAbs,
                    HelpText = Strings.CommandAbsHelpText,
                    ExampleText = Strings.CommandAbsExampleText,
                },
                new LogoCommand
                {
                    Name = "and",
                    Aliases = new string[0],
                    Redefinability = RedefinabilityType.NonRedefinable,
                    ParameterCount = 1,
                    Implementation = BoolAnd,
                    HelpText = Strings.CommandAndHelpText,
                    ExampleText = Strings.CommandAndExampleText,
                },
                new LogoCommand
                {
                    Name = "arctan",
                    Aliases = new string[0],
                    Redefinability = RedefinabilityType.NonRedefinable,
                    ParameterCount = 1,
                    Implementation = MathAtan,
                    HelpText = Strings.CommandArctanHelpText,
                    ExampleText = Strings.CommandArctanExampleText,
                },
                new LogoCommand
                {
                    Name = "cos",
                    Aliases = new string[0],
                    Redefinability = RedefinabilityType.NonRedefinable,
                    ParameterCount = 1,
                    Implementation = MathCos,
                    HelpText = Strings.CommandCosHelpText,
                    ExampleText = Strings.CommandCosExampleText,
                },
                new LogoCommand
                {
                    Name = "sin",
                    Aliases = new string[0],
                    Redefinability = RedefinabilityType.NonRedefinable,
                    ParameterCount = 1,
                    Implementation = MathSin,
                    HelpText = Strings.CommandSinHelpText,
                    ExampleText = Strings.CommandSinExampleText,
                },
                new LogoCommand
                {
                    Name = "tan",
                    Aliases = new string[0],
                    Redefinability = RedefinabilityType.NonRedefinable,
                    ParameterCount = 1,
                    Implementation = MathTan,
                    HelpText = Strings.CommandTanHelpText,
                    ExampleText = Strings.CommandTanExampleText,
                },
                new LogoCommand
                {
                    Name = "make",
                    Aliases = new string[0],
                    Redefinability = RedefinabilityType.NonRedefinable,
                    ParameterCount = 2,
                    Implementation = MakeVariable,
                    HelpText = Strings.CommandMakeHelpText,
                    ExampleText = Strings.CommandMakeExampleText,
                },
                new LogoCommand
                {
                    Name = "clearname",
                    Aliases = new string[0],
                    Redefinability = RedefinabilityType.NonRedefinable,
                    ParameterCount = 1,
                    Implementation = ClearVariable,
                    HelpText = Strings.CommandClearnameHelpText,
                    ExampleText = Strings.CommandClearnameExampleText,
                },
                new LogoCommand
                {
                    Name = "clearnames",
                    Aliases = new string[0],
                    Redefinability = RedefinabilityType.NonRedefinable,
                    ParameterCount = 0,
                    Implementation = ClearGlobalVariables,
                    HelpText = Strings.CommandClearnamesHelpText,
                    ExampleText = string.Empty,
                },
                new LogoCommand
                {
                    Name = "help",
                    Aliases = new string[0],
                    Redefinability = RedefinabilityType.DefineAlongside,
                    ParameterCount = 1,
                    Implementation = OutputHelpText,
                    HelpText = Strings.CommandHelpHelpText,
                    ExampleText = Strings.CommandHelpExampleText,
                },
                new LogoCommand
                {
                    Name = "pi",
                    Aliases = new string[0],
                    Redefinability = RedefinabilityType.NonRedefinable,
                    ParameterCount = 0,
                    Implementation = ReturnPi,
                    HelpText = Strings.CommandPiHelpText,
                    ExampleText = string.Empty,
                },
                new LogoCommand
                {
                    Name = "butfirst",
                    Aliases = new string[0],
                    Redefinability = RedefinabilityType.NonRedefinable,
                    ParameterCount = 1,
                    Implementation = ListButFirst,
                    HelpText = Strings.CommandButfirstHelpText,
                    ExampleText = Strings.CommandButfirstExampleText,
                },
                new LogoCommand
                {
                    Name = "butlast",
                    Aliases = new string[0],
                    Redefinability = RedefinabilityType.NonRedefinable,
                    ParameterCount = 1,
                    Implementation = ListButLast,
                    HelpText = Strings.CommandButlastHelpText,
                    ExampleText = Strings.CommandButlastExampleText,
                },
                new LogoCommand
                {
                    Name = "ascii",
                    Aliases = new string[0],
                    Redefinability = RedefinabilityType.NonRedefinable,
                    ParameterCount = 1,
                    Implementation = AsciiValue,
                    HelpText = Strings.CommandAsciiHelpText,
                    ExampleText = Strings.CommandAsciiExampleText,
                },
                new LogoCommand
                {
                    Name = "char",
                    Aliases = new string[0],
                    Redefinability = RedefinabilityType.NonRedefinable,
                    ParameterCount = 1,
                    Implementation = AsciiToChar,
                    HelpText = Strings.CommandCharHelpText,
                    ExampleText = Strings.CommandCharExampleText,
                },
                new LogoCommand
                {
                    Name = "count",
                    Aliases = new string[0],
                    Redefinability = RedefinabilityType.NonRedefinable,
                    ParameterCount = 1,
                    Implementation = Count,
                    HelpText = Strings.CommandCountHelpText,
                    ExampleText = Strings.CommandCountExampleText,
                },
                new LogoCommand
                {
                    Name = "difference",
                    Aliases = new string[0],
                    Redefinability = RedefinabilityType.NonRedefinable,
                    ParameterCount = 2,
                    Implementation = Difference,
                    HelpText = Strings.CommandDifferenceHelpText,
                    ExampleText = Strings.CommandDifferenceExampleText,
                },
            };
        }


        /// <summary>
        /// Converts a number to a character.
        /// </summary>
        /// <param name="context">The interpretor context.</param>
        /// <param name="input">Should contain one parameter representing a number.</param>
        /// <returns>A token containing a string.</returns>
        public LogoToken AsciiToChar(InterpretorContext context, params LogoToken[] input)
        {
            if (input[0].TokenValue.Type != ValueType.Number)
            {
                context.Interpretor.WriteOutputLine(Strings.CommandCharWrongTypeError);
                return null;
            }
            return new LogoToken
            {
                Evaluated = true,
                Literal = "char",
                TokenValue = new LogoValue { Type = ValueType.String, Value = Encoding.ASCII.GetString(new[] { Convert.ToByte(input[0].TokenValue.Value) }) }
            };
        }


        /// <summary>
        /// Converts a character to its ASCII number.
        /// </summary>
        /// <param name="context">The interpretor context.</param>
        /// <param name="input">Should contain one parameter representing a string.</param>
        /// <returns>A token containing a number.</returns>
        public LogoToken AsciiValue(InterpretorContext context, params LogoToken[] input)
        {
            if (input[0].TokenValue.Type != ValueType.String)
            {
                context.Interpretor.WriteOutputLine(Strings.CommandAsciiWrongTypeError);
                return null;
            }
            if (string.IsNullOrEmpty((string)input[0].TokenValue.Value))
            {
                return new LogoToken { Evaluated = true, Literal = "", TokenValue = new LogoValue { Type = ValueType.Number, Value = 0 } };
            }
            return new LogoToken
            {
                Evaluated = true,
                Literal = "ascii",
                TokenValue = new LogoValue { Type = ValueType.Number, Value = Encoding.ASCII.GetBytes((string)input[0].TokenValue.Value)[0] }
            };
        }


        /// <summary>
        /// Removes the first element from a list.
        /// </summary>
        /// <param name="context">The interpretor context.</param>
        /// <param name="input">Should contain a single token of list type.</param>
        /// <returns>A token containing a list.</returns>
        public LogoToken ListButFirst(InterpretorContext context, params LogoToken[] input)
        {
            LogoList clonedList;
            if (input[0].GetType() == typeof(LogoList))
            {
                clonedList = (LogoList)input[0].Clone();
            }
            else if (input[0].TokenValue.Type != ValueType.List)
            {
                context.Interpretor.StandardOutputWriter.WriteLine(Strings.CommandButfirstWrongTypeError);
                return null;
            }
            else
            {
                clonedList = (LogoList)input[0].TokenValue.Value;
            }
            clonedList.InnerContents.RemoveAt(0);
            clonedList.TokenValue = new LogoValue { Type = ValueType.List, Value = clonedList.Clone() };
            clonedList.RecreateLiteralValue();
            return clonedList;
        }


        /// <summary>
        /// Removes the last element from a list.
        /// </summary>
        /// <param name="context">The interpretor context.</param>
        /// <param name="input">Should contain a single token of list type.</param>
        /// <returns>A token containing a list.</returns>
        public LogoToken ListButLast(InterpretorContext context, params LogoToken[] input)
        {
            LogoList clonedList;
            if (input[0].GetType() == typeof(LogoList))
            {
                clonedList = (LogoList)input[0].Clone();
            }
            else if (input[0].TokenValue.Type != ValueType.List)
            {
                context.Interpretor.StandardOutputWriter.WriteLine(Strings.CommandButlastWrongTypeError);
                return null;
            }
            else
            {
                clonedList = (LogoList)input[0].TokenValue.Value;
            }
            clonedList.InnerContents.RemoveAt(clonedList.InnerContents.Count - 1);
            clonedList.TokenValue = new LogoValue { Type = ValueType.List, Value = clonedList.Clone() };
            clonedList.RecreateLiteralValue();
            return clonedList;
        }


        /// <summary>
        /// Defines and/or sets the value of a variable.
        /// </summary>
        /// <param name="context">The interpretor context.</param>
        /// <param name="input">Should contain two tokens, the first being the variable name and the second the variable value.</param>
        /// <returns><c>null</c></returns>
        public LogoToken MakeVariable(InterpretorContext context, params LogoToken[] input)
        {
            context.Interpretor.DebugOutputWriter.WriteLine(Strings.CommandMakeStartDebugMessage);
            if (input[1].Evaluated)
            {
                context.SetVariable((string)input[0].TokenValue.Value, input[1].TokenValue);
                context.Interpretor.DebugOutputWriter.WriteLine(string.Format(Strings.CommandMakeEndDebugMessage, input[0].TokenValue.Value, input[1].TokenValue.Value));
            }
            else if (input[1].GetType() == typeof(LogoList))
            {
                context.SetVariable((string)input[0].TokenValue.Value, new LogoValue { Type = ValueType.List, Value = input[1] });
            }
            else
            {
                context.Interpretor.EvaluateToken(input, 1, true);
                return MakeVariable(context, input);
            }
            return null;
        }


        /// <summary>
        /// Removes a variable from the global namespace.
        /// </summary>
        /// <param name="context">The interpretor context.</param>
        /// <param name="input">Should contain one token containing the variable name to remove.</param>
        /// <returns><c>null</c></returns>
        public LogoToken ClearVariable(InterpretorContext context, params LogoToken[] input)
        {
            if (input[0].TokenValue.Type == ValueType.String)
            {
                context.ClearVariable((string)input[0].TokenValue.Value);
            }
            return null;
        }


        /// <summary>
        /// Clears the global variable namespace.
        /// </summary>
        /// <param name="context">The interpretor context.</param>
        /// <param name="input">Not used.</param>
        /// <returns><c>null</c></returns>
        public LogoToken ClearGlobalVariables(InterpretorContext context, params LogoToken[] input)
        {
            context.ClearAllVariables();
            return null;
        }


        /// <summary>
        /// Implements the mathematical cosine function.
        /// </summary>
        /// <remarks>All trigonometrical functions assume the input is in radians.</remarks>
        /// <param name="context">The interpretor context.</param>
        /// <param name="input">Should contain one token containing a number.</param>
        /// <returns>A token containing the cosine of the input.</returns>
        public LogoToken MathCos(InterpretorContext context, params LogoToken[] input)
        {
            if (input[0].TokenValue.Type != ValueType.Number)
            {
                context.Interpretor.WriteOutputLine(Strings.CommandCosWrongTypeError);
                return null;
            }
            return new LogoToken
            {
                Evaluated = true,
                Literal = "cos",
                TokenValue = new LogoValue { Type = ValueType.Number, Value = Convert.ToDecimal(Math.Cos(Convert.ToDouble((decimal)input[0].TokenValue.Value))) }
            };
        }


        /// <summary>
        /// Implements the mathematical arctangent function.
        /// </summary>
        /// <remarks>All trigonometrical functions assume the input is in radians.</remarks>
        /// <param name="context">The interpretor context.</param>
        /// <param name="input">Should contain one token containing a number.</param>
        /// <returns>A token containing the arctangent of the input.</returns>
        public LogoToken MathAtan(InterpretorContext context, params LogoToken[] input)
        {
            if (input[0].TokenValue.Type != ValueType.Number)
            {
                context.Interpretor.WriteOutputLine(Strings.CommandArctanWrongTypeError);
                return null;
            }
            return new LogoToken
            {
                Evaluated = true,
                Literal = "arctan",
                TokenValue = new LogoValue { Type = ValueType.Number, Value = Convert.ToDecimal(Math.Atan(Convert.ToDouble((decimal)input[0].TokenValue.Value))) }
            };
        }


        /// <summary>
        /// Implements the sine function.
        /// </summary>
        /// <remarks>All trigonometrical functions assume the input is in radians.</remarks>
        /// <param name="context">The interpretor context.</param>
        /// <param name="input">Should contain one token containing a number.</param>
        /// <returns>A token containing the sine of the input.</returns>
        public LogoToken MathSin(InterpretorContext context, params LogoToken[] input)
        {
            if (input[0].TokenValue.Type != ValueType.Number)
            {
                context.Interpretor.WriteOutputLine(Strings.CommandSinWrongTypeError);
                return null;
            }
            return new LogoToken
            {
                Evaluated = true,
                Literal = "sin",
                TokenValue = new LogoValue { Type = ValueType.Number, Value = Convert.ToDecimal(Math.Sin(Convert.ToDouble((decimal)input[0].TokenValue.Value))) }
            };
        }


        /// <summary>
        /// Implements the tangent function
        /// </summary>
        /// <remarks>All trigonometrical functions assume the input is in radians.</remarks>
        /// <param name="context">The interpretor context.</param>
        /// <param name="input">Should contain one token containing a number.</param>
        /// <returns>A token containing the tangent of the input.</returns>
        public LogoToken MathTan(InterpretorContext context, params LogoToken[] input)
        {
            if (input[0].TokenValue.Type != ValueType.Number)
            {
                context.Interpretor.WriteOutputLine(Strings.CommandTanWrongTypeError);
                return null;
            }
            return new LogoToken
            {
                Evaluated = true,
                Literal = "tan",
                TokenValue = new LogoValue { Type = ValueType.Number, Value = Convert.ToDecimal(Math.Tan(Convert.ToDouble((decimal)input[0].TokenValue.Value))) }
            };
        }


        /// <summary>
        /// Performs a boolean AND operation on the elements of a list.
        /// </summary>
        /// <param name="context">The interpretor context.</param>
        /// <param name="input">Should contain one token containing a list.</param>
        /// <returns><c>true</c> if all elements in the input list evaluate to <c>true</c>, <c>false</c> otherwise.</returns>
        public LogoToken BoolAnd(InterpretorContext context, params LogoToken[] input)
        {
            if (input[0].TokenValue.Type != ValueType.List)
            {
                context.Interpretor.WriteOutputLine(Strings.CommandAndWrongTypeError);
                return null;
            }

            LogoList inputList = (LogoList)input[0].TokenValue.Value;
            context.Interpretor.EvaluateListContents(inputList, false);
            return new LogoToken
            {
                Evaluated = true,
                Literal = "and",
                TokenValue = new LogoValue
                {
                    Type = ValueType.Bool,
                    Value = (inputList.InnerContents.Count > 0) && inputList.InnerContents.All(t => t.TokenValue.Type == ValueType.Bool) && inputList.InnerContents.All(t => (bool)t.TokenValue.Value)
                }
            };
        }


        /// <summary>
        /// Returns the absolute value of a number.
        /// </summary>
        /// <param name="context">The interpretor context.</param>
        /// <param name="input">Should contain one token containing a number.</param>
        /// <returns>The absolute value of the input.</returns>
        public LogoToken MathAbs(InterpretorContext context, params LogoToken[] input)
        {
            if (input[0].TokenValue.Type != ValueType.Number)
            {
                context.Interpretor.WriteOutputLine(Strings.CommandAbsWrongTypeError);
                return null;
            }
            return new LogoToken { Evaluated = true, Literal = "abs", TokenValue = new LogoValue { Type = ValueType.Number, Value = Math.Abs((decimal)input[0].TokenValue.Value) } };
        }


        /// <summary>
        /// Returns π.
        /// </summary>
        /// <param name="context">The interpretor context.</param>
        /// <param name="dummy">Not used.</param>
        /// <returns>A token containing the number π.</returns>
        public LogoToken ReturnPi(InterpretorContext context, params LogoToken[] dummy)
        {
            return new LogoToken { Evaluated = true, Literal = Math.PI.ToString(CultureInfo.InvariantCulture), TokenValue = new LogoValue { Type = ValueType.Number, Value = (decimal)Math.PI } };
        }


        /// <summary>
        /// Calls the runtime garbage collector.  Largely implemented for nostalgia purposes.
        /// </summary>
        /// <param name="contaxt">Not used.</param>
        /// <param name="input">Not used.</param>
        /// <returns><c>null</c></returns>
        public LogoToken Recycle(InterpretorContext contaxt, params LogoToken[] input)
        {
            GC.Collect();
            return null;
        }


        /// <summary>
        /// Returns the total amount of system memory used by the running process.  Largely implemented for nostalgia purposes.
        /// </summary>
        /// <param name="context">Not used.</param>
        /// <param name="input">Not used.</param>
        /// <returns>A token containing the bytes used by the running process.</returns>
        public LogoToken SpaceUsed(InterpretorContext context, params LogoToken[] input)
        {
            LogoValue val = new LogoValue { Type = ValueType.Number, Value = (decimal)GC.GetTotalMemory(false) };
            return new LogoToken { Evaluated = true, Literal = "space", TokenValue = val };
        }


        /// <summary>
        /// Outputs the first parameter token to the context's output writer, followed by a new line.
        /// </summary>
        /// <param name="context">The interpretor context.</param>
        /// <param name="output">Should contain one token whose value is to be printed.</param>
        /// <returns><c>null</c></returns>
        public LogoToken Print(InterpretorContext context, params LogoToken[] output)
        {
            Type paramType = output[0].GetType();
            if (paramType == typeof(LogoList) || (paramType == typeof(LogoWord) && output[0].TokenValue.Type == ValueType.List))
            {
                if (context.Interpretor.EvaluateListContents((LogoList)output[0].TokenValue.Value, true) == InterpretationResult.SuccessComplete)
                {
                    context.Interpretor.WriteOutputLine(string.Join(" ", ((ContainerToken)output[0].TokenValue.Value).InnerContents.Select(t => t.TokenValue.Value.ToString())));
                }
            }
            else if (paramType == typeof(LogoWord) || paramType == typeof(LogoExpression))
            {
                if (output[0].TokenValue.Value != null)
                {
                    context.Interpretor.WriteOutputLine(output[0].TokenValue.Value.ToString());
                }
                else
                {
                    context.Interpretor.WriteOutputLine(string.Empty);
                }
            }
            else
            {
                context.Interpretor.WriteOutputLine(string.Join(" ", ((ContainerToken)output[0]).InnerContents.Select(t => t.Literal)));
            }
            return null;
        }


        /// <summary>
        /// Prints the total number of defined procedures and the number of distinct procedure names and aliases in the interpretor context, to the context's output writer.
        /// </summary>
        /// <param name="context">The interpretor context.</param>
        /// <param name="dummy">Not used.</param>
        /// <returns><c>null</c></returns>
        public LogoToken Nodes(InterpretorContext context, params LogoToken[] dummy)
        {
            context.Interpretor.WriteOutputLine(string.Format(Strings.CommandNodesOutput, context.Procedures.Count, context.ProcedureNames.Count));
            return null;
        }


        /// <summary>
        /// Prints the example text and help text for the given procedure or alias, to the context's output writer.
        /// </summary>
        /// <remarks>If the user has asked for help about the help command, by entering <c>help "help</c>, also prints a list of all procedures.</remarks>
        /// <param name="context">The interpretor context.</param>
        /// <param name="cmd">Should contain one token containing a string.</param>
        /// <returns><c>null</c></returns>
        public LogoToken OutputHelpText(InterpretorContext context, params LogoToken[] cmd)
        {
            if (!context.ProcedureNames.ContainsKey(cmd[0].TokenValue.Value.ToString()))
            {
                context.Interpretor.WriteOutputLine(string.Format(Strings.CommandHelpUnknownProcedureError, cmd[0].TokenValue.Value));
                return null;
            }

            IList<LogoProcedure> procList = context.ProcedureNames[cmd[0].TokenValue.Value.ToString()];
            if (procList.Count > 1)
            {
                context.Interpretor.WriteOutputLine(string.Format(Strings.CommandHelpActionCountOutput, cmd[0].TokenValue.Value, procList.Count));
            }
            foreach (LogoProcedure proc in procList)
            {
                context.Interpretor.WriteOutputLine(cmd[0].TokenValue.Value + " " + proc.ExampleText);
                context.Interpretor.WriteOutputLine(proc.HelpText + "\n");
            }
            if ("help" == (string)cmd[0].TokenValue.Value)
            {
                context.Interpretor.WriteOutputLine(Strings.CommandHelpHeadingOutput);
                foreach (string procName in context.ProcedureNames.Keys.OrderBy(s => s))
                {
                    context.Interpretor.WriteOutputLine("  " + procName);
                }
            }

            return null;
        }


        /// <summary>
        /// Executes a list of instructions a defined number of times.
        /// </summary>
        /// <param name="context">The interpretor context.</param>
        /// <param name="parameters">Should contain two tokens: the first should be the number of times to repeat the instruction list, and the second should be that list.</param>
        /// <returns><c>null</c></returns>
        public LogoToken Repeat(InterpretorContext context, params LogoToken[] parameters)
        {
            if (parameters[0].TokenValue.Type != ValueType.Number)
            {
                context.Interpretor.WriteOutputLine(Strings.CommandRepeatWrongRepeatTypeError);
                return null;
            }

            if (parameters[1].GetType() != typeof(LogoList))
            {
                context.Interpretor.WriteOutputLine(Strings.CommandRepeatWrongListTypeError);
                return null;
            }

            for (int i = 0; i < Convert.ToInt32(parameters[0].TokenValue.Value); ++i)
            {
                LogoList exec = (LogoList)((LogoList)parameters[1].TokenValue.Value).Clone();
                context.Interpretor.EvaluateListContents(exec, false);
            }

            return null;
        }


        /// <summary>
        /// Gives the length of a list or string.
        /// </summary>
        /// <param name="context">The intepretor context.</param>
        /// <param name="parameters">Should contain a single token, either a list or a string.</param>
        /// <returns>A token containing the number of elements (characters or list items) in the input token.</returns>
        public LogoToken Count(InterpretorContext context, params LogoToken[] parameters)
        {
            if (parameters[0].TokenValue.Type == ValueType.String)
                return new LogoToken
                {
                    Evaluated = true,
                    Literal = "count",
                    TokenValue = new LogoValue { Type = ValueType.Number, Value = (decimal)(parameters[0].TokenValue.Value as string).Length }
                };
            else if (parameters[0].TokenValue.Type == ValueType.List)
            {
                return new LogoToken
                {
                    Evaluated = true,
                    Literal = "count",
                    TokenValue = new LogoValue { Type = ValueType.Number, Value = (decimal)(parameters[0].TokenValue.Value as LogoList).InnerContents.Count }
                };
            }
            return new LogoToken
            {
                Evaluated = true,
                Literal = "count",
                TokenValue = new LogoValue { Type = ValueType.Number, Value = 1m }
            };
        }


        /// <summary>
        /// Subtracts one number from another.
        /// </summary>
        /// <param name="context">The interpretor context.</param>
        /// <param name="parameters">Should contain two tokens, both numbers.</param>
        /// <returns>A token containing the difference between the two numbers.</returns>
        public LogoToken Difference(InterpretorContext context, params LogoToken[] parameters)
        {
            if (parameters[0].TokenValue.Type != ValueType.Number || parameters[1].TokenValue.Type != ValueType.Number)
            {
                context.Interpretor.WriteOutputLine(Strings.CommandDifferenceTypeError);
                return null;
            }
            return new LogoToken
            {
                Evaluated = true,
                Literal = "difference",
                TokenValue = new LogoValue { Type = ValueType.Number, Value = ((decimal)parameters[0].TokenValue.Value) - ((decimal)parameters[1].TokenValue.Value) },
            };
        }
    }
}