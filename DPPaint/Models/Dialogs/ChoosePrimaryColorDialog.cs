
using System;
using System.Collections.Generic;
using System.Linq;

using DPPaint.Models.ApplicationState;
using DPPaint.Views;

namespace DPPaint.Models.Dialogs
{
    public class ChoosePrimaryColorDialog : IDialogChoice<ShapeColor>
    {
        private readonly IApplicationState _applicationState;

        public ChoosePrimaryColorDialog(IApplicationState applicationState)
        {
            _applicationState = applicationState;
        }

        public string GetDialogTitle()
        {
            return "Primary Color";
        }

        public string GetDialogText()
        {
            return "Select a primary color from the menu below:";
        }

        public IEnumerable<ShapeColor> GetDialogOptions()
        {
            return Enum.GetValues(typeof(ShapeColor)).Cast<ShapeColor>().ToList();
        }

        public ShapeColor GetCurrentSelection()
        {
            return _applicationState.GetActivePrimaryColor();
        }
    }
}
