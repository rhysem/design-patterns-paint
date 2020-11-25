
using System;
using System.Collections.Generic;
using System.Linq;

using DPPaint.Models.ApplicationState;
using DPPaint.Views;

namespace DPPaint.Models.Dialogs
{
    public class ChooseShadingTypeDialog : IDialogChoice<ShapeShadingType>
    {
        private readonly IApplicationState _applicationState;

        public ChooseShadingTypeDialog(IApplicationState applicationState)
        {
            _applicationState = applicationState;
        }

        public string GetDialogTitle()
        {
            return "Shading Type";
        }

        public string GetDialogText()
        {
            return "Select a shading type from the menu below:";
        }

        public IEnumerable<ShapeShadingType> GetDialogOptions()
        {
            return Enum.GetValues(typeof(ShapeShadingType)).Cast<ShapeShadingType>().ToList();
        }

        public ShapeShadingType GetCurrentSelection()
        {
            return _applicationState.GetActiveShapeShadingType();
        }
    }
}
