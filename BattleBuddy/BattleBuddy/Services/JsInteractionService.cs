using System;

namespace BattleBuddy.Services
{
    public class JsInteractionService
    {
        private readonly ResourceProvider _resourceProvider;

        public JsInteractionService(ResourceProvider resourceProvider)
        {
            _resourceProvider = resourceProvider ?? throw new ArgumentNullException(nameof(resourceProvider));
        }

        public string GetSetupScript()
        {
            var script = _resourceProvider.GetResourceContentAsString(@"BattleBuddy.Resources.SetupJsFunctions.js");
            return script;
        }

        public string ExecuteScrollToEntry(Guid uid)
        {
            return $"scrollToEntry(\"{uid}\");";
        }

        public string ExecuteScrollToEntry(int percentage)
        {
            return $"scrollToPercent({percentage});";
        }
    }
}
