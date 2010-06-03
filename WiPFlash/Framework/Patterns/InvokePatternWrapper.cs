using System;
using System.Windows.Automation;

namespace WiPFlash.Framework.Patterns
{
    public class InvokePatternWrapper
    {
        public InvokePatternWrapper(AutomationElement element)
        {
            Element = element;
        }

        public AutomationElement Element { get; set; }

        public void Invoke()
        {
            ((InvokePattern) Element.GetCurrentPattern(InvokePattern.Pattern)).Invoke();
        }
    }
}