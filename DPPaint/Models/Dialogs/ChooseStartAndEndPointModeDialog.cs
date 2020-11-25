
using System;
using System.Collections.Generic;
using System.Linq;

using DPPaint.Models.ApplicationState;
using DPPaint.Views;

namespace DPPaint.Models.Dialogs
{
    public class ChooseStartAndEndPointModeDialog : IDialogChoice<MouseMode>
    {
        private readonly IApplicationState _applicationState;

        public ChooseStartAndEndPointModeDialog(IApplicationState applicationState)
        {
            _applicationState = applicationState;
        }

        public string GetDialogTitle()
        {
            return "Start and End Point Mode";
        }

        public string GetDialogText()
        {
            return "Select a shading type from the menu below:";
        }

        public IEnumerable<MouseMode> GetDialogOptions()
        {
            return Enum.GetValues(typeof(MouseMode)).Cast<MouseMode>().ToList();
        }

        public MouseMode GetCurrentSelection()
        {
            return _applicationState.GetActiveMouseMode();
        }
    }
}
