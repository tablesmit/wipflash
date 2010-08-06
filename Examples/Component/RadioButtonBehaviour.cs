﻿#region

using System.Windows.Automation;
using NUnit.Framework;
using WiPFlash.Components;
using WiPFlash.Examples.ExampleUtils;

#endregion

namespace WiPFlash.Examples.Component
{
    [TestFixture]
    public class RadioButtonBehaviour : AutomationElementWrapperExamples<RadioButton>
    {
        [Test]
        public void ShouldAllowItselfToBeSelected()
        {
            RadioButton radioButton = CreateWrapper();
            Assert.False(radioButton.Selected);
            radioButton.Select();
            Assert.True(radioButton.Selected);
        }

        [Test]
        public void ShouldBeAbleToWaitForSelection()
        {
            GivenThisWillHappenAtSomePoint(rb => rb.Select());
            ThenWeShouldBeAbleToWaitFor((rb, e) => ((RadioButton)rb).Selected);
        }

        protected override RadioButton CreateWrapperWith(AutomationElement element, string name)
        {
            return new RadioButton(element, name);
        }

        protected override RadioButton CreateWrapper()
        {
            return LaunchPetShopWindow().Find<RadioButton>("cardPaymentInput");
        }
    }
}