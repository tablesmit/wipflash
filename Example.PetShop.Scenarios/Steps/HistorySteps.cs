#region

using Example.PetShop.Scenarios.Utils;
using NUnit.Framework;
using WiPFlash.Components;
using WiPFlash.Framework;

#endregion

namespace Example.PetShop.Scenarios.Steps
{
    public class HistorySteps
    {
        private readonly Universe _universe;

        public HistorySteps(Universe universe)
        {
            _universe = universe;
        }

        public void ShouldContain(string expected)
        {
            _universe.Window.Find<Menu>("mainMenu").Find<Menu>("tabMenu").Select("TabPresenter[History]");
            var historyInput = _universe.Window.Find<RichTextBox>("historyInput");
            historyInput.WaitFor((hi, e) => ((RichTextBox)hi).Text.Contains(expected), src => Assert.Fail("History should have contained {0}", expected));
        }

        public void ShouldIncludeMostRecentPet(string name)
        {
            var view = _universe.Window.Find<GridView>("lastPetsOutput");
            Assert.AreEqual(view.TextAt(0, 2), name);
        }
    }
}