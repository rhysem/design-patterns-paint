
using System;
using System.Collections.Generic;
using System.Linq;

using DPPaint.Models.ApplicationState;
using DPPaint.Views;

namespace DPPaint.Models.Dialogs
{
    public class ChooseSecondaryColorDialog : IDialogChoice<ShapeColor>
    {
        private readonly IApplicationState _applicationState;

        public ChooseSecondaryColorDialog(IApplicationState applicationState)
        {
            _applicationState = applicationState;
        }

        public string GetDialogTitle()
        {
            return "Secondary Color";
        }

        public string GetDialogText()
        {
            return "Select a secondary color from the menu below:";
        }

        public IEnumerable<ShapeColor> GetDialogOptions()
        {
            return Enum.GetValues(typeof(ShapeColor)).Cast<ShapeColor>().ToList();
        }

        public ShapeColor GetCurrentSelection()
        {
            return _applicationState.GetActiveSecondaryColor();
        }
    }
}
