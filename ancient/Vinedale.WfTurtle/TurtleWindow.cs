﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vinedale.WfTurtle.Interfaces;

namespace Vinedale.WfTurtle
{
    /// <summary>
    /// A control which displays turtle graphics.
    /// </summary>
    public partial class TurtleWindow : UserControl
    {
        private ITurtleContext _turtleContext;

        /// <summary>
        /// The context which contains references to all of the turtles, for this window.
        /// </summary>
        public ITurtleContext TurtleContext
        {
            get
            {
                return _turtleContext;
            }
            set
            {
                if (_turtleContext != value)
                {
                    if (_turtleContext != null)
                    {
                        _turtleContext.InstructionsChanged -= FireRedrawNeeded;
                    }
                    _turtleContext = value;
                    if (_turtleContext != null)
                    {
                        _turtleContext.InstructionsChanged += FireRedrawNeeded;
                    }
                }
            }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public TurtleWindow()
        {
            InitializeComponent();
            ResizeRedraw = true;
        }

        /// <summary>
        /// Draws the window's instruction list.
        /// </summary>
        /// <param name="e">The event details.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (TurtleContext != null)
            {
                DrawEverything(e);
            }
        }

        private void FireRedrawNeeded(object sender, EventArgs e)
        {
            RedrawNeeded();
        }

        private void RedrawNeeded()
        {
            Invalidate();
        }

        private void DrawEverything(PaintEventArgs e)
        {
            TurtleContext.ExecuteDrawingInstructions(e, ClientRectangle);
            TurtleContext.CurrentTurtle.DrawTurtle(e, ClientRectangle);
        }
    }
}
