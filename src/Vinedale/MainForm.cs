﻿using Logo.Interpretation;
using Logo.Os;
using System.IO;
using System.Windows.Forms;
using Vinedale.Shell;
using Vinedale.Turtle;

namespace Vinedale
{
    public partial class MainForm : Form
    {
        private readonly StreamWriter _debugOutput;
        private readonly StreamWriter _standardOutput;
        private Interpretor _interp;
        private TurtleContext _turtle;

        public MainForm()
        {
            InitializeComponent();
            _turtle = new TurtleContext();
            turtleWindow1.TurtleContext = _turtle;
            _debugOutput = new StreamWriter(new ShellOutputStream(debugShell)) { AutoFlush = true };
            _standardOutput = new StreamWriter(new ShellOutputStream(interpShell)) { AutoFlush = true };
            _interp = new Interpretor(_standardOutput, _debugOutput, DebugMessageLevel.Logorrheic);
            _interp.LoadModule(new SystemCommands());
            _interp.LoadModule(new ShellCommands());
            _interp.LoadModule(new TurtleCommands(_turtle));
            _interp.StartInteractiveInterpretor();
            interpShell.Enabled = true;
            debugShell.Enabled = true;
        }

        private void InterpShell_CommandEntered(object sender, CommandEnteredEventArgs e)
        {
            if (_interp != null)
            {
                InterpretationResultType result = _interp.Interpret(e.Command);
                if (result == InterpretationResultType.SuccessIncomplete)
                {
                    interpShell.Prompt = "> ";
                }
                else
                {
                    interpShell.Prompt = "? ";
                }
            }
        }
    }
}
