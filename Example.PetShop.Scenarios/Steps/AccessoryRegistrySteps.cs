#region

using System.Windows.Automation;
using Example.PetShop.Scenarios.Utils;
using NUnit.Framework;
using WiPFlash.Components;
using WiPFlash.Framework;

#endregion

namespace Example.PetShop.Scenarios.Steps
{
    public class AccessoryRegistrySteps
    {
        private readonly Universe _universe;

        public AccessoryRegistrySteps(Universe universe)
        {
            _universe = universe;
        }

        public void AreSelected(params string[] accessoryNames)
        {
            var accessoriesTab = _universe.Window.Find<Tab>(FindBy.WpfTitleOrText("Accessories"));
            accessoriesTab.Select();
            var scrollViewer =
                accessoriesTab.Find<ScrollViewer>(new PropertyCondition(AutomationElement.IsScrollPatternAvailableProperty, true));

            var table = accessoriesTab.Find<ListBox>("accessoriesOutput");

            foreach (var name in accessoryNames)
            {
                scrollViewer.ScrollDown(s => s.Contains(name),(s) => {});
                scrollViewer.ScrollUp(s => s.Contains(FindBy.WpfTitleOrText(name)), (s2) => Assert.Fail("Should have scrolled to {0}" + name));
            }

            
            table.Select(CollectionUtils.Convert(accessoryNames, name=> "Accessory[" + name + "]").ToArray());
        }
    }
}